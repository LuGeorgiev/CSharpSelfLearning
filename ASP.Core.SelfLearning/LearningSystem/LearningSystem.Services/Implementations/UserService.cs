namespace LearningSystem.Services.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using LearningSystem.Data;
    using LearningSystem.Services.Models;
    using Microsoft.EntityFrameworkCore;

    public class UserService : IUserService
    {
        private readonly LearningSystemDbContext db;
        private readonly IMapper mapper;

        public UserService(LearningSystemDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<UserProfileServiceModel> ProfileAsync(string id)
        {
            var student = await this.db
                .Users
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

            var mappedModel = mapper.Map<UserProfileServiceModel>(student);
            return mappedModel;
        }
    }
}
