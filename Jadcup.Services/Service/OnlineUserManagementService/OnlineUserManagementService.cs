using System;
using System.Collections.Generic;
using System.Text;
using Jadcup.Services.Interface.OnlineUserService;
using Jadcup.Common.Model;
using Jadcup.Services.Model.OnlineUserModel;
using System.Threading.Tasks;
using Jadcup.Common.Repository;
using Jadcup.Common.Context;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Jadcup.Common.Error;
using Jadcup.Common.Helper;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace Jadcup.Services.Service.OnlineUserManagementService
{
    public class OnlineUserManagementService : IOlineUserManagementService
    {
        private readonly IGenericMySqlAccessRepository<OnlineUser> _onlineUserRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public OnlineUserManagementService(IMapper mapper,
            IGenericMySqlAccessRepository<OnlineUser> onlineUserRepo,
            IConfiguration configuration)
        {
            _mapper = mapper;
            _onlineUserRepo = onlineUserRepo;
            _configuration = configuration;
        }

        public async Task<TaskResponse<int>> Add(AddOnlineUserDto request)
        {
            OnlineUser dbOnlineUser = await GetOnlineUserByUserName(request.UserName);
            if (dbOnlineUser != null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.UserNameTaken());
            }

            
            OnlineUser newOnlineUser = _mapper.Map<OnlineUser>(request);
            GeneralMethods.HashPassword(request.Password, out string passwordHash, out string passwordSalt);
            DateTime newOnlineUserCreatedTime = GeneralMethods.createTime();

            newOnlineUser.Password = passwordHash;
            newOnlineUser.Salt = passwordSalt;
            newOnlineUser.Active = 1;
            newOnlineUser.CreatedAt = newOnlineUserCreatedTime;

            _onlineUserRepo.Insert(newOnlineUser);
            await _onlineUserRepo.SaveAsync();
            
            /*
            using var transaction = _onlineUserRepo.GetContext().Database.BeginTransaction();
            try
            {
                OnlineUser newOnlineUser = _mapper.Map<OnlineUser>(request);
                GeneralMethods.HashPassword(request.Password, out string passwordHash, out string passwordSalt);
                DateTime newOnlineUserCreatedTime = GeneralMethods.createTime();

                newOnlineUser.Password = passwordHash;
                newOnlineUser.Salt = passwordSalt;
                newOnlineUser.Active = 1;
                newOnlineUser.CreatedAt = newOnlineUserCreatedTime;

                _onlineUserRepo.Insert(newOnlineUser);
                await _onlineUserRepo.SaveAsync();
                Console.WriteLine("Try");
                transaction.Commit();
            }
            catch(Exception e)
            {
                transaction.Rollback();
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage(e.ToString()));
            }
            finally
            {
                Console.WriteLine("Finally");
                transaction.Dispose();
            }
            */

            OnlineUser dbNewOnlineUser = await GetOnlineUserByUserName(request.UserName);
            int dbNewOnlineUserId = dbNewOnlineUser.UserId;
            TaskResponse<int> response = new TaskResponse<int>();
            response.Data = dbNewOnlineUserId;
            return response;
        }

        public async Task<OnlineUser> GetOnlineUserByUserName(string userName)
        {
            OnlineUser dbNewOnlineUser = await _onlineUserRepo.GetQueryable().
                SingleOrDefaultAsync(ou => ou.UserName.ToLower() == userName.ToLower());
            return dbNewOnlineUser;
        }

        public async Task<TaskResponse<bool>> UpdatePassword(UpdateOnlineUserDto request)
        {
            OnlineUser dbOnlineUser = await _onlineUserRepo.GetQueryable()
                .SingleOrDefaultAsync(ou => ou.UserName.ToLower() == request.UserName.ToLower());
            if (dbOnlineUser == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.UserNameNotFound());
            }

            bool validOnlineUser = VerifyOnlineUser(dbOnlineUser, request);
            if (!validOnlineUser)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, SystemMessage.IncorrectPassword());
            }
            GeneralMethods.HashPassword(request.NewPassword, out string passwordHash, out string passwordSalt);

            dbOnlineUser.Password = passwordHash;
            dbOnlineUser.Salt = passwordSalt;

            _onlineUserRepo.UpdateT(dbOnlineUser);
            await _onlineUserRepo.SaveAsync();
            TaskResponse<bool> response = new TaskResponse<bool>();
            response.Data = true;
            return response;
        }

        private bool VerifyOnlineUser(OnlineUser dbOnlineUser, UpdateOnlineUserDto request)
        {
            string inputPassword = request.Password;
            string dbPassword = dbOnlineUser.Password;
            string dbSalt = dbOnlineUser.Salt;
            return GeneralMethods.VerifyPasswordHash(inputPassword, dbPassword, dbSalt);
        }

        // Method overloading
        private bool VerifyOnlineUser(OnlineUser dbOnlineUser, OnlineUserLoginDto request)
        {
            string inputPassword = request.Password;
            string dbPassword = dbOnlineUser.Password;
            string dbSalt = dbOnlineUser.Salt;
            return GeneralMethods.VerifyPasswordHash(inputPassword, dbPassword, dbSalt);
        }

        public  async Task<TaskResponse<OnlineUserLoginResultDto>> Login(OnlineUserLoginDto request)
        {
            OnlineUser dbOnlineUser = await _onlineUserRepo.GetQueryable()
                .SingleOrDefaultAsync(ou => ou.UserName.ToLower() == request.UserName.ToLower());
            if (dbOnlineUser == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.UserNameNotFound());
            }

            bool validOnlineUser = VerifyOnlineUser(dbOnlineUser, request);
            if (!validOnlineUser)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, SystemMessage.IncorrectPassword());
            }

            var token = GenerateJwt(dbOnlineUser.UserId);
            OnlineUserLoginResultDto result = new OnlineUserLoginResultDto
            {
                UserId = dbOnlineUser.UserId,
                UserName = dbOnlineUser.UserName,
                CustomerId = dbOnlineUser.CustomerId,
                Token = token
            };

            TaskResponse<OnlineUserLoginResultDto> response = new TaskResponse<OnlineUserLoginResultDto>();
            response.Data = result;
            return response;
        }

        private string GenerateJwt(int id)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("ApplicationSettings:JWT_Secret").Value)),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandle = new JwtSecurityTokenHandler();
            var securityToken = tokenHandle.CreateToken(tokenDescriptor);
            var tokenToClient = tokenHandle.WriteToken(securityToken);
            return tokenToClient;
        }

        public async Task<TaskResponse<bool>> CheckPassword(OnlineUserLoginDto request)
        {
            OnlineUser dbOnlineUser = await _onlineUserRepo.GetQueryable()
                .SingleOrDefaultAsync(ou => ou.UserName.ToLower() == request.UserName.ToLower());
            if (dbOnlineUser == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.UserNameNotFound());
            }

            bool validOnlineUser = VerifyOnlineUser(dbOnlineUser, request);
            if (!validOnlineUser)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, SystemMessage.IncorrectPassword());
            }

            TaskResponse<bool> response = new TaskResponse<bool>();
            response.Data = true;
            return response;
        }
    }
}
