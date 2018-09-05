
namespace LearningSystem.Services.Implementations
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using LearningSystem.Data;
    using LearningSystem.Services.Models;
    using System;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;

    public class CourseService : ICourseService
    {
        private readonly LearningSystemDbContext db;
        private readonly IMapper mapper;

        public CourseService(LearningSystemDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CourseListingServiceModel>> Active()
        {
            var courses = await this.db
                            .Courses
                            .OrderByDescending(x => x.Id)
                            .Where(c => c.StartDate >= DateTime.UtcNow)
                            .ToListAsync();

            return this.mapper.Map<IEnumerable<CourseListingServiceModel>>(courses);
        }
    }
}
