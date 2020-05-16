using AutoMapper;
using KnowledgeTestingService.Authentication.DataTransferObjects;
using KnowledgeTestingService.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeTestingService.Authentication.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public AccountService(UserManager<User> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<Result<UserDto>> GetUserById(string userId)
        {
            if (userId is null)
            {
                return Result.Fail<UserDto>(-1);
            }
            var user = await userManager.FindByIdAsync(userId);
            if (user is null)
            {
                return Result.Fail<UserDto>(-1);
            }

            return Result.Ok(mapper.Map<UserDto>(user));
        }

        public async Task<IEnumerable<UserDto>> GetAll(int offset, int count)
        {
            var users = userManager.Users.Skip(offset).Take(count);
            var admins = await userManager.GetUsersInRoleAsync("admin");

            var userDtos = mapper.Map<IEnumerable<UserDto>>(users);

            userDtos.Join(admins, ud => ud.Id, a => a.Id, (ud, a) => ud)
                .ToList()
                .ForEach(ud => ud.IsAdmin = true);

            return userDtos;
        }

        public async Task<long> GetUsersCount()
        {
            return await userManager.Users.LongCountAsync();
        }

        public async Task<IEnumerable<IdentityError>> SetAdmin(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var result = await userManager.AddToRoleAsync(user, "admin");

            if (!result.Succeeded)
            {
                return result.Errors;
            }

            return new List<IdentityError>();
        }

        public async Task<IEnumerable<IdentityError>> RemoveAdmin(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var result = await userManager.RemoveFromRoleAsync(user, "admin");

            if (!result.Succeeded)
            {
                return result.Errors;
            }
            return new List<IdentityError>();
        }

        public async Task<IEnumerable<IdentityError>> BanUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            var result = await userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);
            if (!result.Succeeded)
            {
                return result.Errors;
            }
            return new List<IdentityError>();
        }

        public async Task<IEnumerable<IdentityError>> UnbanUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            var result = await userManager.SetLockoutEndDateAsync(user, null);
            if (!result.Succeeded)
            {
                return result.Errors;
            }
            return new List<IdentityError>();
        }
    }
}