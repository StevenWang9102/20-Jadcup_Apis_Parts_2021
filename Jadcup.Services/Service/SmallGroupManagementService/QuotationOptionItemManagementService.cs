using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.QuotationOptionItemModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class QuotationOptionItemManagementService : IQuotationOptionItemManagementService
    {
        private readonly ICrud<QuotationOptionItem, GetQuotationOptionItemDto, UpdateQuotationOptionItemDto> _crud;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<QuotationOptionItem> _quotationOptionItemRepo;

        public QuotationOptionItemManagementService(ICrud<QuotationOptionItem, GetQuotationOptionItemDto, UpdateQuotationOptionItemDto> crud, IMapper mapper, IGenericMySqlAccessRepository<QuotationOptionItem> genericMySqlAccessRepository)
        {
            _crud = crud;
            _mapper = mapper;
            _quotationOptionItemRepo = genericMySqlAccessRepository;
        }
        public async Task<TaskResponse<bool>> Add(AddQuotationOptionItemDto request)
        {
            QuotationOptionItem dbQuotationOptionItem = await _quotationOptionItemRepo.GetQueryable().FirstOrDefaultAsync(s => s.QuotationOptionItemName == request.QuotationOptionItemName);
            return await _crud.AddToTableAsync(dbQuotationOptionItem, request);
        }

        public async Task<TaskResponse<bool>> Delete(int id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }

        public async Task<TaskResponse<List<GetQuotationOptionItemDto>>> GetAll()
        {
            return await _crud.GetAll();
        }

        public async Task<TaskResponse<GetQuotationOptionItemDto>> GetById(int id)
        {
            return await _crud.GetById(id);
        }

        public async Task<TaskResponse<GetQuotationOptionItemDto>> Update(UpdateQuotationOptionItemDto request)
        {
            QuotationOptionItem dbQuotationOptionItem = await _quotationOptionItemRepo.GetAsync(request.QuotationOptionItemId);
            bool duplicated = (await _quotationOptionItemRepo.GetQueryable().AnyAsync(b => b.QuotationOptionItemName == request.QuotationOptionItemName)) && dbQuotationOptionItem.QuotationOptionItemName.ToUpper() != request.QuotationOptionItemName.ToUpper();

            return await _crud.UpdateEntry(dbQuotationOptionItem, request, duplicated);
        }
    }
}