using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.ShelfPlateService;
using Jadcup.Services.Model.CellModel;
using Jadcup.Services.Model.PlateModel;
using Jadcup.Services.Model.ShelfPlateModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.ShelfPlateService
{
    public class ShelfPlateManagementService : IShelfPlateManagementService
    {
        private readonly IGenericMySqlAccessRepository<ShelfPlate> _shelfPlateRepo;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<Cell> _cellRepo;
        private readonly IGenericMySqlAccessRepository<Plate> _plateRepo;
        private readonly IGenericMySqlAccessRepository<PlateBox> _plateBoxRepo;
        private readonly IGenericMySqlAccessRepository<TempZone> _tempZoneRepo;

        public ShelfPlateManagementService(
            IGenericMySqlAccessRepository<ShelfPlate> shelfPlateRepo,
            IMapper mapper,
            IGenericMySqlAccessRepository<Cell> cellRepo,
            IGenericMySqlAccessRepository<Plate> plateRepo,
            IGenericMySqlAccessRepository<PlateBox> plateBoxRepo,
            IGenericMySqlAccessRepository<TempZone> tempZoneRepo)
        {
            _cellRepo = cellRepo;
            _plateRepo = plateRepo;
            _plateBoxRepo = plateBoxRepo;
            _tempZoneRepo = tempZoneRepo;
            _mapper = mapper;
            _shelfPlateRepo = shelfPlateRepo;

        }
        public async Task<TaskResponse<int>> Add(AddShelfPlateDto request)
        {
            TaskResponse<int> response = new TaskResponse<int>();

            ShelfPlate shelfPlate = _mapper.Map<ShelfPlate>(request);
            shelfPlate.CreatedAt = DateTime.UtcNow;
            shelfPlate.Active = 1;

            _shelfPlateRepo.Insert(shelfPlate);
            await _shelfPlateRepo.SaveAsync();

            response.Data = shelfPlate.ShelfPlateId;
            return response;
        }

        public async Task<TaskResponse<bool>> Delete(int id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            ShelfPlate shelfPlate = await _shelfPlateRepo.GetAsync(id);
            if (shelfPlate == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            bool hasBox = await _plateBoxRepo.GetQueryable().AnyAsync(pb => pb.PlateId == shelfPlate.PlateId && pb.Active == 1);

            if (hasBox)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage("Cannot Remove Plate From Warehouse. Please Remove Boxes on the Plate First."));
            }

            shelfPlate.UpdatedAt = DateTime.UtcNow;
            shelfPlate.Active = 0;

            _shelfPlateRepo.UpdateT(shelfPlate);
            await _shelfPlateRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetShelfPlateDto>>> GetAll(short? cellId, short? plateId, ulong? active)
        {
            TaskResponse<List<GetShelfPlateDto>> response = new TaskResponse<List<GetShelfPlateDto>>();

            List<ShelfPlate> shelfPlates = await _shelfPlateRepo.GetQueryable()
                .Where(sp => cellId == null || sp.CellId == cellId)
                .Where(sp => plateId == null || sp.PlateId == plateId)
                .Where(sp => active == null || sp.Active == active)
                .Include(sp => sp.Cell).ThenInclude(c => c.Shelf)
                .Include(sp => sp.Plate).ThenInclude(p => p.PlateType)
                .ToListAsync();

            response.Data = shelfPlates.Select(sp => _mapper.Map<GetShelfPlateDto>(sp)).ToList();
            return response;
        }

        public async Task<TaskResponse<GetShelfPlateDto>> GetById(int id)
        {
            TaskResponse<GetShelfPlateDto> response = new TaskResponse<GetShelfPlateDto>();

            ShelfPlate shelfPlate = await _shelfPlateRepo.GetQueryable()
                .Include(sp => sp.Cell).ThenInclude(c => c.Shelf)
                .Include(sp => sp.Plate).ThenInclude(p => p.PlateType)
                .FirstOrDefaultAsync(sp => sp.ShelfPlateId == id);

            if (shelfPlate == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            response.Data = _mapper.Map<GetShelfPlateDto>(shelfPlate);
            return response;
        }

        public async Task<TaskResponse<List<GetCellDto>>> GetEmptyCell()
        {
            TaskResponse<List<GetCellDto>> response = new TaskResponse<List<GetCellDto>>();

            List<ShelfPlate> shelfPlates = await _shelfPlateRepo.GetQueryable().Where(sp => sp.Active == 1).ToListAsync();

            List<Cell> cells = await _cellRepo.GetQueryable().Where(c => !shelfPlates.Select(sp => sp.CellId).ToList().Contains(c.CellId)).Include(c => c.Shelf).ToListAsync();

            response.Data = cells.Select(c => _mapper.Map<GetCellDto>(c)).ToList();
            return response;
        }

        public async Task<TaskResponse<List<GetPlateDto>>> GetUnassignedPlate()
        {
            TaskResponse<List<GetPlateDto>> response = new TaskResponse<List<GetPlateDto>>();

            List<ShelfPlate> shelfPlates = await _shelfPlateRepo.GetQueryable().Where(sp => sp.Active == 1).ToListAsync();

            List<Plate> plates = await _plateRepo.GetQueryable().Where(p => !shelfPlates.Select(sp => sp.PlateId).ToList().Contains(p.PlateId)).Include(p => p.PlateType).ToListAsync();

            response.Data = plates.Select(p => _mapper.Map<GetPlateDto>(p)).ToList();
            return response;
        }

        public async Task<TaskResponse<int>> MovePlate(short plateId, short cellId)
        {
            TaskResponse<int> response = new TaskResponse<int>();

            ShelfPlate shelfPlate = await _shelfPlateRepo.GetQueryable().FirstOrDefaultAsync(sp => sp.Active == 1 && sp.PlateId == plateId);

            if (shelfPlate == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage("Plate not assigned to any shelf."));
            }

            shelfPlate.Active = 0;
            shelfPlate.UpdatedAt = DateTime.UtcNow;
            _shelfPlateRepo.UpdateT(shelfPlate);

            ShelfPlate added = new ShelfPlate
            {
                PlateId = plateId,
                CellId = cellId,
                Active = 1,
                CreatedAt = DateTime.UtcNow
            };

            _shelfPlateRepo.Insert(added);
            await _shelfPlateRepo.SaveAsync();

            response.Data = added.ShelfPlateId;
            return response;
        }

        public async Task<TaskResponse<bool>> Update(UpdateShelfPlateDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            ShelfPlate shelfPlate = await _shelfPlateRepo.GetAsync(request.ShelfPlateId);
            if (shelfPlate == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _mapper.Map(request, shelfPlate);
            shelfPlate.UpdatedAt = DateTime.UtcNow;

            _shelfPlateRepo.UpdateT(shelfPlate);
            await _shelfPlateRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> MoveToTempZone(short plateId, sbyte? zoneType)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            ShelfPlate shelfPlate = await _shelfPlateRepo.GetQueryable().FirstOrDefaultAsync(sp => sp.Active == 1 && sp.PlateId == plateId);
            if (shelfPlate == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            shelfPlate.UpdatedAt = DateTime.UtcNow;
            shelfPlate.Active = 0;

            _shelfPlateRepo.UpdateT(shelfPlate);

            TempZone tempZone = new TempZone
            {
                PlateId = plateId,
                Active = 1,
                CreatedAt = DateTime.UtcNow
            };

            if (zoneType == null)
            {
                tempZone.ZoneType = 1;
            }
            else
            {
                tempZone.ZoneType = zoneType;
            }

            _tempZoneRepo.Insert(tempZone);
            await _shelfPlateRepo.SaveAsync();

            response.Data = true;
            return response;
        }
    }
}