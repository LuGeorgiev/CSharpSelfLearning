using AutoMapper;
using EstateManagment.Data.Models;
using EstateManagment.Services.ServiceModels.Clients;
using EstateManagment.Services.ServiceModels.Companies;
using EstateManagment.Services.ServiceModels.Properties;
using EstateManagment.Services.ServiceModels.Rents;
using EstateManagment.Services.ServiceModels.Users;
using EstateManagment.Web.Areas.Admin.Models.Users;
using EstateManagment.Web.Models.Properties;
using System.Linq;

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
            CreateMap<Property, PropertyShortModel>();

            CreateMap<Client, ClientListingModel>();
            CreateMap<Client, ClientDetailsModel>();
            CreateMap<RentAgreement, RentListingViewModel>()
                .ForMember(c => c.Client, opt => opt.MapFrom(ra => ra.Client.Name))
                .ForMember(p => p.Properties, opt => opt.MapFrom(pr => pr.PropertyRents.Select(x => x.Property.Name)));
            CreateMap<RentAgreement, RentDetailsModel>()
                .ForMember(r => r.TotalMonthlyPrice, opt => opt.MapFrom(ra => ra.MonthlyPrice + ra.ParkingSlots.Sum(x => x.Price * x.Quantity)))
                .ForMember(r => r.Client, opt => opt.MapFrom(ra => ra.Client.Name))
                .ForMember(r=>r.Properties, opt=>opt.MapFrom(ra=>ra.PropertyRents.Select(x=>x.Property)));

            CreateMap<ParkingSlot, ParkingSlotShortModel>();
        }
    }
}
