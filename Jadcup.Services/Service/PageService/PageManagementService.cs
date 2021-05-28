using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.IPageService;
using Jadcup.Services.Model.PageModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.PageService
{
    public class PageManagementService : IPageManagementService
    {
        private readonly IGenericMySqlAccessRepository<Page> _pageRepo;
        private readonly IMapper _mapper;
        public PageManagementService(IGenericMySqlAccessRepository<Page> pageRepo, IMapper mapper)
        {
            _mapper = mapper;
            _pageRepo = pageRepo;

        }
        public async Task<TaskResponse<int>> Add(AddPageDto request)
        {
            TaskResponse<int> response = new TaskResponse<int>();
            Page page = _mapper.Map<Page>(request);

            _pageRepo.Insert(page);
            await _pageRepo.SaveAsync();

            response.Data = page.PageId;
            return response;
        }

        public async Task<TaskResponse<bool>> Delete(short id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();
            Page page = await _pageRepo.GetAsync(id);
            if (page == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }
            _pageRepo.Delete(page);
            await _pageRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetPageDto>>> GetAll()
        {
            TaskResponse<List<GetPageDto>> response = new TaskResponse<List<GetPageDto>>();

            List<Page> pages = await _pageRepo.GetQueryable().Include(p => p.Group).OrderBy(p => p.SortingOrder).ToListAsync();

            response.Data = (pages.Select(p => _mapper.Map<GetPageDto>(p))).ToList();

            return response;
        }

        public async Task<TaskResponse<List<GetPageDto>>> GetByGroup(short id)
        {
            TaskResponse<List<GetPageDto>> response = new TaskResponse<List<GetPageDto>>();

            List<Page> pages = await _pageRepo.GetQueryable().Where(p => p.GroupId == id).OrderBy(p => p.SortingOrder).ToListAsync();

            response.Data = (pages.Select(p => _mapper.Map<GetPageDto>(p))).ToList();

            return response;
        }

        public async Task<TaskResponse<GetPageDto>> GetById(short id)
        {
            TaskResponse<GetPageDto> response = new TaskResponse<GetPageDto>();
            Page page = await _pageRepo.GetQueryable().Include(p => p.Group).FirstOrDefaultAsync(p => p.PageId == id);

            if (page == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }
            response.Data = _mapper.Map<GetPageDto>(page);
            return response;
        }

        public async Task<TaskResponse<int>> Update(UpdatePageDto request)
        {
            TaskResponse<int> response = new TaskResponse<int>();
            Page page = await _pageRepo.GetAsync(request.PageId);

            if (page == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _mapper.Map(request, page);
            _pageRepo.UpdateT(page);
            await _pageRepo.SaveAsync();

            response.Data = page.PageId;
            return response;
        }
    }
}
