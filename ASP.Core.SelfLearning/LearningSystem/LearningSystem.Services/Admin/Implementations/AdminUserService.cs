
namespace LearningSystem.Services.Admin.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using LearningSystem.Data;
    using Microsoft.EntityFrameworkCore;
    using Services.Admin.Models;

    public class AdminUserService : IAdminUserService
    {

        private readonly LearningSystemDbContext db;
        private readonly IMapper mapper;

        public AdminUserService(LearningSystemDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AdminUserListingServiceModel>> AllAsync()
        {
            var users = await this.db
              .Users
              .ToListAsync();

            return mapper.Map<IEnumerable<AdminUserListingServiceModel>>(users);
        }
    }
}
