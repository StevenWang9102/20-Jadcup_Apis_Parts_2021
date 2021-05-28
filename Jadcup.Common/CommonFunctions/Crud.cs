using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;

namespace Jadcup.Common.CommonFunctions
{
    public class Crud<T, U, V> : ICrud<T, U, V> where T : class
    {
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<T> _repo;
        public Crud(IMapper mapper, IGenericMySqlAccessRepository<T> genericMySqlAccessRepository)
        {
            _repo = genericMySqlAccessRepository;
            _mapper = mapper;
        }

        public async Task<TaskResponse<bool>> AddToTableAsync(T t, object dto)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();
            if (t == null)
            {
                T addedEntity = _mapper.Map<T>(dto);
                _repo.Insert(addedEntity);
                await _repo.SaveAsync();

                response.Data = true;
            }
            else
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, SystemMessage.DuplicateError());
            }

            return response;
        }

        public async Task<TaskResponse<bool>> DeleteFromTableAsync(object id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();
            T t = await _repo.GetAsync(id);
            if (t == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }
            _repo.Delete(t);
            await _repo.SaveAsync();

            response.Data = true;
            return response;
        }


        public async Task<TaskResponse<List<U>>> GetAll()
        {
            TaskResponse<List<U>> response = new TaskResponse<List<U>>();
            List<T> t = await _repo.GetAllAsync();

            response.Data = (t.Select(e => _mapper.Map<U>(e))).ToList();
            return response;
        }

        public async Task<TaskResponse<U>> GetById(object id)
        {
            TaskResponse<U> response = new TaskResponse<U>();
            T t = await _repo.GetAsync(id);
            if (t == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            response.Data = _mapper.Map<U>(t);
            return response;
        }

        public async Task<TaskResponse<U>> UpdateEntry(T t, V v, bool duplicated)
        {
            TaskResponse<U> response = new TaskResponse<U>();

            if (t == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }
            if(duplicated)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, SystemMessage.DuplicateError());
            }

            _mapper.Map(v, t);
            
            _repo.UpdateT(t);
            await _repo.SaveAsync();
            
            response.Data = _mapper.Map<U>(t);
            return response;
        }
    }
}