using AutoMapper;
using EstateManagment.Data.Models;
using EstateManagment.Services.ServiceModels.Clients;
using EstateManagment.Services.ServiceModels.Companies;
using EstateManagment.Services.ServiceModels.Properties;
using EstateManagment.Services.ServiceModels.Rents;
using EstateManagment.Services.ServiceModels.Users;
using EstateManagment.Web.Areas.Admin.Models.Users;
using EstateManagment.Web.Models.Properties;

namespace EstateManagment.Web.Common.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserInfoModel>();
            CreateMap<User, UserShortModel>();
            CreateMap<UserInfoModel, RemoveRolesUserViewModel>();
            CreateMap<CompanyDetailsModel, CreatePropertyViewModel>();
            CreateMap<Property, PropertyDetailsModel>();
            CreateMap<Client, ClientListingModel>();
            CreateMap<Client, ClientDetailsModel>();
            //CreateMap<RentAgreement,RentListingViewModel>().ForMember(c=>c.Client, opt=>opt.MapFrom(ra=>ra.ClientRents.Client))
        }
    }
}
