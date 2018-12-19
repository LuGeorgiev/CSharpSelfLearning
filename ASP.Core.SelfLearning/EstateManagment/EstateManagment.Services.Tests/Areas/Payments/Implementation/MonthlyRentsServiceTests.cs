using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Services.Areas.Payments.Implementation;
using EstateManagment.Services.Models.Areas.Payments.MonthlyRents;
using EstateManagment.Web.Common.Mapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EstateManagment.Services.Tests.Areas.Payments.Implementation
{
    public class MonthlyRentsServiceTests
    {
        [Fact]
        public async Task AllNotPaidAsync_ShouldReturn_AllRentsThatAreNotPaid_IfSuchExist()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstRent = new MonthlyPaymentRent { Id = 1, DeadLine = new DateTime(2018, 12, 12), IsPaid=false };
            var secndRent = new MonthlyPaymentRent { Id = 2, DeadLine = new DateTime(2017, 11, 6), IsPaid=false };
            var thirdRent = new MonthlyPaymentRent { Id = 3, DeadLine = new DateTime(2016, 11, 12), IsPaid=true };
            var forthRent = new MonthlyPaymentRent { Id = 4, DeadLine = new DateTime(2015, 12, 15), IsPaid=false };
            await db.MonthlyPaymentRents.AddRangeAsync(firstRent, secndRent, thirdRent, forthRent);
            await db.SaveChangesAsync();
            var rentPaymentService = new MonthlyRentsService(mapper, db);
            //Act
            var result = await rentPaymentService.AllNotPaidAsync();
            //Assert
            result
                .Should()
                .BeOfType<List<MonthlyRentListingModel>>()
                .And
                .HaveCount(3)
                .And
                .Match(x => x.ElementAt(0).Id == 4
                    && x.ElementAt(1).Id == 2
                    && x.ElementAt(2).DeadLine== new DateTime(2018, 12, 12));
        }

        [Fact]
        public async Task AllNotPaidAsync_ShouldReturn_AllPaidRents_IfArgumentIsTrue()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstRent = new MonthlyPaymentRent { Id = 1, DeadLine = new DateTime(2018, 12, 12), IsPaid = false };
            var secndRent = new MonthlyPaymentRent { Id = 2, DeadLine = new DateTime(2017, 11, 6), IsPaid = false };
            var thirdRent = new MonthlyPaymentRent { Id = 3, DeadLine = new DateTime(2016, 11, 12), IsPaid = true };
            var forthRent = new MonthlyPaymentRent { Id = 4, DeadLine = new DateTime(2015, 12, 15), IsPaid = false };
            await db.MonthlyPaymentRents.AddRangeAsync(firstRent, secndRent, thirdRent, forthRent);
            await db.SaveChangesAsync();
            var rentPaymentService = new MonthlyRentsService(mapper, db);
            //Act
            var result = await rentPaymentService.AllNotPaidAsync(true);
            //Assert
            result
                .Should()
                .BeOfType<List<MonthlyRentListingModel>>()
                .And
                .HaveCount(1)
                .And
                .Match(x => x.ElementAt(0).Id == 3);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturn_True_IfRentagreementExist()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstRent = new RentAgreement { Id = 1 };
            var secndRent = new RentAgreement { Id = 2 };
            
            await db.RentAgreements.AddRangeAsync(firstRent, secndRent);
            await db.SaveChangesAsync();
            var rentPaymentService = new MonthlyRentsService(mapper, db);
            //Act
            var result = await rentPaymentService.CreateAsync(1, 1234, new DateTime(2018,12,12));
            var createdRentPayment = await db.MonthlyPaymentRents
                .FirstOrDefaultAsync(x => x.TotalPayment == 1234*1.20m && x.DeadLine == new DateTime(2018, 12, 12));
            //Assert
            result
                .Should()
                .BeTrue();
            createdRentPayment
                .Should()
                .NotBeNull();
        }

        [Fact]
        public async Task CreateAsync_ShouldReturn_False_IfRentagreementDoNotExist()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstRent = new RentAgreement { Id = 1 };
            var secndRent = new RentAgreement { Id = 2 };

            await db.RentAgreements.AddRangeAsync(firstRent, secndRent);
            await db.SaveChangesAsync();
            var rentPaymentService = new MonthlyRentsService(mapper, db);
            //Act
            var result = await rentPaymentService.CreateAsync(3, 1234, new DateTime(2018, 12, 12));
            var createdRentPayment = await db.MonthlyPaymentRents
                .FirstOrDefaultAsync(x => x.TotalPayment == 1234 && x.DeadLine == new DateTime(2018, 12, 12));
            //Assert
            result
                .Should()
                .BeFalse();
            createdRentPayment
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task CreateNextMonthPayment_ShouldReturn_True_IfSuchRentExist()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            
            var secndRent = new MonthlyPaymentRent { Id = 12, DeadLine = new DateTime(2017, 11, 6), TotalPayment = 300 };
            var thirdRent = new MonthlyPaymentRent { Id = 13, DeadLine = new DateTime(2016, 11, 12), TotalPayment = 400 };
            var forthRent = new MonthlyPaymentRent { Id = 14, DeadLine = new DateTime(2015, 12, 15), TotalPayment = 500 };
            await db.MonthlyPaymentRents.AddRangeAsync( secndRent, thirdRent, forthRent);
            await db.SaveChangesAsync();
            var rentPaymentService = new MonthlyRentsService(mapper, db);
            //Act
            var result = await rentPaymentService.CreateNextMonthPayment(12);
            var createdRent = await db.MonthlyPaymentRents
                .FirstOrDefaultAsync(x => x.DeadLine == new DateTime(2017, 12, 6) 
                    && x.TotalPayment==300);
            //Assert
            result
                .Should()
                .BeTrue();
            createdRent
                .Should()
                .NotBeNull();
        }

        [Fact]
        public async Task CreateNextMonthPayment_ShouldReturn_False_IfSuchRentDoNotExist()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstRent = new MonthlyPaymentRent { Id = 1, DeadLine = new DateTime(2018, 12, 12), TotalPayment = 200 };
            var secndRent = new MonthlyPaymentRent { Id = 2, DeadLine = new DateTime(2017, 11, 6), TotalPayment = 300 };
            var thirdRent = new MonthlyPaymentRent { Id = 3, DeadLine = new DateTime(2016, 11, 12), TotalPayment = 400 };
            var forthRent = new MonthlyPaymentRent { Id = 4, DeadLine = new DateTime(2015, 12, 15), TotalPayment = 500 };
            await db.MonthlyPaymentRents.AddRangeAsync(firstRent, secndRent, thirdRent, forthRent);
            await db.SaveChangesAsync();
            var rentPaymentService = new MonthlyRentsService(mapper, db);
            //Act
            var result = await rentPaymentService.CreateNextMonthPayment(5);

            //Assert
            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public async Task EditAsync_ShouldReturn_True_IfRentExist()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstRent = new MonthlyPaymentRent { Id = 1, DeadLine = new DateTime(2018, 12, 12), TotalPayment = 200 , IsPaid=false};
            var secndRent = new MonthlyPaymentRent { Id = 2, DeadLine = new DateTime(2017, 11, 6), TotalPayment = 300 ,IsPaid=false};
            await db.MonthlyPaymentRents.AddRangeAsync(firstRent,secndRent);
            await db.SaveChangesAsync();
            var rentPaymentService = new MonthlyRentsService(mapper, db);
            //Act
            var editModel = new MonthlyRentViewModel
            {
                Id=1,
                DeadLine = new DateTime(2018, 12, 22),
                TotalPayment = 300
            };
            var result = await rentPaymentService.EditAsync(editModel);
            var createdRent = await db.MonthlyPaymentRents
                .FirstOrDefaultAsync(x => x.Id==1);
            //Assert
            result
                .Should()
                .BeTrue();
            createdRent
                .Should()
                .Match<MonthlyPaymentRent>(x=>
                x.TotalPayment==300
                && x.DeadLine== new DateTime(2018, 12, 22));
        }

        [Fact]
        public async Task EditAsync_ShouldReturn_false_IfRentNotExist()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstRent = new MonthlyPaymentRent { Id = 1, DeadLine = new DateTime(2018, 12, 12), TotalPayment = 200, IsPaid = false };
            var secndRent = new MonthlyPaymentRent { Id = 2, DeadLine = new DateTime(2017, 11, 6), TotalPayment = 300, IsPaid = false };
            await db.MonthlyPaymentRents.AddRangeAsync(firstRent, secndRent);
            await db.SaveChangesAsync();
            var rentPaymentService = new MonthlyRentsService(mapper, db);
            //Act
            var editModel = new MonthlyRentViewModel
            {
                Id = 4,
                DeadLine = new DateTime(2018, 12, 22),
                TotalPayment = 300
            };
            var result = await rentPaymentService.EditAsync(editModel);
            ;
            //Assert
            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public async Task EditAsync_ShouldReturn_false_IfRentAlreadyPaid()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstRent = new MonthlyPaymentRent { Id = 1, DeadLine = new DateTime(2018, 12, 12), TotalPayment = 200, IsPaid = true };
            var secndRent = new MonthlyPaymentRent { Id = 2, DeadLine = new DateTime(2017, 11, 6), TotalPayment = 300, IsPaid = true };
            await db.MonthlyPaymentRents.AddRangeAsync(firstRent, secndRent);
            await db.SaveChangesAsync();
            var rentPaymentService = new MonthlyRentsService(mapper, db);
            //Act
            var editModel = new MonthlyRentViewModel
            {
                Id = 4,
                DeadLine = new DateTime(2018, 12, 22),
                TotalPayment = 300
            };
            var result = await rentPaymentService.EditAsync(editModel);
            ;
            //Assert
            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturn_CorrectModel_IfRentExistInDb()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstRent = new MonthlyPaymentRent { Id = 1, DeadLine = new DateTime(2018, 12, 12), TotalPayment = 200, IsPaid = false, ApplyVAT=true };
            var secndRent = new MonthlyPaymentRent { Id = 2, DeadLine = new DateTime(2017, 11, 6), TotalPayment = 300, IsPaid = false, ApplyVAT=true };
            await db.MonthlyPaymentRents.AddRangeAsync(firstRent, secndRent);
            await db.SaveChangesAsync();
            var rentPaymentService = new MonthlyRentsService(mapper, db);
            //Act            
            var result = await rentPaymentService.GetByIdAsync(1);
            //Assert
            result
                .Should()
                .BeOfType< MonthlyRentViewModel >()
                .And
                .Match<MonthlyRentViewModel>(x =>
                x.TotalPayment == 200
                && x.DeadLine == new DateTime(2018, 12, 12));
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturn_Nulll_IfRentDoNotExistInDb()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstRent = new MonthlyPaymentRent { Id = 1, DeadLine = new DateTime(2018, 12, 12), TotalPayment = 200, IsPaid = false, ApplyVAT = true };
            var secndRent = new MonthlyPaymentRent { Id = 2, DeadLine = new DateTime(2017, 11, 6), TotalPayment = 300, IsPaid = false, ApplyVAT = true };
            await db.MonthlyPaymentRents.AddRangeAsync(firstRent, secndRent);
            await db.SaveChangesAsync();
            var rentPaymentService = new MonthlyRentsService(mapper, db);
            //Act            
            var result = await rentPaymentService.GetByIdAsync(3);
            //Assert
            result
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task GetDetailsAsync_ShouldReturn_CorrectModel_IfRentAgreementExistInDb()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstRentAgreement = new RentAgreement
            {
                Id = 1,
                MonthlyPrice=1000,
                PropertyRents = new List<PropertyRent>
                {
                    new PropertyRent
                    {
                        Property = new Property {Id=1,Name="Room",Area=10,IsActual=true }
                    }
                },
                Client = new Client {Id=1, Name="Petar" },
                ParkingSlots = new List<ParkingSlot>
                {
                    new ParkingSlot{Id=1,Quantity=10,Price=10 },
                    new ParkingSlot{ Id=2,Quantity=2,Price=2}
                }
            };

            await db.RentAgreements.AddAsync(firstRentAgreement);
            await db.SaveChangesAsync();
            var rentPaymentService = new MonthlyRentsService(mapper, db);
            //Act            
            var result = await rentPaymentService.GetDetailsAsync(1);
            //Assert
            result
                .Should()
                .Match<CreateMonthlyRentFormViewModel>(x=>
                x.Client=="Petar"
                && x.ParkingSlotsQty==12
                && x.Properties.Contains("Room с площ: 10")
                && x.TotalPayment==1104
                && x.RentAgreementId==1);
        }

        [Fact]
        public async Task GetDetailsAsync_ShouldReturn_Null_IfRentAgreementDoNotExistInDb()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstRentAgreement = new RentAgreement
            {
                Id = 1,
                MonthlyPrice = 1000,
                PropertyRents = new List<PropertyRent>
                {
                    new PropertyRent
                    {
                        Property = new Property {Id=1,Name="Room",Area=10,IsActual=true }
                    }
                },
                Client = new Client { Id = 1, Name = "Petar" },
                ParkingSlots = new List<ParkingSlot>
                {
                    new ParkingSlot{Id=1,Quantity=10,Price=10 },
                    new ParkingSlot{ Id=2,Quantity=2,Price=2}
                }
            };

            await db.RentAgreements.AddAsync(firstRentAgreement);
            await db.SaveChangesAsync();
            var rentPaymentService = new MonthlyRentsService(mapper, db);
            //Act            
            var result = await rentPaymentService.GetDetailsAsync(2);
            //Assert
            result
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task TerminateAsync_ShouldReturn_True_IfMonthlyRentExistInDbAndIsNotPaid()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstRent = new MonthlyPaymentRent { Id = 1, DeadLine = new DateTime(2018, 12, 12), TotalPayment = 200, IsPaid = false, ApplyVAT = true };
            var secndRent = new MonthlyPaymentRent { Id = 2, DeadLine = new DateTime(2017, 11, 6), TotalPayment = 300, IsPaid = false, ApplyVAT = true };
            await db.MonthlyPaymentRents.AddRangeAsync(firstRent, secndRent);
            await db.SaveChangesAsync();
            var rentPaymentService = new MonthlyRentsService(mapper, db);
            //Act            
            var result = await rentPaymentService.TerminateAsync(1);
            var termnatedMontlyRent = await db.MonthlyPaymentRents
                .FindAsync(1);
            //Assert
            result
                .Should()
                .BeTrue();
            termnatedMontlyRent
                .Should()
                .Match<MonthlyPaymentRent>(x=>x.IsPaid==true);
        }

        [Fact]
        public async Task TerminateAsync_ShouldReturn_False_IfMonthlyRentDoNotExistInDb()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstRent = new MonthlyPaymentRent { Id = 1, DeadLine = new DateTime(2018, 12, 12), TotalPayment = 200, IsPaid = false, ApplyVAT = true };
            var secndRent = new MonthlyPaymentRent { Id = 2, DeadLine = new DateTime(2017, 11, 6), TotalPayment = 300, IsPaid = false, ApplyVAT = true };
            await db.MonthlyPaymentRents.AddRangeAsync(firstRent, secndRent);
            await db.SaveChangesAsync();
            var rentPaymentService = new MonthlyRentsService(mapper, db);
            //Act            
            var result = await rentPaymentService.TerminateAsync(4);
            //Assert
            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public async Task TerminateAsync_ShouldReturn_False_IfMonthlyRentIsAlreadyPaid()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstRent = new MonthlyPaymentRent { Id = 1, DeadLine = new DateTime(2018, 12, 12), TotalPayment = 200, IsPaid = true, ApplyVAT = true };
            var secndRent = new MonthlyPaymentRent { Id = 2, DeadLine = new DateTime(2017, 11, 6), TotalPayment = 300, IsPaid = false, ApplyVAT = true };
            await db.MonthlyPaymentRents.AddRangeAsync(firstRent, secndRent);
            await db.SaveChangesAsync();
            var rentPaymentService = new MonthlyRentsService(mapper, db);
            //Act            
            var result = await rentPaymentService.TerminateAsync(1);
            //Assert
            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public async Task AllOverdueRentsAsync_ShouldReturn_Collection_WithAllDelayedRents()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstRent = new MonthlyPaymentRent { Id = 1, DeadLine = new DateTime(2016, 12, 12), TotalPayment = 200, IsPaid = false, ApplyVAT = true };
            var secndRent = new MonthlyPaymentRent { Id = 2, DeadLine = new DateTime(2017, 11, 6), TotalPayment = 300, IsPaid = false, ApplyVAT = true };
            var thirdRent = new MonthlyPaymentRent { Id = 3, DeadLine = new DateTime(2018, 11, 6), TotalPayment = 400, IsPaid = true, ApplyVAT = true };
            var fourthRent = new MonthlyPaymentRent { Id = 4, DeadLine = new DateTime(2050, 11, 6), TotalPayment = 500, IsPaid = false, ApplyVAT = true };
            await db.MonthlyPaymentRents.AddRangeAsync(firstRent, secndRent,thirdRent, fourthRent);
            await db.SaveChangesAsync();
            var rentPaymentService = new MonthlyRentsService(mapper, db);
            //Act            
            var result = await rentPaymentService.AllOverdueRentsAsync();
            //Assert
            result
                .Should()
                .HaveCount(2)
                .And
                .Match(x => x.ElementAt(0).TotalPayment == 200
                    && x.ElementAt(1).TotalPayment == 300);
        }
        private EstateManagmentContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<EstateManagmentContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var db = new EstateManagmentContext(dbOptions);

            return db;
        }

        private IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            return config.CreateMapper();
        }
    }
}
