using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SuborderService;
using Jadcup.Services.Interface.WorkOrderService;
using Jadcup.Services.Model.SuborderModel;
using Jadcup.Services.Model.WorkOrderModel;
using Jadcup.Services.Model.ActionModel;

using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.WorkOrderService
{
    public class WorkOrderManagementService : IWorkOrderManagementService
    {
        private readonly IGenericMySqlAccessRepository<WorkOrder> _workOrderRepo;
        private readonly IMapper _mapper;
        private readonly ISuborderManagementService _suborderManagementService;
        private readonly IGenericMySqlAccessRepository<Product> _productRepo;
        private readonly IGenericMySqlAccessRepository<ProductTypeAction> _productTypeActionRepo;
        private readonly IGenericMySqlAccessRepository<ProductMachineMapping> _productMachineMappingRepo;
        private readonly IGenericMySqlAccessRepository<Suborder> _suborderRepo;

        public WorkOrderManagementService(IGenericMySqlAccessRepository<WorkOrder> workOrderRepo,
            IMapper mapper,
            ISuborderManagementService suborderManagementService,
            IGenericMySqlAccessRepository<Product> productRepo,
            IGenericMySqlAccessRepository<ProductTypeAction> productTypeActionRepo,
            IGenericMySqlAccessRepository<ProductMachineMapping> productMachineMappingRepo,
            IGenericMySqlAccessRepository<Suborder> suborderRepo)
        {
            _productRepo = productRepo;
            _productTypeActionRepo = productTypeActionRepo;
            _productMachineMappingRepo = productMachineMappingRepo;
            _suborderRepo = suborderRepo;
            _suborderManagementService = suborderManagementService;
            _mapper = mapper;
            _workOrderRepo = workOrderRepo;

        }
        public async Task<TaskResponse<bool>> Add(AddWorkOrderDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            using var transaction = _workOrderRepo.GetContext().Database.BeginTransaction();
            try
            {
                await AddWorkOrderAndSuborder(request);
                response.Data = true;
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage(ex.ToString()));
            }
            return response;
        }

        public async Task<TaskResponse<bool>> Approve(string id, int employeeId, string approvedComment)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();
            WorkOrder workOrder = await _workOrderRepo.GetAsync(id);

            using var transaction = _workOrderRepo.GetContext().Database.BeginTransaction();
            try
            {
                workOrder.ApprovedEmployeeId = employeeId;
                workOrder.ApprovedComments = approvedComment;
                workOrder.WorkOrderStatusId = 1;
                _workOrderRepo.UpdateT(workOrder);
                await _workOrderRepo.SaveAsync();

                await GenerateSuborder(workOrder);

                response.Data = true;
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage(ex.ToString()));
            }
            return response;
        }

        public async Task<TaskResponse<bool>> Delete(string id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            WorkOrder workOrder = await _workOrderRepo.GetAsync(id);
            if (workOrder.WorkOrderStatusId == 10)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage("Work order cannot be deleted. Product already finished."));
            }

            if (workOrder.WorkOrderStatusId >= 2)
            {
                List<Suborder> suborders = await _suborderRepo.GetQueryable().Where(s => s.WorkOrderId == workOrder.WorkOrderId).ToListAsync();
                foreach (Suborder s in suborders)
                {
                    s.SuborderStatusId = 0;
                    _suborderRepo.UpdateT(s);
                }
            }

            workOrder.WorkOrderStatusId = 0;
            _workOrderRepo.UpdateT(workOrder);
            await _workOrderRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetWorkOrderDto>>> GetAll(sbyte? statusId, DateTime? start, DateTime? end, bool? orderByRequiredDate)
        {
            TaskResponse<List<GetWorkOrderDto>> response = new TaskResponse<List<GetWorkOrderDto>>();

            List<WorkOrder> workOrders = await _workOrderRepo.GetQueryable()
                .Where(w => statusId == null || w.WorkOrderStatusId == statusId)
                .Where(w => start == null || w.CreatedAt >= start)
                .Where(w => end == null || w.CreatedAt <= end)
                .Include(w => w.CreatedEmployee)
                .Include(w => w.OrderProduct)
                .Include(w => w.OrderType)
                .Include(w => w.Product)
                .Include(w => w.WorkOrderSource)
                .Include(w => w.WorkOrderStatus)
                .Include(w => w.Suborder)
                .ThenInclude(sb => sb.Action)
                .OrderBy(w => w.RequiredDate)
                .ToListAsync();
                
            if (orderByRequiredDate == null)
            {
                workOrders = workOrders.OrderByDescending(w => w.Urgent).ThenByDescending(w => w.CreatedAt).ToList();
            }
            else
            {
                workOrders = workOrders.OrderByDescending(w => w.Urgent).ThenBy(w => w.RequiredDate).ToList();
            }

            response.Data = workOrders.Select(w => _mapper.Map<GetWorkOrderDto>(w)).ToList();

            foreach( var resWorkOrder in response.Data){
                var workOrder = workOrders.FirstOrDefault(wo => wo.WorkOrderId == resWorkOrder.WorkOrderId);
                var subOrder = workOrder.Suborder.Where(sb => sb.SuborderStatusId==1)
                        .OrderByDescending(sb => sb.SequenceNo).FirstOrDefault();

                if (subOrder !=null ){
                    resWorkOrder.ActionDto =  _mapper.Map<GetActionDto>(subOrder.Action);
                    // resWorkOrder.ActionDto.ActionId = subOrder.Action.ActionId;
                    // resWorkOrder.ActionDto.ActionName = subOrder.Action.ActionName;                        

                }

            }
            return response;
        }

        public async Task<TaskResponse<GetWorkOrderDto>> GetById(string id)
        {
            TaskResponse<GetWorkOrderDto> response = new TaskResponse<GetWorkOrderDto>();

            WorkOrder workOrder = await _workOrderRepo.GetQueryable()
                .Include(w => w.CreatedEmployee)
                .Include(w => w.OrderProduct)
                .Include(w => w.OrderType)
                .Include(w => w.Product)
                .Include(w => w.WorkOrderSource)
                .Include(w => w.WorkOrderStatus)
                .FirstOrDefaultAsync(w => w.WorkOrderId == id);

            response.Data = _mapper.Map<GetWorkOrderDto>(workOrder);
            return response;
        }

        public async Task<TaskResponse<bool>> UpdateQuantity(string id, int quantity)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            WorkOrder workOrder = await _workOrderRepo.GetAsync(id);

            if (workOrder.WorkOrderStatusId >= 2)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage("Work order in production. Quantity cannot be updated."));
            }

            if (workOrder.WorkOrderStatusId == 1)
            {
                List<Suborder> suborders = await _suborderRepo.GetQueryable().Where(s => s.WorkOrderId == id).OrderBy(s => s.SequenceNo).ToListAsync();
                foreach (Suborder s in suborders)
                {
                    if (suborders.IndexOf(s) == 0)
                    {
                        s.ReceivedQuantity = quantity;
                    }
                    s.OrginalQuantity = quantity;
                    _suborderRepo.UpdateT(s);
                }
            }

            workOrder.Quantity = quantity;
            _workOrderRepo.UpdateT(workOrder);
            await _workOrderRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> Urgent(string id, bool urgent)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            WorkOrder workOrder = await _workOrderRepo.GetAsync(id);

            if (urgent)
            {
                workOrder.Urgent = 1;
            }
            else
            {
                workOrder.Urgent = 0;
            }

            _workOrderRepo.UpdateT(workOrder);
            await _workOrderRepo.SaveAsync();

            response.Data = true;
            return response;
        }


        //function
        public async Task AddWorkOrderAndSuborder(AddWorkOrderDto request)
        {
            Guid id = Guid.NewGuid();

            WorkOrder workOrder = _mapper.Map<WorkOrder>(request);
            workOrder.CreatedAt = DateTime.UtcNow;
            workOrder.WorkOrderId = id.ToString();
            workOrder.WorkOrderNo = await GenerateWorkOrderNo();

            _workOrderRepo.Insert(workOrder);
            await _workOrderRepo.SaveAsync();

            await GenerateSuborder(workOrder);

        }

        public async Task GenerateSuborder(WorkOrder workOrder)
        {
            Product product = await _productRepo.GetQueryable()
                .Include(p => p.BaseProduct)
                .FirstOrDefaultAsync(p => workOrder.ProductId == p.ProductId);

            List<ProductTypeAction> productTypeActions = await _productTypeActionRepo.GetQueryable()
                .Where(pta => pta.ProductTypeId == product.BaseProduct.ProductTypeId && pta.OrderTypeId == workOrder.OrderTypeId)
                .OrderBy(pta => pta.SequenceNo)
                .ToListAsync();

            for (int i = 0; i < productTypeActions.Count; i++)
            {
                AddSuborderDto suborderRequest = new AddSuborderDto();
                if (i == 0)
                {
                    suborderRequest.WorkOrderId = workOrder.WorkOrderId;
                    suborderRequest.SuborderStatusId = 1;
                    suborderRequest.ReceivedQuantity = workOrder.Quantity;
                    suborderRequest.Comments = workOrder.ApprovedComments;
                    suborderRequest.ActionId = productTypeActions[i].ActionId;
                    suborderRequest.SequenceNo = productTypeActions[i].SequenceNo;
                    suborderRequest.OrginalQuantity = workOrder.Quantity;
                }
                else
                {

                    suborderRequest.WorkOrderId = workOrder.WorkOrderId;
                    suborderRequest.SuborderStatusId = 4;
                    suborderRequest.ReceivedQuantity = null;
                    suborderRequest.Comments = workOrder.ApprovedComments;
                    suborderRequest.ActionId = productTypeActions[i].ActionId;
                    suborderRequest.SequenceNo = productTypeActions[i].SequenceNo;
                    suborderRequest.OrginalQuantity = workOrder.Quantity;

                }

                _suborderManagementService.Add(suborderRequest);
                await _workOrderRepo.SaveAsync();
            }
        }

        public async Task<string> GenerateWorkOrderNo()
        {
            List<int> numbers = (await _workOrderRepo.GetQueryable().Select(q => q.WorkOrderNo).ToListAsync()).Select(n => int.Parse(n)).ToList();
            if (numbers.Count == 0)
            {
                return 1.ToString();
            }
            int max = numbers.Max();
            string number = (max + 1).ToString();

            return number;
        }
    }
}