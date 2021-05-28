using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.CellService;
using Jadcup.Services.Model.CellModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.CellService
{
    public class CellManagementService : ICellManagementService
    {
        private readonly IGenericMySqlAccessRepository<Cell> _cellRepo;
        private readonly IMapper _mapper;
        public CellManagementService(IGenericMySqlAccessRepository<Cell> cellRepo, IMapper mapper)
        {
            _mapper = mapper;
            _cellRepo = cellRepo;

        }
        public async Task<TaskResponse<short>> Add(AddCellDto request)
        {
            TaskResponse<short> response = new TaskResponse<short>();

            Cell cell = _mapper.Map<Cell>(request);

            Cell dbCell = await _cellRepo.GetQueryable().FirstOrDefaultAsync(c => c.ShelfId == request.ShelfId && c.RowNo == request.RowNo && c.ColNo == request.ColNo);
            if (dbCell != null)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, SystemMessage.DuplicateError());
            }

            cell.Active = 1;

            _cellRepo.Insert(cell);
            await _cellRepo.SaveAsync();

            response.Data = cell.CellId;
            return response;
        }

        public async Task<TaskResponse<bool>> Delete(short id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Cell cell = await _cellRepo.GetAsync(id);
            if (cell == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            cell.Active = 0;

            _cellRepo.UpdateT(cell);
            await _cellRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetCellDto>>> GetAll(short? shelfId, short? rowNo, short? colNo)
        {
            TaskResponse<List<GetCellDto>> response = new TaskResponse<List<GetCellDto>>();

            List<Cell> cells = await _cellRepo.GetQueryable()
                .Where(c => shelfId == null || c.ShelfId == shelfId)
                .Where(c => rowNo == null || c.RowNo == rowNo)
                .Where(c => colNo == null || c.ColNo == colNo)
                .Where(c => c.Active == 1)
                .Include(c => c.Shelf)
                .ToListAsync();

            response.Data = cells.Select(c => _mapper.Map<GetCellDto>(c)).ToList();
            return response;
        }

        public async Task<TaskResponse<GetCellDto>> GetById(short id)
        {
            TaskResponse<GetCellDto> response = new TaskResponse<GetCellDto>();

            Cell cell = await _cellRepo.GetQueryable().Include(c => c.Shelf).FirstOrDefaultAsync(c => c.CellId == id);
            if (cell == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            response.Data = _mapper.Map<GetCellDto>(cell);
            return response;
        }

        public async Task<TaskResponse<bool>> Update(UpdateCellDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Cell cell = await _cellRepo.GetAsync(request.CellId);
            if (cell == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            Cell dbCell = await _cellRepo.GetQueryable().FirstOrDefaultAsync(c => c.ShelfId == request.ShelfId && c.RowNo == request.RowNo && c.ColNo == request.ColNo);
            if (dbCell != null)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, SystemMessage.DuplicateError());
            }

            _mapper.Map(request, cell);
            _cellRepo.UpdateT(cell);
            await _cellRepo.SaveAsync();

            response.Data = true;
            return response;
        }
    }
}