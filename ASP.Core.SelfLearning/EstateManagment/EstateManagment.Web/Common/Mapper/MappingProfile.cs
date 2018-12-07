using AutoMapper;
using EstateManagment.Data.Models;
using EstateManagment.Services.Areas.Payments.Models;
using EstateManagment.Services.Areas.Payments.Models.MonthlyConsumables;
using EstateManagment.Services.Areas.Payments.Models.MonthlyRents;
using EstateManagment.Services.Areas.Payments.Models.Payments;
using EstateManagment.Services.ServiceModels.Clients;
using EstateManagment.Services.ServiceModels.Companies;
using EstateManagment.Services.ServiceModels.Properties;
using EstateManagment.Services.ServiceModels.Rents;
using EstateManagment.Services.ServiceModels.Users;
using EstateManagment.Web.Areas.Admin.Models.Users;
using EstateManagment.Web.Models.Properties;
using System;
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
            CreateMap<Client, ClientViewModel>();
            CreateMap<Client, ClientDetailsModel>()
                .ForMember(c => c.RentAgreements, opt => opt.MapFrom(ra => ra.RentAgreements.Where(x => x.EndDate == null || x.EndDate > DateTime.UtcNow)));
            CreateMap<RentAgreement, RentAgreementShortModel>()
                .ForMember(ra => ra.ParkingPlacesQuantity, opt => opt.MapFrom(ps => ps.ParkingSlots.Sum(x => x.Quantity)))
                .ForMember(ra => ra.TotalPrice, opt => opt.MapFrom(ra => ra.MonthlyPrice + ra.ParkingSlots.Sum(x => x.Quantity * x.Price)))
                .ForMember(ra => ra.PropertyName, opt => opt.MapFrom(ra => ra.PropertyRents.Select(x => x.Property.Name)));

            CreateMap<RentAgreement, RentListingViewModel>()
                .ForMember(c => c.Client, opt => opt.MapFrom(ra => ra.Client.Name))
                .ForMember(p => p.Properties, opt => opt.MapFrom(pr => pr.PropertyRents.Select(x => x.Property.Name)))
                .ForMember(t=>t.TotalMonthlyPrice, opt=>opt.MapFrom(ra=>ra.MonthlyPrice+ra.ParkingSlots.Sum(x=>x.Price*x.Quantity)))
                .ForMember(p=>p.ParkingSlotQuantity, opt=>opt.MapFrom(ra=>ra.ParkingSlots.Sum(x=>x.Quantity)));
            CreateMap<RentAgreement, RentDetailsModel>()
                .ForMember(r => r.Client, opt => opt.MapFrom(ra => ra.Client.Name))
                .ForMember(r=>r.Properties, opt=>opt.MapFrom(ra=>ra.PropertyRents.Select(x=>x.Property)));
            CreateMap<ParkingSlot, ParkingSlotShortModel>();

            CreateMap<RentAgreement, CreateMonthlyRentFormViewModel>()
                .ForMember(r => r.TotalPayment, opt => opt.MapFrom(ra =>ra.MonthlyPrice + ra.ParkingSlots.Sum(x => x.Quantity * x.Price)))
                .ForMember(r=>r.Client, opt=>opt.MapFrom(ra=>ra.Client.Name))
                .ForMember(r=>r.Properties, opt=>opt.MapFrom(ra=>ra.PropertyRents.Select(x=>x.Property.Name+Area+x.Property.Area)))
                .ForMember(r=>r.ParkingSlotsQty, opt=>opt.MapFrom(ra=>ra.ParkingSlots.Sum(x=>x.Quantity)))
                .ForMember(r=>r.RentAgreementId, opt=>opt.MapFrom(ra=>ra.Id));


            CreateMap<MonthlyPaymentRent, MonthlyRentListingModel>()
                .ForMember(mr => mr.Client, opt => opt.MapFrom(mr => mr.RentAgreement.Client.Name))
                .ForMember(mr => mr.Properties, opt => opt.MapFrom(mr => mr.RentAgreement.PropertyRents.Select( x => x.Property.Name )))
                .ForMember(mr=>mr.TotalPayment, opt=>opt.MapFrom(mr=>mr.TotalPayment-mr.Payments.Sum(x=>x.Amount)))
                .ForMember(mr=>mr.ParkingSlotQuantity, opt=>opt.MapFrom(mr=>mr.RentAgreement.ParkingSlots.Sum(x=>x.Quantity)));

            CreateMap<RentAgreement, CreateMonthlyConsumablesModel>()
                .ForMember(r=>r.Client, opt=>opt.MapFrom(ra=>ra.Client.Name))
                .ForMember(r => r.Properties, opt=>opt.MapFrom(mc=>mc.PropertyRents.Select(p=>p.Property.Name + Area + p.Property.Area)));
            CreateMap<MonthlyConsumablesBindingModel, MonthlyPaymentConsumable>();
            CreateMap<MonthlyPaymentConsumable, MonthlyConsumablesListingModel>()
                .ForMember(r => r.Client, opt => opt.MapFrom(mc => mc.RentAgreement.Client.Name))
                .ForMember(mc => mc.TotalConsumablesMonthlyPrice, opt => opt.MapFrom(mc => mc.PaymentForElectricity + mc.PaymentForWater))
                .ForMember(mc => mc.Properties, opt => opt.MapFrom(mc => mc.RentAgreement.PropertyRents.Select(x => x.Property.Name)));
            CreateMap<MonthlyPaymentConsumable, MonthlyConsumablesViewModel>()
                .ForMember(mc => mc.Client, opt => opt.MapFrom(mc => mc.RentAgreement.Client.Name));

            CreateMap<MonthlyPaymentRent, MonthlyRentViewModel>();

            CreateMap<Payment, PaymentConsumablesListingModel>()
                .ForMember(p => p.Client, opt => opt.MapFrom(p => p.MonthlyPaymentConsumable.RentAgreement.Client.Name))
                .ForMember(p => p.DeadLine, opt => opt.MapFrom(p => p.MonthlyPaymentConsumable.DeadLine))
                .ForMember(p => p.PaymentForElectricity, opt => opt.MapFrom(p => p.MonthlyPaymentConsumable.PaymentForElectricity))
                .ForMember(p => p.PaymentForWater, opt => opt.MapFrom(p => p.MonthlyPaymentConsumable.PaymentForWater))
                .ForMember(p => p.RentAgreementId, opt => opt.MapFrom(p => p.MonthlyPaymentConsumable.RentAgreementId))
                .ForMember(p => p.User, opt => opt.MapFrom(p => p.User.Nickname ?? p.User.UserName));
            CreateMap<Payment, PaymentRentListingModel>()
                .ForMember(p => p.ApplyVAT, opt => opt.MapFrom(p => p.MonthlyPaymentRent.ApplyVAT))
                .ForMember(p => p.Client, opt => opt.MapFrom(p => p.MonthlyPaymentRent.RentAgreement.Client.Name))
                .ForMember(p => p.DeadLine, opt => opt.MapFrom(p => p.MonthlyPaymentRent.DeadLine))
                .ForMember(p => p.RentAgreementId, opt => opt.MapFrom(p => p.MonthlyPaymentRent.RentAgreementId))
                .ForMember(p => p.TotalPayment, opt => opt.MapFrom(p => p.MonthlyPaymentRent.TotalPayment))
                .ForMember(p => p.Username, opt => opt.MapFrom(p => p.User.Nickname ?? p.User.UserName));            

            CreateMap<MonthlyPaymentRent, OverdueMontlyRentsListingModel>()
                .ForMember(mp => mp.MonthsOverdue, opt => opt.MapFrom(mp => DateTime.UtcNow.Month - mp.DeadLine.Month))
                .ForMember(mp => mp.ParkingSlotsQty, opt => opt.MapFrom(mp => mp.RentAgreement.ParkingSlots.Sum(x => x.Quantity)))
                .ForMember(mp=>mp.PropertyRentsNames, opt=>opt.MapFrom(mp=>mp.RentAgreement.PropertyRents.Select(x=>x.Property.Name+"/"+x.Property.Area)))
                .ForMember(mp=>mp.ClientName, opt=>opt.MapFrom(mp=>mp.RentAgreement.Client.Name));

            CreateMap<MonthlyPaymentConsumable, OverdueMonthlyConsumablesListingModel>()
                .ForMember(mp => mp.PropertyRentsNames, opt => opt.MapFrom(mp => mp.RentAgreement.PropertyRents.Select(x => x.Property.Name + "/" + x.Property.Area)))
                .ForMember(mp => mp.ClientName, opt => opt.MapFrom(mp => mp.RentAgreement.Client.Name));



        }
    }
}
