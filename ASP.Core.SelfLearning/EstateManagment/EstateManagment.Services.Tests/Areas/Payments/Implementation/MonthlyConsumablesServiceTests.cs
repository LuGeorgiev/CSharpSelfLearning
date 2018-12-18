using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Services.Areas.Payments.Implementation;
using EstateManagment.Services.Models.Areas.Payments.MonthlyConsumables;
using EstateManagment.Web.Common.Mapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EstateManagment.Services.Tests.Areas.Payments.Implementation
{
    public class MonthlyConsumablesServiceTests
    {
        [Fact]
        public async Task AllNotPaid_ShouldReturn_AllConsumablesThatAreNotPaid_IfSuchExist()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstConsumable = new MonthlyPaymentConsumable { Id =1, PaymentId=null,DeadLine = new DateTime(2018,12,12) };
            var secndConsumable = new MonthlyPaymentConsumable { Id =2, PaymentId=null,DeadLine = new DateTime(2018,11,12) };
            var thirdConsumable = new MonthlyPaymentConsumable { Id =3, PaymentId = 2 ,DeadLine = new DateTime(2018,11,12) };
            var forthConsumable = new MonthlyPaymentConsumable { Id =4, PaymentId=null,DeadLine = new DateTime(2018,12,15) };
            await db.MonthlyPaymentConsumables.AddRangeAsync(firstConsumable,secndConsumable,thirdConsumable, forthConsumable);
            await db.SaveChangesAsync();
            var consumableService = new MonthlyConsumablesService(mapper, db);
            //Act
            var result = await consumableService.AllNotPaidAsync();
            //Assert
            result
                .Should()
                .HaveCount(3)
                .And
                .Match(x => x.ElementAt(0).Id == 4
                    && x.ElementAt(1).Id == 1);
        }

        [Fact]
        public async Task CreateMonthlyConsumable_ShouldReturn_True_IfInputCorrect()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var rent = new RentAgreement { Id = 1, IsActual = true };
            await db.RentAgreements.AddAsync(rent);
            await db.SaveChangesAsync();
            var consumabelService = new MonthlyConsumablesService(mapper, db);

            var consumableInput = new MonthlyConsumablesBindingModel
            {
                DeadLine = new DateTime(2018, 12,24),
                ElectricityDay=1,
                ElectricityNight=2,
                ElectricityPeak=3,
                PaymentForElectricity=4,
                PaymentForWater=5,
                WaterReport=6,
                rentId=1
            };
            //Act
            var result = await consumabelService.CreateAsync(consumableInput);
            var createdConsumable = await db.MonthlyPaymentConsumables
                .FirstOrDefaultAsync(x=>x.ElectricityDay==1 && x.PaymentForWater==5);
            //Assert
            result
                .Should()
                .BeTrue();
            createdConsumable
                .Should()
                .Match<MonthlyPaymentConsumable>(x=>
                    x.DeadLine== new DateTime(2018, 12, 24)
                    && x.ElectricityDay==1
                    &&x.ElectricityNight==2
                    && x.ElectricityPeak==3
                    && x.PaymentForElectricity==4
                    && x.PaymentForWater==5
                    && x.WaterReport==6);
        }

        [Fact]
        public async Task CreateMonthlyConsumable_ShouldReturn_False_IfInputIsNotCorrect()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var rent = new RentAgreement { Id = 1, IsActual = true };
            await db.RentAgreements.AddAsync(rent);
            await db.SaveChangesAsync();
            var consumabelService = new MonthlyConsumablesService(mapper, db);

            var consumableInput = new MonthlyConsumablesBindingModel
            {
                DeadLine = new DateTime(2018, 12, 24),
                ElectricityDay = 1,
                ElectricityNight = 2,
                ElectricityPeak = 3,
                PaymentForElectricity = 4,
                PaymentForWater = 5,
                WaterReport = 6,
                rentId = 2
            };
            //Act
            var result = await consumabelService.CreateAsync(consumableInput);
            var createdConsumable = await db.MonthlyPaymentConsumables
                .FirstOrDefaultAsync(x => x.ElectricityDay == 1 && x.PaymentForWater == 5);
            //Assert
            result
                .Should()
                .BeFalse();
            createdConsumable
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task EditAsync_ShouldReturn_True_IfEntryExist()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var monthlyConsumable = new MonthlyPaymentConsumable
            {
                Id=1,
                DeadLine=new DateTime(2018, 12, 12),
                ElectricityDay = 1,
                ElectricityNight = 2,
                ElectricityPeak = 3,
                PaymentForElectricity = 4,
                PaymentForWater = 5,
                WaterReport = 6                
            };
            await db.MonthlyPaymentConsumables.AddAsync(monthlyConsumable);
            await db.SaveChangesAsync();
            var consumabelService = new MonthlyConsumablesService(mapper, db);

            var consumableEditInput = new EditMontlyConsumablesModel
            {
                DeadLine = new DateTime(2018, 12, 24),
                ElectricityDay = 7,
                ElectricityNight = 8,
                ElectricityPeak = 9,
                PaymentForElectricity = 10,
                PaymentForWater = 11,
                WaterReport = 12,
                Id=1
            };
            //Act
            var result = await consumabelService.EditAsync(consumableEditInput);
            var createdConsumable = await db.MonthlyPaymentConsumables
                .FirstOrDefaultAsync(x => x.Id == 1 );
            //Assert
            result
               .Should()
               .BeTrue();

            createdConsumable
                .Should()
                .Match<MonthlyPaymentConsumable>(x =>
                    x.DeadLine == new DateTime(2018, 12, 24)
                    && x.ElectricityDay == 7
                    && x.ElectricityNight == 8
                    && x.ElectricityPeak == 9
                    && x.PaymentForElectricity == 10
                    && x.PaymentForWater == 11
                    && x.WaterReport == 12);
        }

        [Fact]
        public async Task EditAsync_ShouldReturn_False_IfEntryDoNotExist()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var monthlyConsumable = new MonthlyPaymentConsumable
            {
                Id = 1,
                DeadLine = new DateTime(2018, 12, 12),
                ElectricityDay = 1,
                ElectricityNight = 2,
                ElectricityPeak = 3,
                PaymentForElectricity = 4,
                PaymentForWater = 5,
                WaterReport = 6
            };
            await db.MonthlyPaymentConsumables.AddAsync(monthlyConsumable);
            await db.SaveChangesAsync();
            var consumabelService = new MonthlyConsumablesService(mapper, db);

            var consumableEditInput = new EditMontlyConsumablesModel
            {
                DeadLine = new DateTime(2018, 12, 24),
                ElectricityDay = 7,
                ElectricityNight = 8,
                ElectricityPeak = 9,
                PaymentForElectricity = 10,
                PaymentForWater = 11,
                WaterReport = 12,
                Id = 2
            };
            //Act
            var result = await consumabelService.EditAsync(consumableEditInput);
            var createdConsumable = await db.MonthlyPaymentConsumables
                .FirstOrDefaultAsync(x => x.Id == 2);
            //Assert
            result
               .Should()
               .BeFalse();

            createdConsumable
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturn_Entity_IfExistInDb()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstMonthlyConsumable = new MonthlyPaymentConsumable
            {
                Id = 1,
                DeadLine = new DateTime(2018, 12, 12),
                ElectricityDay = 1,
                ElectricityNight = 2,
                ElectricityPeak = 3,
                PaymentForElectricity = 4,
                PaymentForWater = 5,
                WaterReport = 6
            };
            var secondMonthlyConsumable = new MonthlyPaymentConsumable
            {
                Id = 2,
                DeadLine = new DateTime(2018, 12, 24),
                ElectricityDay = 7,
                ElectricityNight = 8,
                ElectricityPeak = 9,
                PaymentForElectricity = 10,
                PaymentForWater = 11,
                WaterReport = 12
            };
            await db.MonthlyPaymentConsumables.AddRangeAsync(firstMonthlyConsumable,secondMonthlyConsumable);
            await db.SaveChangesAsync();
            var consumabelService = new MonthlyConsumablesService(mapper, db);           
            //Act
            var result = await consumabelService.GetByIdAsync(2);
            //Assert
            result
               .Should()
               .BeOfType<MonthlyConsumablesViewModel>()
               .And
               .Match<MonthlyConsumablesViewModel>(x =>
                    x.DeadLine == new DateTime(2018, 12, 24)
                    && x.ElectricityDay == 7
                    && x.ElectricityNight == 8
                    && x.ElectricityPeak == 9
                    && x.PaymentForElectricity == 10
                    && x.PaymentForWater == 11
                    && x.WaterReport == 12);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturn_Null_IfExistNotInDb()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstMonthlyConsumable = new MonthlyPaymentConsumable
            {
                Id = 1,
                DeadLine = new DateTime(2018, 12, 12),
                ElectricityDay = 1,
                ElectricityNight = 2,
                ElectricityPeak = 3,
                PaymentForElectricity = 4,
                PaymentForWater = 5,
                WaterReport = 6
            };
            var secondMonthlyConsumable = new MonthlyPaymentConsumable
            {
                Id = 2,
                DeadLine = new DateTime(2018, 12, 24),
                ElectricityDay = 7,
                ElectricityNight = 8,
                ElectricityPeak = 9,
                PaymentForElectricity = 10,
                PaymentForWater = 11,
                WaterReport = 12
            };
            await db.MonthlyPaymentConsumables.AddRangeAsync(firstMonthlyConsumable, secondMonthlyConsumable);
            await db.SaveChangesAsync();
            var consumabelService = new MonthlyConsumablesService(mapper, db);
            //Act
            var result = await consumabelService.GetByIdAsync(3);
            //Assert
            result
               .Should()
               .BeNull();
        }


        [Fact]
        public async Task GetCreateInfoAsync_ShouldReturn_CreateModel_IfRentExistInDb()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var rent = new RentAgreement
            {
                Id = 1,
                IsActual = true,
                Client = new Client {Id=1,Name="Ivan",AccountableName="Parkash" },
                PropertyRents =new List<PropertyRent>()
                {
                    new PropertyRent
                    {
                        Property =new Property{Id=1,Name="Office Grande",Area=122 }
                    },
                    new PropertyRent
                    {
                        Property =new Property{Id=2,Name="Room",Area=20 }
                    }
                }
            };
            await db.RentAgreements.AddAsync(rent);
            await db.SaveChangesAsync();
            var consumabelService = new MonthlyConsumablesService(mapper, db);
            
            //Act
            var result = await consumabelService.GetCreateInfoAsync(1);
            //Assert
            result
                .Should()
                .BeOfType<CreateMonthlyConsumablesModel>()
                .And
                .Match<CreateMonthlyConsumablesModel>(x =>
                   x.Client=="Ivan"
                   && x.Properties.Any(p=>p.Contains("Office Grande")));
        }

        [Fact]
        public async Task GetCreateInfoAsync_ShouldReturn_Null_IfRentDoNotExistInDb()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var rent = new RentAgreement
            {
                Id = 1,
                IsActual = true,
                Client = new Client { Id = 1, Name = "Ivan", AccountableName = "Parkash" },
                PropertyRents = new List<PropertyRent>()
                {
                    new PropertyRent
                    {
                        Property =new Property{Id=1,Name="Office Grande",Area=122 }
                    },
                    new PropertyRent
                    {
                        Property =new Property{Id=2,Name="Room",Area=20 }
                    }
                }
            };
            await db.RentAgreements.AddAsync(rent);
            await db.SaveChangesAsync();
            var consumabelService = new MonthlyConsumablesService(mapper, db);

            //Act
            var result = await consumabelService.GetCreateInfoAsync(2);
            //Assert
            result
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task TerminateAsync_ShouldReturn_True_IfEntityExistInDb()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstMonthlyConsumable = new MonthlyPaymentConsumable
            {
                Id = 1,
                DeadLine = new DateTime(2018, 12, 12),
                ElectricityDay = 1,
                ElectricityNight = 2,
                ElectricityPeak = 3,
                PaymentForElectricity = 4,
                PaymentForWater = 5,
                WaterReport = 6
            };
            var secondMonthlyConsumable = new MonthlyPaymentConsumable
            {
                Id = 2,
                DeadLine = new DateTime(2018, 12, 24),
                ElectricityDay = 7,
                ElectricityNight = 8,
                ElectricityPeak = 9,
                PaymentForElectricity = 10,
                PaymentForWater = 11,
                WaterReport = 12
            };
            await db.MonthlyPaymentConsumables.AddRangeAsync(firstMonthlyConsumable, secondMonthlyConsumable);
            await db.SaveChangesAsync();
            var consumabelService = new MonthlyConsumablesService(mapper, db);
            //Act
            var result = await consumabelService.TerminateAsync(2);
            var terminatedEntity = await db.MonthlyPaymentRents.FindAsync(2);
            //Assert
            result
               .Should()
               .BeTrue();
            terminatedEntity
                .Should()
                .BeNull();
        }


        [Fact]
        public async Task TerminateAsync_ShouldReturn_False_IfEntityNotExistInDb()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstMonthlyConsumable = new MonthlyPaymentConsumable
            {
                Id = 1,
                DeadLine = new DateTime(2018, 12, 12),
                ElectricityDay = 1,
                ElectricityNight = 2,
                ElectricityPeak = 3,
                PaymentForElectricity = 4,
                PaymentForWater = 5,
                WaterReport = 6
            };
            var secondMonthlyConsumable = new MonthlyPaymentConsumable
            {
                Id = 2,
                DeadLine = new DateTime(2018, 12, 24),
                ElectricityDay = 7,
                ElectricityNight = 8,
                ElectricityPeak = 9,
                PaymentForElectricity = 10,
                PaymentForWater = 11,
                WaterReport = 12
            };
            await db.MonthlyPaymentConsumables.AddRangeAsync(firstMonthlyConsumable, secondMonthlyConsumable);
            await db.SaveChangesAsync();
            var consumabelService = new MonthlyConsumablesService(mapper, db);
            //Act
            var result = await consumabelService.TerminateAsync(3);
            //Assert
            result
               .Should()
               .BeFalse();
        }

        [Fact]
        public async Task AllOverduConsumablesAsync_ShouldReturn_CollectionWithPendigPayments_IfSuchExistInDb()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstMonthlyConsumable = new MonthlyPaymentConsumable
            {
                Id = 1,
                DeadLine = new DateTime(2016, 12, 12),
                PaymentForElectricity = 4,
                PaymentForWater = 5,
            };
            var secondMonthlyConsumable = new MonthlyPaymentConsumable
            {
                Id = 2,
                DeadLine = new DateTime(2017, 12, 24),
                PaymentForElectricity = 10,
                PaymentForWater = 11,
            };
            var thirdMonthlyConsumable = new MonthlyPaymentConsumable
            {
                Id = 3,
                DeadLine = new DateTime(2050, 12, 24),
                PaymentForElectricity = 14,
                PaymentForWater = 17,
            };
            await db.MonthlyPaymentConsumables.AddRangeAsync(firstMonthlyConsumable, secondMonthlyConsumable,thirdMonthlyConsumable);
            await db.SaveChangesAsync();
            var consumabelService = new MonthlyConsumablesService(mapper, db);
            //Act
            var result = await consumabelService.AllOverduConsumablesAsync();
            //Assert
            result
                .Should()
                .HaveCount(2)
                .And
                .BeOfType<List<OverdueMonthlyConsumablesListingModel>>()
                .And
                .Match(x => x.ElementAt(0).PaymentForElectricity == 4
                    && x.ElementAt(1).PaymentForWater == 11);
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
