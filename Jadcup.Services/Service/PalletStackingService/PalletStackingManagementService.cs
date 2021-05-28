using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.PalletStackingService;
using Jadcup.Services.Model.PalletStackingModel;

namespace Jadcup.Services.Service.PalletStackingService
{
    public class PalletStackingManagementService : IPalletStackingManagementService
    {
        private readonly IGenericMySqlAccessRepository<PalletStacking> _palletStackingRepo;
        private readonly IMapper _mapper;

        public PalletStackingManagementService(IGenericMySqlAccessRepository<PalletStacking> palletStackingRepo, IMapper mapper)
        {
            _palletStackingRepo = palletStackingRepo;
            _mapper = mapper;
        }
        public async Task<TaskResponse<bool>> Add(AddPalletStackingDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            PalletStacking palletStacking = _mapper.Map<PalletStacking>(request);
            _palletStackingRepo.Insert(palletStacking);
            await _palletStackingRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> Delete(short id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            PalletStacking palletStacking = await _palletStackingRepo.GetAsync(id);

            _palletStackingRepo.Delete(palletStacking);
            await _palletStackingRepo.SaveAsync();
            
            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetPalletStackingDto>>> GetAll()
        {
            TaskResponse<List<GetPalletStackingDto>> response = new TaskResponse<List<GetPalletStackingDto>>();

            List<PalletStacking> palletStackings = await _palletStackingRepo.GetAllAsync();

            response.Data = palletStackings.Select(p => _mapper.Map<GetPalletStackingDto>(p)).ToList();
            return response;
        }

        public async Task<TaskResponse<GetPalletStackingDto>> GetById(short id)
        {
            TaskResponse<GetPalletStackingDto> response = new TaskResponse<GetPalletStackingDto>();

            PalletStacking palletStacking = await _palletStackingRepo.GetAsync(id);

            response.Data = _mapper.Map<GetPalletStackingDto>(palletStacking);
            return response;
        }

        public async Task<TaskResponse<bool>> Update(UpdatePalletStackingDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            PalletStacking palletStacking = await _palletStackingRepo.GetAsync(request.PalletStackingId);

            _mapper.Map(request, palletStacking);
            _palletStackingRepo.UpdateT(palletStacking);
            await _palletStackingRepo.SaveAsync();

            response.Data = true;
            return response;
        }
    }
}