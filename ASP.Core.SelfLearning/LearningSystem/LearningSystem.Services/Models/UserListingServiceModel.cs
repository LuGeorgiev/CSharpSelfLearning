namespace LearningSystem.Services.Models
{
    using AutoMapper;
    using LearningSystem.Common.Mapping;
    using LearningSystem.Data.Models;

    public class UserListingServiceModel: IMapFrom<User>, IHaveCustomMapping
    {
        public string  Username { get; set; }

        public string Name { get; set; }

        public int Courses { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<User, UserListingServiceModel>()
                .ForMember(u => u.Courses, cfg => cfg.MapFrom(u => u.Courses.Count));
    }
}
