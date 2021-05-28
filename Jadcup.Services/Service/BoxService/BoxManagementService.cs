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
using Jadcup.Services.Model.BoxModel;
using Jadcup.Services.Model.CellModel;
using Jadcup.Services.Model.PlateModel;
using Jadcup.Services.Model.TempZoneModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.BoxService
{
    public class BoxManagementService : IBoxManagementService
    {
        private readonly IGenericMySqlAccessRepository<Box> _boxRepo;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<WorkOrder> _workOrderRepo;
        private readonly IGenericMySqlAccessRepository<Suborder> _suborderRepo;
        private readonly IGenericMySqlAccessRepository<Parameter> _paraRepo;
        private readonly IGenericMySqlAccessRepository<PlateBox> _plateBoxRepo;
        private readonly IGenericMySqlAccessRepository<ShelfPlate> _shelfPlateRepo;
        private readonly IGenericMySqlAccessRepository<TempZone> _tempZoneRepo;
        private readonly IGenericMySqlAccessRepository<Stock> _stockRepo;
        private readonly IGenericMySqlAccessRepository<StockLog> _stockLogRepo;
        private readonly IGenericMySqlAccessRepository<DispatchingDetails> _dispatchingDetailsRepo;

        public BoxManagementService(
            IGenericMySqlAccessRepository<Box> boxRepo,
            IMapper mapper,
            IGenericMySqlAccessRepository<WorkOrder> workOrderRepo,
            IGenericMySqlAccessRepository<Suborder> suborderRepo,
            IGenericMySqlAccessRepository<Parameter> paraRepo,
            IGenericMySqlAccessRepository<PlateBox> plateBoxRepo,
            IGenericMySqlAccessRepository<ShelfPlate> shelfPlateRepo,
            IGenericMySqlAccessRepository<TempZone> tempZoneRepo,
            IGenericMySqlAccessRepository<Stock> stockRepo,
            IGenericMySqlAccessRepository<StockLog> stockLogRepo,
            IGenericMySqlAccessRepository<DispatchingDetails> dispatchingDetailsRepo)
        {
            _mapper = mapper;
            _workOrderRepo = workOrderRepo;
            _suborderRepo = suborderRepo;
            _paraRepo = paraRepo;
            _plateBoxRepo = plateBoxRepo;
            _shelfPlateRepo = shelfPlateRepo;
            _tempZoneRepo = tempZoneRepo;
            _stockRepo = stockRepo;
            _stockLogRepo = stockLogRepo;
            _boxRepo = boxRepo;
            _dispatchingDetailsRepo = dispatchingDetailsRepo;

        }
        public async Task<TaskResponse<bool>> Delete(string id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Box box = await _boxRepo.GetQueryable().Where(b => b.Status != 0).FirstOrDefaultAsync(b => b.BoxId == id);

            if (box == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            box.Status = 0;
            _boxRepo.UpdateT(box);
            await SetPalletAvaiable(id);            
            await _boxRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<string>>> GenerateBarCode(string suborderId, int count)
        {
            TaskResponse<List<string>> response = new TaskResponse<List<string>>();

            Suborder suborder = await _suborderRepo.GetQueryable().Include(s => s.WorkOrder).FirstOrDefaultAsync(s => s.SuborderId == suborderId);
            short sequence = await GetMaxSequence(suborder.SuborderId);
            ulong semi = 0;
            if (suborder.WorkOrder.OrderTypeId == 2)
            {
                semi = 1;
            }

            using var transaction = _boxRepo.GetContext().Database.BeginTransaction();

            try
            {
                List<Box> boxes = new List<Box>();
                for (int i = 1; i <= count; i++)
                {
                    Guid id = Guid.NewGuid();
                    string barCode = await GetBarCode();
                    Box box = new Box
                    {
                        BoxId = id.ToString(),
                        BarCode = barCode,
                        SuborderId = suborder.SuborderId,
                        Status = 1,
                        CreatedAt = DateTime.UtcNow,
                        Quantity = 0,
                        Sequence = (short)(sequence + 1),
                        ProductId = suborder.WorkOrder.ProductId,
                        IsSemi = semi
                    };

                    sequence += 1;
                    _boxRepo.Insert(box);
                    boxes.Add(box);
                }

                await _boxRepo.SaveAsync();
                transaction.Commit();
                response.Data = boxes.Select(b => b.BarCode).ToList();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage(ex.ToString()));
            }

            return response;
        }

        public async Task<TaskResponse<List<GetBoxDto>>> GetAll(string suborderId, short? productId, ulong? isSemi, short? sequence, string ticketId)
        {
            TaskResponse<List<GetBoxDto>> response = new TaskResponse<List<GetBoxDto>>();

            List<Box> boxes = await _boxRepo.GetQueryable()
                .Where(b => b.Status != 0)
                .Where(b => suborderId == null || b.SuborderId == suborderId)
                .Where(b => productId == null || b.ProductId == productId)
                .Where(b => isSemi == null || b.IsSemi == isSemi)
                .Where(b => sequence == null || b.Sequence == sequence)
                .Where(b => ticketId == null || b.TicketId == ticketId)
                .Include(b => b.StatusNavigation)
                .Include(b => b.Product)
                .Include(b => b.Suborder)
                .ToListAsync();

            response.Data = boxes.Select(b => _mapper.Map<GetBoxDto>(b)).ToList();
            return response;
        }

        public async Task<TaskResponse<GetBoxDto>> GetByBarCode(string barCode)
        {
            TaskResponse<GetBoxDto> response = new TaskResponse<GetBoxDto>();

            Box box = await _boxRepo.GetQueryable()
                .Include(b => b.StatusNavigation)
                .Include(b => b.Product)
                .Include(b => b.Suborder)
                .FirstOrDefaultAsync(b => b.BarCode == barCode);

            if (box == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            response.Data = _mapper.Map<GetBoxDto>(box);
            return response;
        }

        public async Task<TaskResponse<GetBoxDto>> GetById(string id)
        {
            TaskResponse<GetBoxDto> response = new TaskResponse<GetBoxDto>();

            Box box = await _boxRepo.GetQueryable()
               .Include(b => b.StatusNavigation)
               .Include(b => b.Product)
               .Include(b => b.Suborder)
               .FirstOrDefaultAsync(b => b.BoxId == id);

            if (box == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            response.Data = _mapper.Map<GetBoxDto>(box);
            return response;
        }

        public async Task<TaskResponse<bool>> UpdateQuantity(string id, int quantity)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Box box = await _boxRepo.GetAsync(id);
            box.Quantity = quantity;

            _boxRepo.UpdateT(box);
            await _boxRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetBoxDto3>>> GetByProductId(short productId)
        {
            TaskResponse<List<GetBoxDto3>> response = new TaskResponse<List<GetBoxDto3>>();
            List<String> boxIds = await _dispatchingDetailsRepo.GetQueryable().Include(dd => dd.Box)
                    .Include( dd => dd.Dispatch)
                    .Where(dd => dd.Box.ProductId==productId && dd.Dispatch.Status ==1)
                    .Select(dd => dd.BoxId).ToListAsync();

            List<PlateBox> plateBoxes = await _plateBoxRepo.GetQueryable()
                .Include(pb => pb.Box)
                    .ThenInclude(b => b.StatusNavigation)
                .Include(pb => pb.Plate)
                    .ThenInclude(p => p.PlateType)
                .Where(pb => pb.Box.ProductId == productId && pb.Active == 1)
                .Where(pb => !boxIds.Contains(pb.BoxId))
                .ToListAsync();

            List<ShelfPlate> shelfPlates = await _shelfPlateRepo.GetQueryable()
                .Include(sp => sp.Cell)
                    .ThenInclude(c => c.Shelf)
                    .ThenInclude(s => s.Zone)
                .Include(sp => sp.Plate)
                .Where(sp => plateBoxes.Select(pb => pb.PlateId).ToList().Contains(sp.PlateId) && sp.Active == 1)
                .ToListAsync();

            List<TempZone> tempZones = await _tempZoneRepo.GetQueryable().Where(tz => plateBoxes.Select(pb => pb.PlateId).ToList().Contains(tz.PlateId) && tz.Active == 1).ToListAsync();

            List<GetBoxDto3> results = new List<GetBoxDto3>();

            foreach (PlateBox plateBox in plateBoxes)
            {
                GetBoxDto3 b = _mapper.Map<GetBoxDto3>(plateBox.Box);

                b.Plate = _mapper.Map<GetPlateDto>(plateBox.Plate);

                ShelfPlate shelfPlate = shelfPlates.FirstOrDefault(sp => sp.PlateId == plateBox.PlateId);

                if (shelfPlate != null)
                {
                    Cell cell = shelfPlate.Cell;
                    if (cell != null)
                    {
                        b.Cell = _mapper.Map<GetCellDto>(cell);
                    }
                }
                else
                {
                    b.Tempzone = _mapper.Map<GetTempZoneDto2>(tempZones.FirstOrDefault(tz => tz.PlateId == plateBox.PlateId));
                }


                results.Add(b);
            }

            response.Data = results;
            return response;
        }

        public async Task<TaskResponse<bool>> Obsolete(string id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Box box = await _boxRepo.GetAsync(id);
            if (box == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            box.Status = 0;
            _boxRepo.UpdateT(box);

            Stock stock = await _stockRepo.GetQueryable()
                .Include(s => s.Item)
                .FirstOrDefaultAsync(s => s.Item.IsSemi == box.IsSemi && s.Item.ProductId == box.ProductId);

            StockLog log = new StockLog
            {
                LogId = Guid.NewGuid().ToString(),
                StockId = stock.StockId,
                Quantity = box.Quantity,
                CreatedAt = DateTime.UtcNow,
                TransactionTypeId = 3,
                BoxId = id
            };
            _stockLogRepo.Insert(log);
            
            stock.Quantity -= box.Quantity;
            _stockRepo.UpdateT(stock);

            PlateBox pb = await _plateBoxRepo.GetQueryable().FirstOrDefaultAsync(pb => pb.BoxId == id && pb.Active == 1);
            if (pb != null)
            {
                pb.Active = 0;
                pb.UpdatedAt = DateTime.UtcNow;
                _plateBoxRepo.UpdateT(pb);
            }
            await SetPalletAvaiable(id);
            await _boxRepo.SaveAsync();
            
            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> UpdateStockQuantity(string id, int quantity)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Box box = await _boxRepo.GetAsync(id);
            
            int difference = quantity - box.Quantity;
            Stock stock = await _stockRepo.GetQueryable()
                .Include(s => s.Item)
                .FirstOrDefaultAsync(s => s.Item.ProductId == box.ProductId && s.Item.IsSemi == box.IsSemi);

            stock.Quantity += difference;
            _stockRepo.UpdateT(stock);

            StockLog log = new StockLog
            {
                LogId = Guid.NewGuid().ToString(),
                StockId = stock.StockId,
                Quantity = difference,
                CreatedAt = DateTime.UtcNow,
                TransactionTypeId = 4,
                BoxId = box.BoxId  
            };
            _stockLogRepo.Insert(log);

            box.Quantity = quantity;
            _boxRepo.UpdateT(box);

            await _boxRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        //functions
        public async Task<string> GetBarCode()
        {
            Parameter para = await _paraRepo.GetQueryable().FirstOrDefaultAsync(p => p.ParaName == "BoxBarCode");
            int thisBox = (int)(para.Value += 1);
            string barCode = (100000000000 + thisBox).ToString();

            para.Value = thisBox;
            _paraRepo.UpdateT(para);
            await _paraRepo.SaveAsync();

            return barCode;
        }

        public async Task<short> GetMaxSequence(string suborderId)
        {
            List<Box> existedBox = await _boxRepo.GetQueryable().Where(b => b.SuborderId == suborderId).ToListAsync();

            short sequence = 0;
            if (existedBox.Count != 0)
            {
                sequence = existedBox.Select(b => b.Sequence).ToList().Max();
            }

            return sequence;
        }

        public async Task GenerateSemiBox(Suborder suborder)
        {
            TaskResponse<string> response = new TaskResponse<string>();

            string barCode = await GetBarCode();

            Box box = new Box
            {
                BoxId = Guid.NewGuid().ToString(),
                BarCode = barCode,
                SuborderId = suborder.SuborderId,
                Status = 1,
                CreatedAt = DateTime.UtcNow,
                Quantity = suborder.CompletedQuanity.Value,
                Sequence = 1,
                ProductId = suborder.WorkOrder.ProductId,
                IsSemi = 1
            };

            _boxRepo.Insert(box);
        }
         
        public async Task<bool> SetPalletAvaiable(List<string> boxIds)
        {
            var plateIds =await _plateBoxRepo.GetQueryable().Where(pb => boxIds.Contains(pb.BoxId)).
                    Select(pb =>pb.PlateId).Distinct().ToArrayAsync();
            foreach(var plateId in plateIds)
            {
                var box =await _plateBoxRepo.GetQueryable().Include(pb => pb.Box)
                    .Where(pb => pb.PlateId==plateId 
                    && pb.Active==1 && pb.Box.Status!=0
                    && !boxIds.Contains(pb.BoxId)).FirstOrDefaultAsync();   
                if (box==null){
                    var shelfplate =await _shelfPlateRepo.GetQueryable().Where(sp => sp.PlateId==plateId && sp.Active==1).FirstOrDefaultAsync();
                    shelfplate.Active=0;
                    shelfplate.UpdatedAt = DateTime.UtcNow;
                    // await _shelfPlateRepo.SaveAsync();
                }                                 
            }
            return true;
        }
        public async Task<bool> SetPalletAvaiable(string boxId)
        {
            var plateBox =await _plateBoxRepo.GetQueryable().Where(pb => pb.BoxId==boxId).FirstOrDefaultAsync();
            if (plateBox==null) return false;
            var box =await _plateBoxRepo.GetQueryable().Include(pb => pb.Box)
                .Where(pb => pb.PlateId==plateBox.PlateId 
                && pb.Active==1 && pb.Box.Status!=0).FirstOrDefaultAsync();
            if (box==null){
                var shelfplate =await _shelfPlateRepo.GetQueryable().Where(sp => sp.PlateId==plateBox.PlateId && sp.Active==1).FirstOrDefaultAsync();
                shelfplate.Active=0;
                shelfplate.UpdatedAt = DateTime.UtcNow;
                // await _shelfPlateRepo.SaveAsync();
            }
            return true;
        }

    }
}