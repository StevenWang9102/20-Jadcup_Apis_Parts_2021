using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.BoxService;
using Jadcup.Services.Interface.SuborderService;
using Jadcup.Services.Model.SuborderLogModel;
using Jadcup.Services.Model.SuborderModel;
using Jadcup.Services.Model.WorkOrderModel;
using Jadcup.Services.Model.MachineModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.SuborderService
{
    public class SuborderManagementService : ISuborderManagementService
    {
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<Suborder> _suborderRepo;
        private readonly IGenericMySqlAccessRepository<Orders> _orderRepo;
        private readonly IGenericMySqlAccessRepository<OrderProduct> _orderProductRepo;
        private readonly IGenericMySqlAccessRepository<Machine> _machineRepo;
        private readonly IGenericMySqlAccessRepository<Parameter> _parameterRepo;
        private readonly IGenericMySqlAccessRepository<SuborderLog> _suborderLogRepo;
        private readonly IGenericMySqlAccessRepository<WorkOrder> _workOrderRepo;
        private readonly IGenericMySqlAccessRepository<WorkingArrangement> _workingArrangementRepo;       
        private readonly IGenericMySqlAccessRepository<ProductMachineMapping> _productMachineMappingRepo;
        private readonly IBoxManagementService _boxManagementService;
        private readonly IGenericMySqlAccessRepository<Box> _boxRepo;
        private readonly IGenericMySqlAccessRepository<Stock> _stockRepo;

        public SuborderManagementService(IMapper mapper,
            IGenericMySqlAccessRepository<Suborder> suborderRepo,
            IGenericMySqlAccessRepository<Orders> orderRepo,
            IGenericMySqlAccessRepository<OrderProduct> orderProductRepo,
            IGenericMySqlAccessRepository<Machine> machineRepo,
            IGenericMySqlAccessRepository<Parameter> parameterRepo,
            IGenericMySqlAccessRepository<SuborderLog> suborderLogRepo,
            IGenericMySqlAccessRepository<WorkOrder> workOrderRepo,
            IGenericMySqlAccessRepository<ProductMachineMapping> productMachineMappingRepo,
            IGenericMySqlAccessRepository<WorkingArrangement> workingArrangement,
            IBoxManagementService boxManagementService,
            IGenericMySqlAccessRepository<Box> boxRepo,
            IGenericMySqlAccessRepository<WorkingArrangement> workingArrangementRepo,
            IGenericMySqlAccessRepository<Stock> stockRepo)
        {
            _orderRepo = orderRepo;
            _orderProductRepo = orderProductRepo;
            _machineRepo = machineRepo;
            _parameterRepo = parameterRepo;
            _suborderLogRepo = suborderLogRepo;
            _workOrderRepo = workOrderRepo;
            _productMachineMappingRepo = productMachineMappingRepo;
            _boxManagementService = boxManagementService;
            _boxRepo = boxRepo;
            _stockRepo = stockRepo;
            _suborderRepo = suborderRepo;
            _workingArrangementRepo = workingArrangementRepo;
            _mapper = mapper;

        }

        public async Task<TaskResponse<bool>> Finish(string id, AddSuborderLogDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Suborder suborder = await _suborderRepo.GetQueryable().Include(s => s.WorkOrder).ThenInclude(wo => wo.Product)
                .FirstOrDefaultAsync(s => s.SuborderId == id);
            List<Suborder> suborders = await GetByWorkOrder(suborder.WorkOrderId,suborder);
            // update original suborder status to 10-partly completed, and completedQty = req.QTY
            suborder.SuborderStatusId = 10;
            suborder.CompletedQuanity = request.Quantity;

            if (IsLast(suborder, suborders)) 
            {//if last record
                if (suborder.WorkOrder.OrderTypeId == 2) //don't known
                {
                    await _boxManagementService.GenerateSemiBox(suborder);

                    Stock stock = await _stockRepo.GetQueryable()
                        .Include(s => s.Item)
                        .FirstOrDefaultAsync(s => s.Item.IsSemi == 1 && s.Item.ProductId == suborder.WorkOrder.ProductId);

                    if (stock == null)
                    {
                        throw new HttpException(System.Net.HttpStatusCode.NotFound, new SystemMessage("Stock not Found."));
                    }

                    stock.Quantity += request.Quantity;
                    _stockRepo.UpdateT(stock);
                }
                //end don't known
                Suborder productionSuborder = beforePackaging(suborders); //find matched prod suborder
                if (productionSuborder != null)
                {
                    if (productionSuborder.SuborderStatusId != 10 && productionSuborder.SuborderStatusId != 9) //if last suborder not finish
                    {
                        throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage("Cannot Finish Packaging Suborder. Production Suborder is not Finished."));
                    }
                }
                //find all last suborders, if all completed generate make up order
                List<Suborder> lastSuborders = suborders.Where(s => s.SequenceNo == suborder.SequenceNo).ToList();


                bool allCompleted = true;
                int finalQuantity = 0;
                Parameter para = await _parameterRepo.GetAsync((short)2);
                decimal rejectionRate = para.Value;

                short? errorMargin = suborder.WorkOrder.Product.MarginOfError;
                if  (errorMargin!=null && errorMargin>0 && errorMargin<100) 
                    rejectionRate =(decimal)(errorMargin/100);

                foreach (Suborder s in lastSuborders)
                {
                    if (s.SuborderStatusId != 10 && s.SuborderStatusId != 9)
                    {
                        allCompleted = false;
                    }
                    else
                    {
                        finalQuantity += s.CompletedQuanity.Value;
                    }
                }

                if (allCompleted)
                {
                    WorkOrder wo = await _workOrderRepo.GetQueryable()
                        .Include(w => w.OrderProduct)
                        .ThenInclude(w => w.Order)
                        .FirstOrDefaultAsync(w => w.WorkOrderId == suborder.WorkOrderId);
                    wo.WorkOrderStatusId = 10;
                    _workOrderRepo.UpdateT(wo);

                    if (wo.OrderProductId != null)
                    {
                        if (await AllFinished(wo))
                        {
                            wo.OrderProduct.Order.OrderStatusId = 11;
                            _orderRepo.UpdateT(wo.OrderProduct.Order);
                        }
                    }

                    if (finalQuantity < wo.Quantity / (1 + rejectionRate))
                    {
                        AddWorkOrderDto workOrderRequest = new AddWorkOrderDto
                        {
                            OrderProductId = wo.OrderProductId,
                            ProductId = wo.ProductId,
                            OrderTypeId = wo.OrderTypeId,
                            RequiredDate = wo.RequiredDate,
                            Quantity = (int)Math.Round((wo.Quantity / (1 + rejectionRate) - finalQuantity) * (1 + rejectionRate)),
                            WorkOrderSourceId = 5,
                            WorkOrderStatusId = -1
                        };

                        WorkOrder makeUpWorkOrder = _mapper.Map<WorkOrder>(workOrderRequest);
                        Guid workOrderId = Guid.NewGuid();
                        makeUpWorkOrder.WorkOrderId = workOrderId.ToString();
                        makeUpWorkOrder.CreatedAt = DateTime.UtcNow;
                        makeUpWorkOrder.WorkOrderNo = await GenerateWorkOrderNo();

                        _workOrderRepo.Insert(makeUpWorkOrder);
                    }
                }

            }
            else  //if is'nt last order
            {
                Suborder next = NextSuborder(suborder, suborders);//find next and update status and revqty
                if (next != null)
                {
                    next.SuborderStatusId = 1;
                    next.ReceivedQuantity = request.Quantity;
                    _suborderRepo.UpdateT(next);
                }
                else
                {
                    next = suborders.FirstOrDefault(s => s.ActionId == 4 && s.SuborderStatusId == 2 );  //why can not status==1
                    if (next == null)
                    {
                        throw new HttpException(System.Net.HttpStatusCode.NotFound, new SystemMessage("Cannot Find Corresponding Packaging Suborder. Please Confirm Packaging Suborder is Taken."));
                    }
                    next.ReceivedQuantity = request.Quantity;
                    _suborderRepo.UpdateT(next);
                }
            }

            AddSuborderLog(id, request);

            suborder.CompletedDate = DateTime.UtcNow;

            _suborderRepo.UpdateT(suborder);

            await _suborderRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetSuborderDto3>>> GetAll(sbyte? statusId, DateTime? start, DateTime? end)
        {
            TaskResponse<List<GetSuborderDto3>> response = new TaskResponse<List<GetSuborderDto3>>();
            List<GetSuborderDto3> results = new List<GetSuborderDto3>();

            List<Suborder> suborders = await _suborderRepo.GetQueryable()
                .Where(so => statusId == null || so.SuborderStatusId == statusId)
                .Where(so => start == null || so.CompletedDate >= start)
                .Where(so => end == null || so.CompletedDate <= end)
                .Include(so => so.WorkOrder)
                    .ThenInclude(w => w.Product)
                    .ThenInclude(p => p.BaseProduct)
                .Include(so => so.Action)
                .Include(so => so.SuborderStatus)
                .OrderByDescending(so => so.WorkOrder.Urgent)
                    .ThenBy(so => so.WorkOrder.RequiredDate)
                .ToListAsync();

            foreach (Suborder suborder in suborders)
            {
                GetSuborderDto3 dto = _mapper.Map<GetSuborderDto3>(suborder);

                List<SuborderLog> logs = await _suborderLogRepo.GetQueryable()
                    .Where(l => l.SuborderId == suborder.SuborderId)
                    .Include(l => l.Machine)
                    .Include(l => l.OperEmployee)
                    .Include(l => l.RawMaterialBox)
                        .ThenInclude(rmb => rmb.RawMaterial)
                    .OrderByDescending(l => l.CreatedAt)
                    .ToListAsync();
                if (logs.Count != 0)
                {
                    SuborderLog log = logs[0];
                    dto.SuborderLogDto = _mapper.Map<GetSuborderLogDto>(log);
                }

                results.Add(dto);
            }

            response.Data = results;
            return response;
        }

        public async Task<TaskResponse<GetSuborderDto>> GetById(string id)
        {
            TaskResponse<GetSuborderDto> response = new TaskResponse<GetSuborderDto>();

            Suborder suborder = await _suborderRepo.GetQueryable()
                .Include(so => so.WorkOrder)
                .ThenInclude(w => w.Product)
                .ThenInclude(p => p.BaseProduct)
                .ThenInclude(b => b.PackagingType)
                .Include(so => so.Action)
                .Include(so => so.SuborderStatus)
                .FirstOrDefaultAsync(so => so.SuborderId == id);

            if (suborder == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            response.Data = _mapper.Map<GetSuborderDto>(suborder);
            return response;
        }

        public async Task<TaskResponse<List<GetSuborderDto5>>> GetByDate( DateTime? completeDate)
        {
            if(completeDate == null) throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.NotEnterValidDate());

            TaskResponse<List<GetSuborderDto5>> response = new TaskResponse<List<GetSuborderDto5>>(); 
            List<GetSuborderDto5> results = new List<GetSuborderDto5>(); 
            var workingArrangements = await _workingArrangementRepo.GetQueryable().Include(wr =>wr.Machine)
                            .Where(wa =>wa.WorkingDate.Value.Date == completeDate.Value.Date ).ToListAsync();
            foreach (var workingArrangement in workingArrangements){
                var res = await GetByMachineId(workingArrangement.MachineId.Value,completeDate,true);
                GetSuborderDto5 suborderDto5 = new GetSuborderDto5();
                suborderDto5.Machine =  _mapper.Map<GetMachineDto2>(workingArrangement.Machine); 
                suborderDto5.Machine.Maintenance = workingArrangement.Maintenance;
                suborderDto5.Suborder =  res.Data;

                List<Suborder> completedSuborders = await _suborderRepo.GetQueryable()
                    // .Where(s => s.SuborderStatusId == 1)
                    .Include(s => s.WorkOrder)
                        .ThenInclude(w => w.Product)
                        .ThenInclude(p => p.BaseProduct)
                        .ThenInclude(b => b.PackagingType)
                    .Include(s => s.WorkOrder)
                        .ThenInclude(w => w.Product)
                        .ThenInclude(p => p.PalletStacking)
                    .Include(so => so.Action)
                    .Include(so => so.SuborderStatus)
                    .Where(so => so.CompletedDate.Value.Date == completeDate.Value.Date && 
                            so.SuborderLog.FirstOrDefault(sl => sl.MachineId ==workingArrangement.MachineId)!=null)
                    .OrderByDescending(so => so.CompletedDate)
                    .ThenBy(so => so.CreatedAt)
                    .ToListAsync();
                //  GetSuborderDto4 dtos = _mapper.Map<GetSuborderDto4>(completedSuborders);
                 foreach (var completedSuborder in completedSuborders){
                    suborderDto5.Suborder.Add(_mapper.Map<GetSuborderDto4>(completedSuborder));
                 }
                 results.Add(suborderDto5);
            }
            response.Data = results;
            return response;
        }
        
        public async Task<TaskResponse<List<GetSuborderDto5>>> GetByDate2( DateTime? completeDate)
        {
            if(completeDate == null) throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.NotEnterValidDate());

            TaskResponse<List<GetSuborderDto5>> response = new TaskResponse<List<GetSuborderDto5>>(); 
            List<GetSuborderDto5> results = new List<GetSuborderDto5>(); 
            var workingArrangements = await _workingArrangementRepo.GetQueryable().Include(wr =>wr.Machine)
                            .Where(wa =>wa.WorkingDate.Value.Date == completeDate.Value.Date ).ToListAsync();
            List<Suborder> completedSuborders = await _suborderRepo.GetQueryable()
                // .Where(s => s.SuborderStatusId == 1)
                .Include(s => s.WorkOrder)
                .ThenInclude(w => w.Product)
                .ThenInclude(p => p.BaseProduct)
                .ThenInclude(b => b.PackagingType)
                .Include(s => s.WorkOrder)
                .ThenInclude(w => w.Product)
                .ThenInclude(p => p.PalletStacking)
                .Include(so => so.Action)
                .Include(so => so.SuborderStatus)
                .Where(so => so.CompletedDate.Value.Date == completeDate.Value.Date).ToListAsync();
            
            foreach (var workingArrangement in workingArrangements){
                var res = await GetByMachineId1(workingArrangement.MachineId.Value,completeDate,true);
                GetSuborderDto5 suborderDto5 = new GetSuborderDto5();
                suborderDto5.Machine =  _mapper.Map<GetMachineDto2>(workingArrangement.Machine); 
                suborderDto5.Machine.Maintenance = workingArrangement.Maintenance;
                suborderDto5.Suborder =  res.Data;

                List<Suborder> completedSuborders2 = completedSuborders
                    .Where(so => 
                            so.SuborderLog.FirstOrDefault(sl => sl.MachineId ==workingArrangement.MachineId)!=null)
                    .OrderByDescending(so => so.CompletedDate)
                    .ThenBy(so => so.CreatedAt)
                    .ToList();
                //  GetSuborderDto4 dtos = _mapper.Map<GetSuborderDto4>(completedSuborders);
                 foreach (var completedSuborder in completedSuborders2){
                    suborderDto5.Suborder.Add(_mapper.Map<GetSuborderDto4>(completedSuborder));
                 }
                 results.Add(suborderDto5);
            }
            response.Data = results;
            return response;
        }
        
        public async Task<TaskResponse<List<GetSuborderDto5>>> GetByDate3( DateTime? completeDate)
        {
            if(completeDate == null) throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.NotEnterValidDate());

            TaskResponse<List<GetSuborderDto5>> response = new TaskResponse<List<GetSuborderDto5>>(); 
            List<GetSuborderDto5> results = new List<GetSuborderDto5>(); 
            var workingArrangements = await _workingArrangementRepo.GetQueryable().Include(wr =>wr.Machine)
                            .Where(wa =>wa.WorkingDate.Value.Date == completeDate.Value.Date ).ToListAsync();
            List<Suborder> completedSuborders = await _suborderRepo.GetQueryable()
                // .Where(s => s.SuborderStatusId == 1)
                .Include(s => s.WorkOrder)
                    .ThenInclude(w => w.Product)
                    .ThenInclude(p => p.BaseProduct)
                    .ThenInclude(b => b.PackagingType)
                .Include(s => s.WorkOrder)
                    .ThenInclude(w => w.Product)
                    .ThenInclude(p => p.PalletStacking)
                .Include(so => so.Action)
                .Include(so => so.SuborderStatus)
                .ToListAsync();
            
            foreach (var workingArrangement in workingArrangements){
                var res = await GetByMachineId3(workingArrangement.MachineId.Value,completeDate,true, completedSuborders);
                GetSuborderDto5 suborderDto5 = new GetSuborderDto5();
                suborderDto5.Machine =  _mapper.Map<GetMachineDto2>(workingArrangement.Machine); 
                suborderDto5.Machine.Maintenance = workingArrangement.Maintenance;
                suborderDto5.Suborder =  res.Data;
                List<Suborder> completedSuborders2 = completedSuborders
                    .Where(so => so.CompletedDate.Value.Date == completeDate.Value.Date &&
                        so.SuborderLog.FirstOrDefault(sl => sl.MachineId ==workingArrangement.MachineId)!=null)
                    .OrderByDescending(so => so.CompletedDate)
                    .ThenBy(so => so.CreatedAt)
                    .ToList();
                //  GetSuborderDto4 dtos = _mapper.Map<GetSuborderDto4>(completedSuborders);
                 foreach (var completedSuborder in completedSuborders2){
                    suborderDto5.Suborder.Add(_mapper.Map<GetSuborderDto4>(completedSuborder));
                 }
                 results.Add(suborderDto5);
            }
            response.Data = results;
            return response;
        }
        
        public async Task<TaskResponse<List<GetSuborderDto4>>> GetByMachineId3(short id, DateTime? completeDate,bool inclQueue, List<Suborder> completedSuborders)
        {
            TaskResponse<List<GetSuborderDto4>> response = new TaskResponse<List<GetSuborderDto4>>();

            List<GetSuborderDto4> results = new List<GetSuborderDto4>();

            List<ProductMachineMapping> pmms = await _productMachineMappingRepo.GetQueryable().Where(p => p.MachineId == id).ToListAsync();
            List<short?> baseProductIds = pmms.Select(p => p.BaseProductId).ToList();
            short? ActionId = pmms.Select(p => p.ActionId).FirstOrDefault();


            List<Suborder> awaitingSuborders = completedSuborders
                .Where(s => (s.SuborderStatusId == 1 && inclQueue==false ) ||
                    ((s.SuborderStatusId == 4 || s.SuborderStatusId == 1 )&& inclQueue== true))
                .Where(so => baseProductIds.Contains(so.WorkOrder.Product.BaseProductId) 
                    && so.ActionId == ActionId && so.WorkOrder.WorkOrderStatusId !=0 )
                .OrderByDescending(so => so.WorkOrder.Urgent)
                .ThenBy(so => so.CreatedAt)
                .Where(s => s.ReceivedQuantity!=0)
                .ToList();
            
            foreach (Suborder awaitingSuborder in awaitingSuborders)
            {
                GetSuborderDto4 dto = _mapper.Map<GetSuborderDto4>(awaitingSuborder); //new 一个新的，赋予awaitingSuborder的数据

                List<SuborderLog> suborderLogs = new List<SuborderLog>(); //new list 
                List<Suborder> suborders = await _suborderRepo.GetQueryable().Where(s => s.WorkOrderId == awaitingSuborder.WorkOrderId).ToListAsync();
                //找出suborder表中相同workOrderId的数据
                foreach (Suborder s in suborders) //遍历suborders
                {
                    List<SuborderLog> dbLogs = await _suborderLogRepo.GetQueryable().Where(l => l.SuborderId == s.SuborderId).Include(l => l.OperEmployee).ToListAsync();
                    //找出相同suborderId 的list数据
                    suborderLogs.AddRange(dbLogs);
                }
                dto.Logs = suborderLogs.Select(l => _mapper.Map<GetSuborderLogDto2>(l)).ToList();
                results.Add(dto);
            }


            results = results.OrderByDescending(s => s.WorkOrder.Urgent)
                .ThenBy(s => s.WorkOrder.RequiredDate)
                .ThenBy(s => s.CreatedAt)
                .ToList();

            List<SuborderLog> logs = await _suborderLogRepo.GetQueryable().Where(l => l.MachineId == id).ToListAsync();
            List<string> suborderIds = logs.Select(l => l.SuborderId).ToList().Distinct().ToList();


            List<Suborder> subordersWithLog = completedSuborders
            .Where(so => completeDate == null || so.CompletedDate == null || so.CompletedDate == completeDate)
            .Where(s => suborderIds.Contains(s.SuborderId))
            .ToList();

            foreach (Suborder suborderWithLog in subordersWithLog)
            {
                GetSuborderDto4 dto = _mapper.Map<GetSuborderDto4>(suborderWithLog);

                if (suborderWithLog.WorkOrder.OrderTypeId == 2 && (suborderWithLog.SuborderStatusId == 9 || suborderWithLog.SuborderStatusId == 10))
                {
                    List<Suborder> suborders = await GetByWorkOrder(suborderWithLog.WorkOrderId,null);
                    {
                        if (IsLast(suborderWithLog, suborders))
                        {
                            dto.IsSemiLast = true;
                        }
                    }
                }
                List<SuborderLog> suborderLogs = new List<SuborderLog>();
                List<Suborder> dbSuborders = await _suborderRepo.GetQueryable().Where(s => s.WorkOrderId == suborderWithLog.WorkOrderId).ToListAsync();
                foreach (Suborder s in dbSuborders)
                {
                    List<SuborderLog> dbLogs = await _suborderLogRepo.GetQueryable().Where(l => l.SuborderId == s.SuborderId).Include(l => l.OperEmployee).ToListAsync();
                    suborderLogs.AddRange(dbLogs);
                }
                dto.Logs = suborderLogs.Select(l => _mapper.Map<GetSuborderLogDto2>(l)).ToList();
                results.Add(dto);
            }

            response.Data = results;
            return response;
        }
        public async Task<TaskResponse<List<GetSuborderDto4>>> GetByMachineId(short id, DateTime? completeDate,bool inclQueue)
        {
            TaskResponse<List<GetSuborderDto4>> response = new TaskResponse<List<GetSuborderDto4>>();

            List<GetSuborderDto4> results = new List<GetSuborderDto4>();

            List<ProductMachineMapping> pmms = await _productMachineMappingRepo.GetQueryable().Where(p => p.MachineId == id).ToListAsync();
            List<short?> baseProductIds = pmms.Select(p => p.BaseProductId).ToList();
            short? ActionId = pmms.Select(p => p.ActionId).FirstOrDefault();


            List<Suborder> awaitingSuborders = await _suborderRepo.GetQueryable()
                .Where(s => (s.SuborderStatusId == 1 && inclQueue==false ) ||
                    ((s.SuborderStatusId == 4 || s.SuborderStatusId == 1 )&& inclQueue== true))
                .Include(s => s.WorkOrder)
                    .ThenInclude(w => w.Product)
                    .ThenInclude(p => p.BaseProduct)
                    .ThenInclude(b => b.PackagingType)
                .Include(s => s.WorkOrder)
                    .ThenInclude(w => w.Product)
                    .ThenInclude(p => p.PalletStacking)
                .Include(so => so.Action)
                .Include(so => so.SuborderStatus)
                .Where(so => baseProductIds.Contains(so.WorkOrder.Product.BaseProductId) 
                    && so.ActionId == ActionId && so.WorkOrder.WorkOrderStatusId !=0 )
                .OrderByDescending(so => so.WorkOrder.Urgent)
                .ThenBy(so => so.CreatedAt)
                .Where(s => s.ReceivedQuantity!=0)
                .ToListAsync();
            
            foreach (Suborder awaitingSuborder in awaitingSuborders)
            {
                GetSuborderDto4 dto = _mapper.Map<GetSuborderDto4>(awaitingSuborder); //new 一个新的，赋予awaitingSuborder的数据

                List<SuborderLog> suborderLogs = new List<SuborderLog>(); //new list 
                List<Suborder> suborders = await _suborderRepo.GetQueryable().Where(s => s.WorkOrderId == awaitingSuborder.WorkOrderId).ToListAsync();
                //找出suborder表中相同workOrderId的数据
                foreach (Suborder s in suborders) //遍历suborders
                {
                    List<SuborderLog> dbLogs = await _suborderLogRepo.GetQueryable().Where(l => l.SuborderId == s.SuborderId).Include(l => l.OperEmployee).ToListAsync();
                    //找出相同suborderId 的list数据
                    suborderLogs.AddRange(dbLogs);
                }
                dto.Logs = suborderLogs.Select(l => _mapper.Map<GetSuborderLogDto2>(l)).ToList();
                results.Add(dto);
            }


            results = results.OrderByDescending(s => s.WorkOrder.Urgent)
                .ThenBy(s => s.WorkOrder.RequiredDate)
                .ThenBy(s => s.CreatedAt)
                .ToList();

            List<SuborderLog> logs = await _suborderLogRepo.GetQueryable().Where(l => l.MachineId == id).ToListAsync();
            List<string> suborderIds = logs.Select(l => l.SuborderId).ToList().Distinct().ToList();


            List<Suborder> subordersWithLog = await _suborderRepo.GetQueryable()
            .Include(s => s.WorkOrder)
                .ThenInclude(w => w.Product)
                .ThenInclude(p => p.BaseProduct)
                .ThenInclude(b => b.PackagingType)
            .Include(s => s.WorkOrder)
                    .ThenInclude(w => w.Product)
                    .ThenInclude(p => p.PalletStacking)
            .Include(so => so.Action)
            .Include(so => so.SuborderStatus)
            .Where(so => completeDate == null || so.CompletedDate == null || so.CompletedDate == completeDate)
            .Where(s => suborderIds.Contains(s.SuborderId))
            .ToListAsync();

            foreach (Suborder suborderWithLog in subordersWithLog)
            {
                GetSuborderDto4 dto = _mapper.Map<GetSuborderDto4>(suborderWithLog);

                if (suborderWithLog.WorkOrder.OrderTypeId == 2 && (suborderWithLog.SuborderStatusId == 9 || suborderWithLog.SuborderStatusId == 10))
                {
                    List<Suborder> suborders = await GetByWorkOrder(suborderWithLog.WorkOrderId,null);
                    {
                        if (IsLast(suborderWithLog, suborders))
                        {
                            dto.IsSemiLast = true;
                        }
                    }
                }
                List<SuborderLog> suborderLogs = new List<SuborderLog>();
                List<Suborder> dbSuborders = await _suborderRepo.GetQueryable().Where(s => s.WorkOrderId == suborderWithLog.WorkOrderId).ToListAsync();
                foreach (Suborder s in dbSuborders)
                {
                    List<SuborderLog> dbLogs = await _suborderLogRepo.GetQueryable().Where(l => l.SuborderId == s.SuborderId).Include(l => l.OperEmployee).ToListAsync();
                    suborderLogs.AddRange(dbLogs);
                }
                dto.Logs = suborderLogs.Select(l => _mapper.Map<GetSuborderLogDto2>(l)).ToList();
                results.Add(dto);
            }

            response.Data = results;
            return response;
        }

        public async Task<TaskResponse<List<GetSuborderDto4>>> GetByMachineId1(short id, DateTime? completeDate,
            bool inclQueue)
        {
            TaskResponse<List<GetSuborderDto4>> response = new TaskResponse<List<GetSuborderDto4>>();

            List<GetSuborderDto4> results = new List<GetSuborderDto4>();

            List<ProductMachineMapping> pmms = await _productMachineMappingRepo.GetQueryable().Where(p => p.MachineId == id).ToListAsync();
            List<short?> baseProductIds = pmms.Select(p => p.BaseProductId).ToList();
            short? ActionId = pmms.Select(p => p.ActionId).FirstOrDefault();

            // List<Suborder> allSuborders = await _suborderRepo.GetQueryable()
            //     .Include(s => s.WorkOrder)
            //     .ThenInclude(w => w.Product)
            //     .ThenInclude(p => p.BaseProduct)
            //     .ThenInclude(b => b.PackagingType)
            //     .Include(s => s.WorkOrder)
            //     .ThenInclude(w => w.Product)
            //     .ThenInclude(p => p.PalletStacking)
            //     .Include(so => so.Action)
            //     .Include(so => so.SuborderStatus)
            //     .ToListAsync();
            //
            // List<Suborder> awaitingSuborders2 = allSuborders
            //     .Where(s => (s.SuborderStatusId == 1 && inclQueue==false ) || 
            //                 ((s.SuborderStatusId == 4 || s.SuborderStatusId == 1 )&& inclQueue== true))
            //     .Where(so => baseProductIds.Contains(so.WorkOrder.Product.BaseProductId) 
            //                  && so.ActionId == ActionId && so.WorkOrder.WorkOrderStatusId !=0 )
            //     .OrderByDescending(so => so.WorkOrder.Urgent)
            //     .ThenBy(so => so.CreatedAt)
            //     .Where(s => s.ReceivedQuantity!=0)
            //     .ToList();
            List<Suborder> awaitingSuborders = await _suborderRepo.GetQueryable()
                .Where(s => (s.SuborderStatusId == 1 && inclQueue==false ) ||
                            ((s.SuborderStatusId == 4 || s.SuborderStatusId == 1 )&& inclQueue== true))
                .Include(s => s.WorkOrder)
                .ThenInclude(w => w.Product)
                .ThenInclude(p => p.BaseProduct)
                .ThenInclude(b => b.PackagingType)
                .Include(s => s.WorkOrder)
                .ThenInclude(w => w.Product)
                .ThenInclude(p => p.PalletStacking)
                .Include(so => so.Action)
                .Include(so => so.SuborderStatus)
                .Where(so => baseProductIds.Contains(so.WorkOrder.Product.BaseProductId) 
                             && so.ActionId == ActionId && so.WorkOrder.WorkOrderStatusId !=0 )
                .OrderByDescending(so => so.WorkOrder.Urgent)
                .ThenBy(so => so.CreatedAt)
                .Where(s => s.ReceivedQuantity!=0)
                .ToListAsync();

            List<SuborderLog> logs1 = await _suborderLogRepo.GetQueryable().Include(l => l.OperEmployee).ToListAsync();

            foreach (Suborder awaitingSuborder in awaitingSuborders)
            {
                GetSuborderDto4 dto = _mapper.Map<GetSuborderDto4>(awaitingSuborder); //new 一个新的，赋予awaitingSuborder的数据

                List<SuborderLog> suborderLogs = new List<SuborderLog>(); //new list 
                List<Suborder> suborders = awaitingSuborders.Where(s => s.WorkOrderId == awaitingSuborder.WorkOrderId).ToList();
                //找出suborder表中相同workOrderId的数据
                foreach (Suborder s in suborders) //遍历suborders
                {
                    List<SuborderLog> dbLogs = logs1.Where(l => l.SuborderId == s.SuborderId).ToList();
                    //找出相同suborderId 的list数据
                    suborderLogs.AddRange(dbLogs);
                }
                dto.Logs = suborderLogs.Select(l => _mapper.Map<GetSuborderLogDto2>(l)).ToList();
                results.Add(dto);
            }
            
            
            results = results.OrderByDescending(s => s.WorkOrder.Urgent)
                .ThenBy(s => s.WorkOrder.RequiredDate)
                .ThenBy(s => s.CreatedAt)
                .ToList();

            List<SuborderLog> logs = logs1.Where(l => l.MachineId == id).ToList();
            List<string> suborderIds = logs.Select(l => l.SuborderId).ToList().Distinct().ToList();
            
            List<Suborder> subordersWithLog2 = await _suborderRepo.GetQueryable()
                .Include(s => s.WorkOrder)
                .ThenInclude(w => w.Product)
                .ThenInclude(p => p.BaseProduct)
                .ThenInclude(b => b.PackagingType)
                .Include(s => s.WorkOrder)
                .ThenInclude(w => w.Product)
                .ThenInclude(p => p.PalletStacking)
                .Include(so => so.Action)
                .Include(so => so.SuborderStatus).Where(so => completeDate == null || so.CompletedDate == null || so.CompletedDate == completeDate)
                .Where(s => suborderIds.Contains(s.SuborderId))
                // .ToList();
                .ToListAsync();
            // List<Suborder> subordersWithLog2 = allSuborders
            //     .Where(so => completeDate == null || so.CompletedDate == null || so.CompletedDate == completeDate)
            //     // .Where(s => suborderIds.Contains(s.SuborderId))
            //     .ToList();
            foreach (Suborder suborderWithLog in subordersWithLog2)
            {
                GetSuborderDto4 dto = _mapper.Map<GetSuborderDto4>(suborderWithLog);

                if (suborderWithLog.WorkOrder.OrderTypeId == 2 && (suborderWithLog.SuborderStatusId == 9 || suborderWithLog.SuborderStatusId == 10))
                {
                    List<Suborder> suborders = await GetByWorkOrder(suborderWithLog.WorkOrderId,null);
                    {
                        if (IsLast(suborderWithLog, suborders))
                        {
                            dto.IsSemiLast = true;
                        }
                    }
                }
                List<SuborderLog> suborderLogs = new List<SuborderLog>();
                List<Suborder> dbSuborders = await _suborderRepo.GetQueryable().Where(s => s.WorkOrderId == suborderWithLog.WorkOrderId).ToListAsync();
                foreach (Suborder s in dbSuborders)
                {
                    List<SuborderLog> dbLogs = logs.Where(l => l.SuborderId == s.SuborderId).ToList();
                    suborderLogs.AddRange(dbLogs);
                }
                dto.Logs = suborderLogs.Select(l => _mapper.Map<GetSuborderLogDto2>(l)).ToList();
                results.Add(dto);
            }

            response.Data = results;
            return response;
        }
        public async Task<TaskResponse<List<GetSuborderDto>>> GetByWorkOrderId(string id)
        {
            TaskResponse<List<GetSuborderDto>> response = new TaskResponse<List<GetSuborderDto>>();

            List<Suborder> so = await GetByWorkOrder(id,null);

            response.Data = so.Select(s => _mapper.Map<GetSuborderDto>(s)).ToList();
            return response;

        }

        public async Task<TaskResponse<bool>> PartlyFinish(string id, AddSuborderLogDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Suborder suborder = await _suborderRepo.GetQueryable().Include(s => s.WorkOrder).FirstOrDefaultAsync(s => s.SuborderId == id);
            List<Suborder> suborders = await GetByWorkOrder(suborder.WorkOrderId,suborder);

            AddSuborderDto current = _mapper.Map<AddSuborderDto>(suborder);
            current.SuborderStatusId = 1;
            current.ReceivedQuantity = suborder.ReceivedQuantity - request.Quantity;
            Add(current);

            suborder.SuborderStatusId = 9;
            suborder.CompletedQuanity = request.Quantity;
            suborder.CompletedDate = DateTime.UtcNow;

            if (!IsLast(suborder, suborders)) //generate new suborder with RevQTY =Org - PartlyCompleted
            {
                Suborder goNext = NextSuborder(suborder, suborders);
                AddSuborderDto nextSuborder = new AddSuborderDto();
                if (goNext != null)
                {
                    nextSuborder = _mapper.Map<AddSuborderDto>(goNext);
                    nextSuborder.SuborderStatusId = 4;
                }
                else//if matched packaging suborder, can not be found in NextSubOrder
                {
                    goNext = suborders.FirstOrDefault(s => s.ActionId == 4 && (s.SuborderStatusId == 2 ||s.SuborderStatusId == 1));
                    nextSuborder = _mapper.Map<AddSuborderDto>(goNext);
                    nextSuborder.ReceivedQuantity = current.ReceivedQuantity;
                    nextSuborder.SuborderStatusId = 1;
                }
                Add(nextSuborder);


                while (!IsLast(goNext, suborders)) //if still have next
                {
                    goNext = NextSuborder(goNext, suborders);  //find next with status is '10-Not Ready'
                    if (goNext != null)
                    {
                        nextSuborder = _mapper.Map<AddSuborderDto>(goNext);
                        nextSuborder.SuborderStatusId = 4;
                    }
                    else // if next is packaging ,possible status is taken or awaiting , generate a new suborder with status is awaiting and revqty = remaining
                    {
                        goNext = suborders.FirstOrDefault(s => s.ActionId == 4 && (s.SuborderStatusId == 1 || s.SuborderStatusId == 2));
                        nextSuborder = _mapper.Map<AddSuborderDto>(goNext);
                        nextSuborder.ReceivedQuantity = current.ReceivedQuantity;
                        nextSuborder.SuborderStatusId = 1;
                    }
                    Add(nextSuborder);
                }

                Suborder next = NextSuborder(suborder, suborders);  //update orginal suborder revQTY
                if (next != null)
                {
                    next.ReceivedQuantity = request.Quantity;
                    next.SuborderStatusId = 1;
                    _suborderRepo.UpdateT(next);
                }
                else
                {
                    next = suborders.FirstOrDefault(s => s.ActionId == 4 );

                    next.ReceivedQuantity = request.Quantity;
                    _suborderRepo.UpdateT(next);

                }
            }
            else
            {
                if (suborder.WorkOrder.OrderTypeId == 2) //?
                {
                    await _boxManagementService.GenerateSemiBox(suborder);

                    Stock stock = await _stockRepo.GetQueryable()
                        .Include(s => s.Item)
                        .FirstOrDefaultAsync(s => s.Item.IsSemi == 1 && s.Item.ProductId == suborder.WorkOrder.ProductId);

                    if (stock == null)
                    {
                        throw new HttpException(System.Net.HttpStatusCode.NotFound, new SystemMessage("Stock not Found."));
                    }

                    stock.Quantity += request.Quantity;
                    _stockRepo.UpdateT(stock);
                }
            }

            AddSuborderLog(id, request);
            _suborderRepo.UpdateT(suborder);

            await _suborderRepo.SaveAsync();

            response.Data = true;
            return response;

        }

        public async Task<TaskResponse<bool>> Pause(string id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Suborder suborder = await _suborderRepo.GetAsync(id);
            suborder.SuborderStatusId = 3;

            _suborderRepo.UpdateT(suborder);
            await _suborderRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> Unpause(string id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Suborder suborder = await _suborderRepo.GetAsync(id);
            suborder.SuborderStatusId = 2;

            _suborderRepo.UpdateT(suborder);
            await _suborderRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> TakeOrder(string id, AddSuborderLogDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Suborder suborder = await _suborderRepo.GetAsync(id);
            List<Suborder> suborders = await GetByWorkOrder(suborder.WorkOrderId,suborder);

            WorkOrder wo = await _workOrderRepo.GetQueryable()
                   .Include(w => w.OrderProduct)
                   .ThenInclude(op => op.Order)
                   .FirstOrDefaultAsync(w => w.WorkOrderId == suborder.WorkOrderId);

            if (IsFirst(suborder, suborders))
            {
                wo.WorkOrderStatusId = 2;
                _workOrderRepo.UpdateT(wo);

                if (wo.OrderProduct != null)
                {
                    wo.OrderProduct.Order.OrderStatusId = 10;
                    _orderRepo.UpdateT(wo.OrderProduct.Order);
                }


                // Suborder packagingSuborder = await _suborderRepo.GetQueryable().Where(s => s.ActionId == 4 && s.SuborderStatusId == 4).FirstOrDefaultAsync(s => s.WorkOrderId == wo.WorkOrderId);
                // if (packagingSuborder != null)
                // {
                //     packagingSuborder.SuborderStatusId = 1;
                //     _suborderRepo.UpdateT(packagingSuborder);
                // }
            }

            if (IsBeforePackaging(suborder, suborders))
            {
                // Suborder packagingSuborder = await _suborderRepo.GetQueryable().Where(s => s.ActionId == 4 ).FirstOrDefaultAsync(s => s.WorkOrderId == wo.WorkOrderId);
                Suborder packagingSuborder = suborders.FirstOrDefault(s => s.ActionId==4);
                if (packagingSuborder != null)
                {
                     packagingSuborder.SuborderStatusId = 1;
                    //  _suborderRepo.UpdateT(packagingSuborder);                    
                    packagingSuborder.ReceivedQuantity = suborder.ReceivedQuantity;
                    _suborderRepo.UpdateT(packagingSuborder);
                }
            }

            if (request.BoxId != null)
            {
                Box box = await _boxRepo.GetAsync(request.BoxId);
                if (box == null)
                {
                    throw new HttpException(System.Net.HttpStatusCode.NotFound, new SystemMessage("Box not Found."));
                }

                box.Quantity -= suborder.ReceivedQuantity.Value;
                _boxRepo.UpdateT(box);

                Stock stock = await _stockRepo.GetQueryable()
                        .Include(s => s.Item)
                        .FirstOrDefaultAsync(s => s.Item.IsSemi == 1 && s.Item.ProductId == suborder.WorkOrder.ProductId);

                if (stock == null)
                {
                    throw new HttpException(System.Net.HttpStatusCode.NotFound, new SystemMessage("Stock not Found."));
                }

                stock.Quantity -= (decimal)suborder.ReceivedQuantity;
                _stockRepo.UpdateT(stock);
            }

            AddSuborderLog(id, request);

            suborder.SuborderStatusId = 2;
            _suborderRepo.UpdateT(suborder);
            await _suborderRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetSuborderLogDto>>> GetSuborderLog(string suborderId, int? operEmployeeId, string rawMaterialBoxId, short? machineId)
        {
            TaskResponse<List<GetSuborderLogDto>> response = new TaskResponse<List<GetSuborderLogDto>>();

            List<SuborderLog> slogs = await _suborderLogRepo.GetQueryable()
                .Where(s => suborderId == null || s.SuborderId == suborderId)
                .Where(s => operEmployeeId == null || s.OperEmployeeId == operEmployeeId)
                .Where(s => rawMaterialBoxId == null || s.RawMaterialBoxId == rawMaterialBoxId)
                .Where(s => machineId == null || s.MachineId == machineId)
                .Include(s => s.Machine)
                .Include(s => s.RawMaterialBox)
                .Include(s => s.OperEmployee)
                .Include(s => s.Box)
                    .ThenInclude(b => b.Product)
                .ToListAsync();

            response.Data = slogs.Select(s => _mapper.Map<GetSuborderLogDto>(s)).ToList();
            return response;
        }


        //function
        public void Add(AddSuborderDto request)
        {
            Guid id = Guid.NewGuid();

            Suborder so = _mapper.Map<Suborder>(request);
            so.CreatedAt = DateTime.UtcNow;
            so.SuborderId = id.ToString();

            _suborderRepo.Insert(so);
        }

        public async Task<List<Suborder>> GetByWorkOrder(string id,Suborder subOrder)
        {
            if (subOrder==null){
                List<Suborder> so = await _suborderRepo.GetQueryable()
                .Include(so => so.Action)
                .Include(so => so.SuborderStatus)
                .Where(s => s.WorkOrderId == id)
                .OrderBy(s => s.SequenceNo)
                .ThenBy(s => s.CreatedAt)
                .ToListAsync();
                return so;
            }
            else{
                List<Suborder> so = await _suborderRepo.GetQueryable()
                .Include(so => so.Action)
                .Include(so => so.SuborderStatus)
                .Where(s => s.WorkOrderId == id && s.CreatedAt == subOrder.CreatedAt)
                .OrderBy(s => s.SequenceNo)
                .ThenBy(s => s.CreatedAt)
                .ToListAsync();
                return so;
            }
            
        }

        public bool IsFirst(Suborder suborder, List<Suborder> suborders)
        {
            bool first = suborder.SequenceNo == suborders.Min(s => s.SequenceNo);
            return first;
        }

        public bool IsLast(Suborder suborder, List<Suborder> suborders)
        {
            bool last = suborder.SequenceNo == suborders.Max(s => s.SequenceNo);
            return last;
        }

        public bool IsBeforePackaging(Suborder suborder, List<Suborder> suborders)
        {
            Suborder packaging = suborders.FirstOrDefault(s => s.ActionId == 4);

            if (packaging != null)
            {
                List<Suborder> subordersDesending = suborders.OrderByDescending(s => s.SequenceNo).ToList();
                Suborder beforePackaging = subordersDesending.FirstOrDefault(s => s.SequenceNo < packaging.SequenceNo);
                bool before = suborder.SequenceNo == beforePackaging.SequenceNo;

                return before;
            }

            return false;
        }

        public Suborder beforePackaging(List<Suborder> suborders)
        {
            Suborder packaging = suborders.FirstOrDefault(s => s.ActionId == 4);

            if (packaging != null)
            {
                List<Suborder> subordersDesending = suborders.OrderByDescending(s => s.SequenceNo).ToList();
                Suborder beforePackaging = subordersDesending.FirstOrDefault(s => s.SequenceNo < packaging.SequenceNo);
                return beforePackaging;
            }
            return null;
        }

        public Suborder NextSuborder(Suborder suborder, List<Suborder> suborders)
        {
            Suborder next = suborders.FirstOrDefault(s => s.SequenceNo > suborder.SequenceNo && s.SuborderStatusId == 4);
            return next;
        }


        public async Task<bool> AllFinished(WorkOrder workOrder)
        {
            List<OrderProduct> orderProducts = await _orderProductRepo.GetQueryable().Where(op => workOrder.OrderProduct.Order.OrderId == workOrder.OrderProduct.OrderId).ToListAsync();
            List<string> orderProductIds = orderProducts.Select(o => o.OrderProductId).ToList();
            List<WorkOrder> workOrders = await _workOrderRepo.GetQueryable().Where(wo => orderProductIds.Contains(wo.OrderProductId)).ToListAsync();
            bool allFinished = true;
            foreach (WorkOrder wo in workOrders)
            {
                if (wo.WorkOrderStatusId != 10 && wo.WorkOrderStatusId != 9)
                {
                    allFinished = false;
                }
            }

            return allFinished;
        }

        public void AddSuborderLog(string suborderId, AddSuborderLogDto request)
        {
            Guid logId = Guid.NewGuid();

            SuborderLog slog = _mapper.Map<SuborderLog>(request);
            slog.SuborderLogId = logId.ToString();
            slog.CreatedAt = DateTime.UtcNow;
            slog.SuborderId = suborderId;

            _suborderLogRepo.Insert(slog);
        }
        public async Task<string> GenerateWorkOrderNo()
        {
            int number = 1;
            List<string> existing = await _workOrderRepo.GetQueryable().Select(w => w.WorkOrderNo).ToListAsync();
            List<int> numbers = existing.Select(e => int.Parse(e)).ToList();

            if (numbers.Count != 0)
            {
                number = numbers.Max() + 1;
            }

            return number.ToString();
        }

    }
}