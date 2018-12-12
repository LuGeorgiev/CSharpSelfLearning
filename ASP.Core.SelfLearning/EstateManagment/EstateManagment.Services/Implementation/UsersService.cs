using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Services.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EstateManagment.Services.Implementation
{
    public class UsersService : BaseService,IUsersService
    {       
        private readonly UserManager<User> userManager;

        public UsersService(IMapper mapper, EstateManagmentContext db, UserManager<User> userManager)
        :base(mapper,db)
        {            
            this.userManager = userManager;
        }


        public async Task<IEnumerable<UserShortModel>> AllNonAdminsAsync(string loggedUserId)
        {
            var usersOfRole = await userManager
                .GetUsersInRoleAsync("Administrator");

            var nonAdminUsers = await this.Db.Users
                .Where(x => x.Id != loggedUserId && !usersOfRole.Any(z=>z.Id==x.Id))
                .ToListAsync();

            var model = this.Mapper.Map<IEnumerable<UserShortModel>>(nonAdminUsers);
            return model;
        }

        public async Task<User> GetUserAsync(string userId)
            => await this.Db.Users.FirstOrDefaultAsync(x=>x.Id==userId);

        public async Task<UserInfoModel> GetUserWithRolesAsync(string userId)
        {           

            var user = await this.Db.Users
                .FirstOrDefaultAsync(x => x.Id == userId);
            if (user==null)
            {
                return null;
            }
            var roles = await this.userManager.GetRolesAsync(user);
            var model = this.Mapper.Map<UserInfoModel>(user);
            model.Roles = roles;

            return model;
        }
    }
}
