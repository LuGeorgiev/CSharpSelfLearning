using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Services.ServiceModels.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EstateManagment.Services.Implementation
{
    public class UsersService : IUsersService
    {
        private readonly IMapper mapper;
        private readonly EsteteManagmentContext db;
        private readonly UserManager<User> userManager;

        public UsersService(IMapper mapper, EsteteManagmentContext db, UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.db = db;
            this.userManager = userManager;
        }


        public async Task<IEnumerable<UserShortModel>> AllNonAdminsAsync(string loggedUserId)
        {
            var usersOfRole = await userManager
                .GetUsersInRoleAsync("Administrator");

            var nonAdminUsers = await this.db.Users
                .Where(x => x.Id != loggedUserId && !usersOfRole.Any(z=>z.Id==x.Id))
                .ToListAsync();

            var model = mapper.Map<IEnumerable<UserShortModel>>(nonAdminUsers);
            return model;
        }

        public async Task<UserInfoModel> GetUserAsync(string userId)
        {
            var user = await this.db.Users
                .FirstOrDefaultAsync(x => x.Id == userId);
            if (user==null)
            {
                return null;
            }
            var roles = await this.userManager.GetRolesAsync(user);
            var model = this.mapper.Map<UserInfoModel>(user);
            model.Roles = roles;

            throw new NotImplementedException();
        }
    }
}
