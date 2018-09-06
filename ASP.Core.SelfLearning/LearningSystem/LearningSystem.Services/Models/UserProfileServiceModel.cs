
namespace LearningSystem.Services.Models
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class UserProfileServiceModel:IMapFrom<User>, IHaveCustomMapping
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public IEnumerable<UserProfileCourseServiceModel> Courses { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<User,UserProfileServiceModel>()
                .ForMember(u=>u.Courses, cfg=>cfg.MapFrom(s=>s.Courses.Select(c=>c.Course)));
        }
    }
}
