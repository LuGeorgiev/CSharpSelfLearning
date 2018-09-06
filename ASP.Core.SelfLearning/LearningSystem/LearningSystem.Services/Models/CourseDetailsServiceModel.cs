namespace LearningSystem.Services.Models
{
    using Common.Mapping;
    using Data.Models;
    using AutoMapper;
    using System;

    public class CourseDetailsServiceModel : IMapFrom<Course>, IHaveCustomMapping
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Trainer { get; set; }

        public int Stiudents { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Course, CourseDetailsServiceModel>()
                .ForMember(c => c.Trainer, cfg => cfg.MapFrom(c => c.Trainer.UserName))
                .ForMember(c => c.Stiudents, cfg => cfg.MapFrom(c => c.Stiudents.Count));
        
    }
}
