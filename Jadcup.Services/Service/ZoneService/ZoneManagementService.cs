using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Model.ZoneModel;
using Microsoft.EntityFrameworkCore;

using System.Linq;

using Jadcup.Common.Error;
using Jadcup.Services.Interface.ZoneService;
using Jadcup.Services.Model.ShelfModel;
using Jadcup.Services.Model.CellModel;
using Jadcup.Services.Model.PlateModel;
using Jadcup.Services.Model.BoxModel;
using Jadcup.Services.Model.RawMaterialBoxModel;

namespace Jadcup.Services.Service.ZoneService
{
    public class ZoneManagementService : IZoneManagementService
    {
        private readonly IGenericMySqlAccessRepository<Zone> _zoneRepo;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<PlateBox> _plateBoxRepo;
        private readonly IGenericMySqlAccessRepository<ShelfPlate> _shelfPlateRepo;
        private readonly IGenericMySqlAccessRepository<Shelf> _shelfRepo;
        private readonly IGenericMySqlAccessRepository<Cell> _cellRepo;

        public ZoneManagementService(
            IGenericMySqlAccessRepository<Zone> zoneRepo,
            IMapper mapper,
            IGenericMySqlAccessRepository<PlateBox> plateBoxRepo,
            IGenericMySqlAccessRepository<ShelfPlate> shelfPlateRepo,
            IGenericMySqlAccessRepository<Shelf> shelfRepo,
            IGenericMySqlAccessRepository<Cell> cellRepo)
        {
            _zoneRepo = zoneRepo;
            _mapper = mapper;
            _plateBoxRepo = plateBoxRepo;
            _shelfPlateRepo = shelfPlateRepo;
            _shelfRepo = shelfRepo;
            _cellRepo = cellRepo;
        }
        public async Task<TaskResponse<List<GetZoneDto2>>> GetAll()
        {
            TaskResponse<List<GetZoneDto2>> response = new TaskResponse<List<GetZoneDto2>>();
            List<GetZoneDto2> results = new List<GetZoneDto2>();

            List<Zone> zones = await _zoneRepo.GetQueryable().Where(z => z.Active == 1).ToListAsync();
            List<Shelf> shelves = await _shelfRepo.GetQueryable().Where(s => s.Active == 1).ToListAsync();
            List<Cell> cells = await _cellRepo.GetQueryable().Where(c => c.Active == 1).ToListAsync();
            List<PlateBox> plateBoxes = await _plateBoxRepo.GetQueryable()
                .Where(pb => pb.Active == 1)
                .Include(pb => pb.Box)
                    .ThenInclude(b => b.Product)
                .Include(pb => pb.RawMaterialBox)
                    .ThenInclude(rmb => rmb.RawMaterial)
                .ToListAsync();

            List<ShelfPlate> shelfPlates = await _shelfPlateRepo.GetQueryable()
                .Where(sp => sp.Active == 1)
                .Include(sp => sp.Cell)
                    .ThenInclude(c => c.Shelf)
                .Include(sp => sp.Plate)
                    .ThenInclude(p => p.PlateType)
                .ToListAsync();

            foreach (Zone zone in zones)
            {
                GetZoneDto2 result = _mapper.Map<GetZoneDto2>(zone);
                result.Shelf = shelves.Where(s => s.ZoneId == zone.ZoneId).ToList().Select(s => _mapper.Map<GetShelfDto2>(s)).ToList();

                foreach (GetShelfDto2 shelfdto in result.Shelf)
                {
                    shelfdto.Cell = cells.Where(c => c.ShelfId == shelfdto.ShelfId).ToList().Select(c => _mapper.Map<GetCellDto2>(c)).ToList();

                    var usedCellCnt = shelfPlates.Where( sp =>sp.Cell.ShelfId == shelfdto.ShelfId && sp.Active==1).Distinct().Count();
                    var totalCellCnt = cells.Where(c => c.ShelfId == shelfdto.ShelfId).Count();
                    shelfdto.availableCellCount =(short ) (totalCellCnt - usedCellCnt);
                    foreach (GetCellDto2 celldto in shelfdto.Cell)
                    {
                        if (shelfPlates.FirstOrDefault(sp => sp.CellId == celldto.CellId) != null)
                        {
                            celldto.Plate = _mapper.Map<GetPlateDto2>(shelfPlates.FirstOrDefault(sp => sp.CellId == celldto.CellId).Plate);
                            celldto.Plate.Box = plateBoxes.Where(pb => pb.PlateId == celldto.Plate.PlateId && pb.BoxId != null).Select(pb => _mapper.Map<GetBoxDto2>(pb.Box)).ToList();
                            celldto.Plate.RawMaterialBox = plateBoxes.Where(pb => pb.PlateId == celldto.Plate.PlateId && pb.RawMaterialBoxId != null).Select(pb => _mapper.Map<GetRawMaterialBoxDto>(pb.RawMaterialBox)).ToList();
                        }
                    }
                }

                results.Add(result);
            }

            response.Data = results;
            return response;
        }

        public async Task<TaskResponse<GetZoneDto2>> GetById(sbyte id)
        {
            TaskResponse<GetZoneDto2> response = new TaskResponse<GetZoneDto2>();
            Zone dbZone = await _zoneRepo.GetQueryable().FirstOrDefaultAsync(z => z.ZoneId == id);
            if (dbZone == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            return response;
        }

        public async Task<TaskResponse<bool>> Update(UpdateZoneDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();
            Zone dbZone = await _zoneRepo.GetQueryable().FirstOrDefaultAsync(z => z.ZoneId == request.ZoneId);
            if (dbZone == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            bool duplicated = await _zoneRepo.GetQueryable().AnyAsync(z => z.ZoneCode == request.ZoneCode);
            if (duplicated && dbZone.ZoneCode.ToUpper() != request.ZoneCode.ToUpper())
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, SystemMessage.DuplicateError());
            }

            _mapper.Map(request, dbZone);
            _zoneRepo.UpdateT(dbZone);
            await _zoneRepo.SaveAsync();
            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> Add(AddZoneDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();
            Zone dbZone = await _zoneRepo.GetQueryable().FirstOrDefaultAsync(z => z.ZoneCode == request.ZoneCode);
            if (dbZone != null)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, SystemMessage.DuplicateError());
            }
            Zone newZone = _mapper.Map<Zone>(request);
            newZone.Active = 1;
            _zoneRepo.Insert(newZone);
            await _zoneRepo.SaveAsync();
            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> Delete(sbyte id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();
            Zone dbZone = await _zoneRepo.GetQueryable().FirstOrDefaultAsync(z => z.ZoneId == id);
            if (dbZone == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            dbZone.Active = 0;

            _zoneRepo.UpdateT(dbZone);
            await _zoneRepo.SaveAsync();
            response.Data = true;
            return response;
        }
    }
}
