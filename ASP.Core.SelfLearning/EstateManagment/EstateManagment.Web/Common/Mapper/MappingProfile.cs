using AutoMapper;
using EstateManagment.Data.Models;
using EstateManagment.Services.Areas.Payments.Models.MonthlyConsumables;
using EstateManagment.Services.Areas.Payments.Models.MonthlyRents;
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
        private readonly string Area = " с площ: ";

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

            CreateMap<RentAgreement, CreateMonthlyRentFormViewModel>()
                .ForMember(r => r.TotalPayment, opt => opt.MapFrom(ra =>ra.MonthlyPrice + ra.ParkingSlots.Sum(x => x.Quantity * x.Price)))
                .ForMember(r=>r.Client, opt=>opt.MapFrom(ra=>ra.Client.Name))
                .ForMember(r=>r.Properties, opt=>opt.MapFrom(ra=>ra.PropertyRents.Select(x=>x.Property.Name+Area+x.Property.Area)))
                .ForMember(r=>r.ParkingSlotsQty, opt=>opt.MapFrom(ra=>ra.ParkingSlots.Sum(x=>x.Quantity)))
                .ForMember(r=>r.RentAgreementId, opt=>opt.MapFrom(ra=>ra.Id));

            CreateMap<ParkingSlot, ParkingSlotShortModel>();

            CreateMap<MonthlyPaymentRent, MonthlyRentListingModel>()
                .ForMember(mr => mr.Client, opt => opt.MapFrom(mr => mr.RentAgreement.Client.Name))
                .ForMember(mr => mr.Properties, opt => opt.MapFrom(mr => mr.RentAgreement.PropertyRents.Select( x => x.Property.Name )))
                .ForMember(mr=>mr.TotalPayment, opt=>opt.MapFrom(mr=>mr.TotalPayment-mr.Payments.Sum(x=>x.Amount)));

            CreateMap<RentAgreement, CreateMonthlyConsumablesModel>()
                .ForMember(r=>r.Client, opt=>opt.MapFrom(ra=>ra.Client.Name))
                .ForMember(r => r.Properties, opt=>opt.MapFrom(mc=>mc.PropertyRents.Select(p=>p.Property.Name + Area + p.Property.Area)));
            CreateMap<MonthlyConsumablesBindingModel, MonthlyPaymentConsumable>();
            CreateMap<MonthlyPaymentConsumable, MonthlyConsumablesListingModel>()
                .ForMember(r => r.Client, opt => opt.MapFrom(mc => mc.RentAgreement.Client.Name))
                .ForMember(mc => mc.TotalConsumablesMonthlyPrice, opt => opt.MapFrom(mc => mc.PaymentForElectricity + mc.PaymentForWater))
                .ForMember(mc => mc.Properties, opt => opt.MapFrom(mc => mc.RentAgreement.PropertyRents.Select(x => x.Property.Name)));

            CreateMap<MonthlyPaymentRent, MonthlyRentViewModel>();
        }
    }
}
