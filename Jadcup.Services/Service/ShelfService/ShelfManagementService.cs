using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.ShelfService;
using Jadcup.Services.Model.BoxModel;
using Jadcup.Services.Model.CellModel;
using Jadcup.Services.Model.PlateModel;
using Jadcup.Services.Model.RawMaterialBoxModel;
using Jadcup.Services.Model.ShelfModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.ShelfService
{
    public class ShelfManagementService : IShelfManagementService
    {
        private readonly IGenericMySqlAccessRepository<Shelf> _shelfRepo;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<Cell> _cellRepo;
        private readonly IGenericMySqlAccessRepository<ShelfPlate> _shelfPlateRepo;
        private readonly IGenericMySqlAccessRepository<PlateBox> _plateBoxRepo;

        public ShelfManagementService(
            IGenericMySqlAccessRepository<Shelf> shelfRepo,
            IMapper mapper,
            IGenericMySqlAccessRepository<Cell> cellRepo,
            IGenericMySqlAccessRepository<ShelfPlate> shelfPlateRepo,
            IGenericMySqlAccessRepository<PlateBox> plateBoxRepo)
        {
            _cellRepo = cellRepo;
            _shelfPlateRepo = shelfPlateRepo;
            _plateBoxRepo = plateBoxRepo;
            _mapper = mapper;
            _shelfRepo = shelfRepo;

        }
        public async Task<TaskResponse<short>> Add(AddShelfDto request)
        {
            TaskResponse<short> response = new TaskResponse<short>();

            Shelf dbShelf = await _shelfRepo.GetQueryable().FirstOrDefaultAsync(s => request.ShelfCode == s.ShelfCode);
            if (dbShelf != null)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, SystemMessage.DuplicateError());
            }

            Shelf shelf = _mapper.Map<Shelf>(request);
            shelf.Active = 1;
            
            var cols = request.TotalCols;
            var rows = request.TotalRows;
            
            var cells = new List<Cell>();
            
            for (var i = 1; i < rows+1; i++)
            {
                for (var j = 1; j < cols+1; j++)
                {
                    cells.Add(new Cell
                    {
                        ShelfId = 12,
                        RowNo = (short) i,
                        ColNo = (short) j,
                        Active = 1
                    });
                    shelf.Cell = cells;
                }
            }

            _shelfRepo.Insert(shelf);
            await _shelfRepo.SaveAsync();
            

            response.Data = shelf.ShelfId;
            return response;
        }

        public async Task<TaskResponse<bool>> Delete(short id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Shelf shelf = await _shelfRepo.GetAsync(id);
            if (shelf == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            shelf.Active = 0;

            _shelfRepo.UpdateT(shelf);
            await _shelfRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetShelfDto>>> GetAll()
        {
            TaskResponse<List<GetShelfDto>> response = new TaskResponse<List<GetShelfDto>>();

            List<Shelf> shelves = await _shelfRepo.GetQueryable().Where(s => s.Active == 1).Include(s => s.Zone).ToListAsync();

            response.Data = shelves.Select(s => _mapper.Map<GetShelfDto>(s)).ToList();
            return response;
        }

        public async Task<TaskResponse<GetShelfDto2>> GetSingle(short? shelfId, string code)
        {
            TaskResponse<GetShelfDto2> response = new TaskResponse<GetShelfDto2>();

            Shelf shelf = await _shelfRepo.GetQueryable()
                .Where(s => shelfId == null || s.ShelfId == shelfId)
                .Where(s => code == null || s.ShelfCode == code)
                .FirstOrDefaultAsync(s => s.Active == 1);

            if (shelf == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            List<ShelfPlate> shelfPlates = await _shelfPlateRepo.GetQueryable()
                .Where(sp => sp.Active == 1)
                .Include(sp => sp.Cell)
                    .ThenInclude(c => c.Shelf)
                .Include(sp => sp.Plate)
                    .ThenInclude(p => p.PlateType)
                .Where(sp => sp.Cell.ShelfId == shelf.ShelfId)
                .ToListAsync();

            List<PlateBox> plateBoxes = await _plateBoxRepo.GetQueryable()
                .Where(pb => pb.Active == 1)
                .Include(pb => pb.Box)
                    .ThenInclude(b => b.Product)
                .Include(pb => pb.RawMaterialBox)
                    .ThenInclude(rmb => rmb.RawMaterial)
                .Where(pb => shelfPlates.Select(sp => sp.PlateId).ToList().Contains(pb.PlateId))
                .ToListAsync();

            GetShelfDto2 shelfdto = _mapper.Map<GetShelfDto2>(shelf);


            shelfdto.Cell = shelfPlates.Select(sp => sp.Cell).Where(c => c.ShelfId == shelfdto.ShelfId).ToList().Select(c => _mapper.Map<GetCellDto2>(c)).ToList();

            foreach (GetCellDto2 celldto in shelfdto.Cell)
            {
                celldto.Plate = _mapper.Map<GetPlateDto2>(shelfPlates.FirstOrDefault(sp => sp.CellId == celldto.CellId).Plate);
                celldto.Plate.Box = plateBoxes.Where(pb => pb.PlateId == celldto.Plate.PlateId && pb.BoxId != null).Select(pb => _mapper.Map<GetBoxDto2>(pb.Box)).ToList();
                celldto.Plate.RawMaterialBox = plateBoxes.Where(pb => pb.PlateId == celldto.Plate.PlateId && pb.RawMaterialBoxId != null).Select(pb => _mapper.Map<GetRawMaterialBoxDto>(pb.RawMaterialBox)).ToList();
            }


            response.Data = shelfdto;
            return response;
        }

        public async Task<TaskResponse<bool>> Update(UpdateShelfDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Shelf shelf = await _shelfRepo.GetAsync(request.ShelfId);
            if (shelf == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            Shelf dbShelf = await _shelfRepo.GetQueryable().FirstOrDefaultAsync(s => s.ShelfCode == request.ShelfCode && s.ShelfId != request.ShelfId);
            if (dbShelf != null)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage("Shelf code duplicated"));
            }

            _mapper.Map(request, shelf);
            _shelfRepo.UpdateT(shelf);
            await _shelfRepo.SaveAsync();

            response.Data = true;
            return response;
        }
    }
}