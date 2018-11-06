using AutoMapper;
using EstateManagment.Data.Models;
using EstateManagment.Services.ServiceModels.Users;

namespace EstateManagment.Web.Common.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserInfoModel>();
            CreateMap<User, UserShortModel>();
        }
    }
}
