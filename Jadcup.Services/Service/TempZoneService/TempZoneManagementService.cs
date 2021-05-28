using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.TempZoneService;
using Jadcup.Services.Model.BoxModel;
using Jadcup.Services.Model.RawMaterialBoxModel;
using Jadcup.Services.Model.StockLogModel;
using Jadcup.Services.Model.TempZoneModel;
using Jadcup.Services.Model.ZoneTypeModel;
using Jadcup.Services.Model.ShelfPlateModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.TempZoneService
{
    public class TempZoneManagementService : ITempZoneManagementService
    {
        private readonly IGenericMySqlAccessRepository<TempZone> _tempZoneRepo;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<Stock> _stockRepo;
        private readonly IGenericMySqlAccessRepository<Box> _boxRepo;
        private readonly IGenericMySqlAccessRepository<Item> _itemRepo;
        private readonly IGenericMySqlAccessRepository<StockLog> _stockLogRepo;
        private readonly IGenericMySqlAccessRepository<PlateBox> _plateBoxRepo;
        private readonly IGenericMySqlAccessRepository<ShelfPlate> _shelfPlateRepo;
        private readonly IGenericMySqlAccessRepository<Plate> _plateRepo;
        private readonly IGenericMySqlAccessRepository<ZoneType> _zoneTypeRepo;

        public TempZoneManagementService(IGenericMySqlAccessRepository<TempZone> tempZoneRepo,
            IMapper mapper,
            IGenericMySqlAccessRepository<Stock> stockRepo,
            IGenericMySqlAccessRepository<Box> boxRepo,
            IGenericMySqlAccessRepository<Item> itemRepo,
            IGenericMySqlAccessRepository<StockLog> stockLogRepo,
            IGenericMySqlAccessRepository<PlateBox> plateBoxRepo,
            IGenericMySqlAccessRepository<ShelfPlate> shelfPlateRepo,
            IGenericMySqlAccessRepository<Plate> plateRepo,
            IGenericMySqlAccessRepository<ZoneType> zoneTypeRepo
            )
        {
            _boxRepo = boxRepo;
            _itemRepo = itemRepo;
            _stockLogRepo = stockLogRepo;
            _plateBoxRepo = plateBoxRepo;
            _shelfPlateRepo = shelfPlateRepo;
            _plateRepo = plateRepo;
            _stockRepo = stockRepo;
            _tempZoneRepo = tempZoneRepo;
            _zoneTypeRepo = zoneTypeRepo;
            _mapper = mapper;
        }
        public async Task<TaskResponse<bool>> Add(List<AddStockLogDto> request, short plateId)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            TempZone tempZone = new TempZone
            {
                PlateId = plateId,
                Active = 1,
                CreatedAt = DateTime.UtcNow,
                ZoneType = 1
            };

            bool exist = await _tempZoneRepo.GetQueryable().AnyAsync(t => t.Active == 1 && t.PlateId == plateId);

            if (exist)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage("Plate Already in TempZone. Please Check Again Or Clear Empty Plate From TempZone."));
            }

            _tempZoneRepo.Insert(tempZone);

            foreach (AddStockLogDto re in request)
            {
                Box box = await _boxRepo.GetAsync(re.BoxId);
                Item item = await _itemRepo.GetQueryable().FirstOrDefaultAsync(i => i.ProductId == box.ProductId && i.IsSemi == box.IsSemi);
                Stock stock = await _stockRepo.GetQueryable().FirstOrDefaultAsync(s => s.ItemId == item.ItemId);

                stock.Quantity += re.Quantity;
                _stockRepo.UpdateT(stock);

                StockLog stockLog = _mapper.Map<StockLog>(re);
                stockLog.StockId = stock.StockId;
                stockLog.CreatedAt = DateTime.UtcNow;
                stockLog.TransactionTypeId = 1;
                stockLog.LogId = Guid.NewGuid().ToString();

                _stockLogRepo.Insert(stockLog);

                Plate plate = await _plateRepo.GetAsync(plateId);
                plate.Package = 0;
                _plateRepo.UpdateT(plate);
            }
            await _stockLogRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> Delete(short plateId)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            TempZone tempZone = await _tempZoneRepo.GetQueryable().FirstOrDefaultAsync(t => t.PlateId == plateId && t.Active == 1 && t.ZoneType == 1);
            if (tempZone == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            tempZone.UpdatedAt = DateTime.UtcNow;
            tempZone.Active = 0;

            _tempZoneRepo.UpdateT(tempZone);
            await _tempZoneRepo.SaveAsync();

            response.Data = true;
            return response;
        }
        public async Task<TaskResponse<List<GetZoneTypeDto>>> GetZoneType()
        {
            TaskResponse<List<GetZoneTypeDto>> response = new TaskResponse<List<GetZoneTypeDto>>();
            List<ZoneType> zoneTypes = await _zoneTypeRepo.GetQueryable().ToListAsync();
            response.Data = zoneTypes.Select(z => _mapper.Map<GetZoneTypeDto>(z)).ToList();
            foreach( var ele in response.Data){
                ele.ZoneType=ele.ZoneType1;
            }
            return response;
        }
        public async Task<TaskResponse<List<GetTempZoneDto>>> GetAll(short? plateId, ulong? active, sbyte? zoneType)
        {
            TaskResponse<List<GetTempZoneDto>> response = new TaskResponse<List<GetTempZoneDto>>();

            List<GetTempZoneDto> result = new List<GetTempZoneDto>();

            List<TempZone> tempZones = await _tempZoneRepo.GetQueryable()
                .Where(t => plateId == null || t.PlateId == plateId)
                .Where(t => active == null || t.Active == active)
                .Where(t => zoneType == null || t.ZoneType == zoneType)
                .Include(t => t.ZoneTypeNavigation)
                .Include(t => t.Plate)
                    .ThenInclude(p => p.PlateType)
                .ToListAsync();

            foreach (TempZone tz in tempZones)
            {
                List<PlateBox> plateBoxes = await _plateBoxRepo.GetQueryable()
                    .Where(pb => pb.PlateId == tz.PlateId && pb.Active == 1)
                    .Include(pb => pb.Box)
                        .ThenInclude(b => b.Product)
                    .Include(pb => pb.Box)
                        .ThenInclude(b => b.Suborder)
                    .Include(pb => pb.Box)
                        .ThenInclude(b => b.StatusNavigation)
                    .Include(pb => pb.RawMaterialBox)
                        .ThenInclude(rmb => rmb.RawMaterial)
                    .ToListAsync();

                GetTempZoneDto dto = _mapper.Map<GetTempZoneDto>(tz);
                dto.Boxes = new List<GetBoxDto>();
                dto.RawMaterialBoxes = new List<GetRawMaterialBoxDto>();

                foreach (PlateBox plateBox in plateBoxes)
                {
                    if (plateBox.Box != null)
                    {
                        GetBoxDto boxdto = _mapper.Map<GetBoxDto>(plateBox.Box);
                        dto.Boxes.Add(boxdto);
                    }
                    if (plateBox.RawMaterialBox != null)
                    {
                        GetRawMaterialBoxDto rmbdto = _mapper.Map<GetRawMaterialBoxDto>(plateBox.RawMaterialBox);
                        dto.RawMaterialBoxes.Add(rmbdto);
                    }
                }
                result.Add(dto);
            }

            response.Data = result;
            return response;
        }

        public async Task<TaskResponse<bool>> MovePlateToShelf(short plateId, short cellId)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            TempZone tempZone = await _tempZoneRepo.GetQueryable().FirstOrDefaultAsync(tz => tz.Active == 1 && tz.PlateId == plateId);

            if (tempZone == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, new SystemMessage("Plate not in temporary zone."));
            }

            tempZone.Active = 0;
            tempZone.UpdatedAt = DateTime.UtcNow;

            _tempZoneRepo.UpdateT(tempZone);

            ShelfPlate shelfPlate = new ShelfPlate
            {
                PlateId = plateId,
                CellId = cellId,
                CreatedAt = DateTime.UtcNow,
                Active = 1
            };

            _shelfPlateRepo.Insert(shelfPlate);
            await _tempZoneRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> Clear()
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            List<TempZone> tempZones = await _tempZoneRepo.GetQueryable().Where(tz => tz.Active == 1 && tz.ZoneType == 1).Include(tz => tz.Plate).ToListAsync();

            foreach (TempZone tempZone in tempZones)
            {
                bool notEmpty = await _plateBoxRepo.GetQueryable().AnyAsync(pb => pb.Active == 1 && pb.PlateId == tempZone.PlateId);

                if (!notEmpty)
                {
                    tempZone.Active = 0;
                    tempZone.UpdatedAt = DateTime.UtcNow;
                    _tempZoneRepo.UpdateT(tempZone);

                    if (tempZone.Plate.PlateTypeId == 2)
                    {
                        tempZone.Plate.Active = 0;
                        _plateRepo.UpdateT(tempZone.Plate);
                    }
                }
            }

            await _tempZoneRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> MovePlateToTempZone(short plateId,sbyte zoneTypeId)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            TempZone tempZone = await _tempZoneRepo.GetQueryable().FirstOrDefaultAsync(tz => tz.PlateId == plateId && tz.Active == 1 && tz.ZoneType == zoneTypeId);
            if (tempZone != null)
            {
                // throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
                tempZone.Active = 0;
                tempZone.UpdatedAt = DateTime.UtcNow;
                _tempZoneRepo.UpdateT(tempZone);
            }


            ShelfPlate shelfPlate = await  _shelfPlateRepo.GetQueryable().FirstOrDefaultAsync(tz => tz.PlateId == plateId && tz.Active == 1);

            if (shelfPlate != null)
            {
                // throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
                shelfPlate.Active = 0;
                shelfPlate.UpdatedAt = DateTime.UtcNow;
                _shelfPlateRepo.UpdateT(shelfPlate);

            }

            TempZone tempZone2 = new TempZone
            {
                PlateId = plateId,
                Active = 1,
                CreatedAt = DateTime.UtcNow,
                ZoneType = zoneTypeId
            };

            _tempZoneRepo.Insert(tempZone2);

            await _tempZoneRepo.SaveAsync();

            response.Data = true;
            return response;
        }
        public async Task<TaskResponse<bool>> MovePlateFromZone2ToZone1(short plateId)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            TempZone tempZone = await _tempZoneRepo.GetQueryable().FirstOrDefaultAsync(tz => tz.PlateId == plateId && tz.Active == 1 && tz.ZoneType == 2);
            if (tempZone == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            tempZone.Active = 0;
            tempZone.UpdatedAt = DateTime.UtcNow;
            _tempZoneRepo.UpdateT(tempZone);

            TempZone tempZone2 = new TempZone
            {
                PlateId = plateId,
                Active = 1,
                CreatedAt = DateTime.UtcNow,
                ZoneType = 1
            };

            _tempZoneRepo.Insert(tempZone2);

            await _tempZoneRepo.SaveAsync();

            response.Data = true;
            return response;
        }
    }
}
