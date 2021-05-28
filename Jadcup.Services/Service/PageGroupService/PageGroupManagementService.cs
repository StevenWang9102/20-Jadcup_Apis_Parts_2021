using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.PageGroupService;
using Jadcup.Services.Model.PageGroupModel;
using Jadcup.Services.Model.PageModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.PageGroupService
{
    public class PageGroupManagementService : IPageGroupManagementService
    {
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<PageGroup> _pageGroupRepo;
        private readonly ICrud<PageGroup, GetPageGroupDto, UpdatePageGroupDto> _crud;
        private readonly IGenericMySqlAccessRepository<Page> _pageRepo;

        public PageGroupManagementService(
            IMapper mapper,
            IGenericMySqlAccessRepository<PageGroup> pageGroupRepo,
            ICrud<PageGroup, GetPageGroupDto, UpdatePageGroupDto> crud,
            IGenericMySqlAccessRepository<Page> pageRepo)
            
        {
            _pageGroupRepo = pageGroupRepo;
            _crud = crud;
            _pageRepo = pageRepo;
            _mapper = mapper;

        }
        public async Task<TaskResponse<bool>> Add(AddPageGroupDto request)
        {
            PageGroup pg = await _pageGroupRepo.GetQueryable().FirstOrDefaultAsync(pg => pg.GroupName == request.GroupName);
            return await _crud.AddToTableAsync(pg, request);
        }

        public async Task<TaskResponse<bool>> Delete(short id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }

        public async Task<TaskResponse<List<GetPageGroupDto>>> GetAll()
        {
            TaskResponse<List<GetPageGroupDto>> response = new TaskResponse<List<GetPageGroupDto>>();

            List<PageGroup> pgs = await _pageGroupRepo.GetQueryable()
                .OrderBy(p => p.SortingOrder)
                .Include(p => p.Page)
                .ToListAsync();
            
            foreach(PageGroup pg in pgs)
            {
                pg.Page = await _pageRepo.GetQueryable().Where(p => p.GroupId == pg.GroupId).OrderBy(p => p.SortingOrder).ToListAsync();
            }

            response.Data = (pgs.Select(pg => _mapper.Map<GetPageGroupDto>(pg))).ToList();
            return response;
        }

        public async Task<TaskResponse<GetPageGroupDto>> GetById(short id)
        {
            TaskResponse<GetPageGroupDto> response = new TaskResponse<GetPageGroupDto>();
            PageGroup pg = await _pageGroupRepo.GetAsync(id);

            pg.Page = await _pageRepo.GetQueryable().Where(p => p.GroupId == pg.GroupId).OrderBy(p => p.SortingOrder).ToListAsync();

            response.Data = _mapper.Map<GetPageGroupDto>(pg);
            return response;
        }

        public async Task<TaskResponse<GetPageGroupDto>> Update(UpdatePageGroupDto request)
        {
            PageGroup pg = await _pageGroupRepo.GetAsync(request.GroupId);
            bool duplicated = await _pageGroupRepo.GetQueryable().AnyAsync(p => p.GroupName == request.GroupName && pg.GroupName != request.GroupName);

            return await _crud.UpdateEntry(pg, request, duplicated);
        }

        public async Task<TaskResponse<List<PageGroupPageDto>>> GetPageByGroupId(short id)
        {
            TaskResponse<List<PageGroupPageDto>> response = new TaskResponse<List<PageGroupPageDto>>();

            List<Page> pages = await _pageRepo.GetQueryable().Where(p => p.GroupId == id).OrderBy(p => p.SortingOrder).ToListAsync();

            response.Data = (pages.Select(p => _mapper.Map<PageGroupPageDto>(p))).ToList();
            return response;
        }

    }
}