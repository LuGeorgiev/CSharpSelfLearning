
namespace LearningSystem.Services.Models
{
    using AutoMapper;
    using System.Linq;
    using Common.Mapping;
    using Data.Models;

    public class UserProfileCourseServiceModel :IMapFrom<Course>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Grade? Grade { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            string studentId = null;

            mapper
                .CreateMap<Course, UserProfileCourseServiceModel>()
                .ForMember(p => p.Grade, cfg => cfg
                      .MapFrom(c => c.Stiudents
                          .Where(s => s.StudentId == studentId)
                          .Select(s => s.Grade)
                          .FirstOrDefault()));
        }
    }
}
