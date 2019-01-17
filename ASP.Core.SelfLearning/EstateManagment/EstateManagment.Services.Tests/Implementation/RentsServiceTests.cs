using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Services.Areas.Payments;
using EstateManagment.Services.Implementation;
using EstateManagment.Services.Models.Rents;
using EstateManagment.Web.Common.Mapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EstateManagment.Services.Tests.Implementation
{
    public class RentsServiceTests
    {
        [Fact]
        public async Task AllAsync_SouldReturn_CollectionWithActualRentAgreements_FromDb()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstRent = new RentAgreement { Id = 1, MonthlyPrice = 800, IsActual = false, Client= new Client { Id=1, Name = "Asen"} };
            var secondRent = new RentAgreement { Id = 2, MonthlyPrice = 900, IsActual = true, Client= new Client { Id=2, Name = "Boris"} };
            var thirdRent = new RentAgreement { Id = 3, MonthlyPrice = 1900, IsActual = true, Client= new Client { Id=3, Name = "Ceco"} };
            var forthRent = new RentAgreement { Id = 4, MonthlyPrice = 2900, IsActual = true, Client = new Client { Id = 4, Name = "Asen" } };
            await db.RentAgreements.AddRangeAsync(firstRent, secondRent, thirdRent, forthRent);
            await db.SaveChangesAsync();

            var rentService = new RentsService(mapper, db, null);

            var result = await rentService.AllAsync();

            result
                .Should()
                .NotBeEmpty()
                .And
                .BeOfType<List<RentListingViewModel>>()
                .And
                .HaveCount(3)
                .And
                .Match(c =>
                    c.ElementAt(0).Id == 4
                    && c.ElementAt(1).Id == 2);
        }

        [Fact]
        public async Task AllAsync_SouldReturn_CollectionWithNotActualRentAgreements_FalsePassedAsArgumnet()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstRent = new RentAgreement { Id = 1, MonthlyPrice = 800, IsActual = false, Client= new Client { Id=1, Name = "Asen"} };
            var secondRent = new RentAgreement { Id = 2, MonthlyPrice = 900, IsActual = true, Client= new Client { Id=2, Name = "Boris"}};
            var thirdRent = new RentAgreement { Id = 3, MonthlyPrice = 1900, IsActual = true, Client= new Client { Id=3, Name = "Ceco"} };
            var forthRent = new RentAgreement { Id = 4, MonthlyPrice = 2900, IsActual = true, Client = new Client { Id = 4, Name = "Didi" } };
            await db.RentAgreements.AddRangeAsync(firstRent, secondRent, thirdRent, forthRent);
            await db.SaveChangesAsync();

            var rentService = new RentsService(mapper, db, null);

            var result = await rentService.AllAsync(false);

            result
                .Should()
                .NotBeEmpty()
                .And
                .BeOfType<List<RentListingViewModel>>()
                .And
                .HaveCount(1)
                .And
                .Match(c =>
                    c.ElementAt(0).Id == 1);
        }

        [Fact]
        public async Task CreateAsync_SouldReturn_True_IfAllArguentsAreCorrect()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var thirdRent = new RentAgreement { Id = 3, MonthlyPrice = 1900, IsActual = true };
            var forthRent = new RentAgreement { Id = 4, MonthlyPrice = 2900, IsActual = true };
            await db.RentAgreements.AddRangeAsync(thirdRent, forthRent);
            var client = new Client { Id = 1, Name = "Ivan" };
            await db.Clients.AddAsync(client);
            var propertyOne = new Property { Id = 1, Area = 800, IsActual = true };
            var propertyTwo = new Property { Id = 2, Area = 600, IsActual = true };
            await db.Properties.AddRangeAsync(propertyTwo, propertyOne);
            await db.SaveChangesAsync();

            var createModel = new CreateRentModel
            {
                StartDate = new DateTime(2018, 3, 3),
                ClientId = 1,
                Description = "No Desc",
                ParkingSlotDescription = "Some Desc",
                MonthlyPrice = 2000,
                PropertiesIds = new List<int>() { 1, 2 },
                CarSlots = 1,
                CarMonthPrice = 1,
                BusSlots = 2,
                BusMonthPrice = 2,
                TruckSlots = 3,
                TruckMonthPrice = 3,
                BigTruckSlots = 4,
                BigTruckMonthPrice = 4,
                CarCageSlots = 5,
                CarCageMonthPrice = 5,
                OtherSlots = 6,
                OtherMonthPrice = 6
            };
            var monthlyRentMock = new Mock<IMonthlyRentsService>();
            monthlyRentMock
                .Setup(mr => mr.CreateAsync(It.IsAny<int>(), It.IsAny<decimal>(), It.IsAny<DateTime>()))
                .ReturnsAsync ( true );
            var rentService = new RentsService(mapper, db, monthlyRentMock.Object);
            //Act
            var result = await rentService.CreateAsync(createModel);
            var createdRent = await db.RentAgreements
                .FirstOrDefaultAsync(x => x.Description == "No Desc");
            //Assert
            result
                .Should()
                .BeTrue();

            createdRent.Should().BeOfType<RentAgreement>().And
                .Match<RentAgreement>(r =>
                    r.ClientId == 1
                    && r.StartDate == new DateTime(2018, 3, 3)
                    && r.ParkingSlotDescription == "Some Desc"
                    && r.MonthlyPrice == 2000M
                    && r.PropertyRents.Any(x => x.Property.Id == 2)
                    && r.ParkingSlots.Any(x => x.Price == 1M
                        || x.Price == 2M
                        || x.Price == 3M
                        || x.Price == 4M
                        || x.Price == 5M
                        || x.Price == 6M));
        }

        [Fact]
        public async Task EditDescriptionAsync_SouldReturn_True_IfInputIsCorrect()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstRent = new RentAgreement { Id = 1, Description = "Some", ParkingSlotDescription = "None" };

            await db.RentAgreements.AddAsync(firstRent);
            await db.SaveChangesAsync();

            var rentService = new RentsService(mapper, db,null);

            var result = await rentService.EditDescriptionsAsync("Property Description", "Parking description", 1);
            var editedRent = await db.RentAgreements.FindAsync(1);
            result
                .Should()
                .BeTrue();
            editedRent
                .Should()
                .BeOfType<RentAgreement>()
                .And
                .Match<RentAgreement>(c =>
                    c.ParkingSlotDescription == "Parking description"
                    && c.Description == "Property Description");
        }
        [Fact]
        public async Task EditDescriptionAsync_SouldReturn_False_IfInputIsNotCorrect()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstRent = new RentAgreement { Id = 1, Description = "Some", ParkingSlotDescription = "None" };

            await db.RentAgreements.AddAsync(firstRent);
            await db.SaveChangesAsync();

            var rentService = new RentsService(mapper, db, null);

            var result = await rentService.EditDescriptionsAsync("Property Description", "Parking description", 2);
            var editedRent = await db.RentAgreements.FindAsync(2);
            result
                .Should()
                .BeFalse();
            editedRent
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task GetDetailsAsync_SouldReturn_DetaildInformation_IfEntityExist()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();
            var client = new Client { Id = 1, Name = "Margaritka 89" };
            await db.Clients.AddAsync(client);
            var property = new Property { Id = 1, Area = 2000, Name = "Warehouse" };
            await db.Properties.AddAsync(property);
            var firstRent = new RentAgreement
            {
                Id = 1,
                Description = "Some",
                ParkingSlotDescription = "None",
                MonthlyPrice =2000,
                StartDate = new DateTime(2018,3,3),
                Client =client,
                PropertyRents = new List<PropertyRent>()
                    {
                        new PropertyRent { Property = property }
                    }
            };
            await db.RentAgreements.AddAsync(firstRent);
            await db.SaveChangesAsync();
            var rentService = new RentsService(mapper, db, null);

            var result = await rentService.GetDetailsAsync(1);

            result
                .Should()
                .BeOfType<RentDetailsModel>()            
                .And
                .Match<RentDetailsModel>(r=>
                    r.Client== "Margaritka 89"
                    && r.Description== "Some"
                    && r.EndDate==null
                    && r.MonthlyPrice==2000
                    && r.ParkingSlotDescription== "None"
                    && r.Properties.Any(x=>x.Area==2000)
                    && r.StartDate == new DateTime(2018,3,3)
                    );
        }

        [Fact]
        public async Task GetDetailsAsync_SouldReturn_Null_IfEntityDoNotExist()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();
            var client = new Client { Id = 1, Name = "Margaritka 89" };
            await db.Clients.AddAsync(client);
            var property = new Property { Id = 1, Area = 2000, Name = "Warehouse" };
            await db.Properties.AddAsync(property);
            var firstRent = new RentAgreement
            {
                Id = 1,
                Description = "Some",
                ParkingSlotDescription = "None",
                MonthlyPrice = 2000,
                StartDate = new DateTime(2018, 3, 3),
                Client = client,
                PropertyRents = new List<PropertyRent>()
                    {
                        new PropertyRent { Property = property }
                    }
            };
            await db.RentAgreements.AddAsync(firstRent);
            await db.SaveChangesAsync();
            var rentService = new RentsService(mapper, db, null);

            var result = await rentService.GetDetailsAsync(2);

            result
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task TerminateAsync_SouldReturn_True_IfEntityExist()
        {
            var db = this.GetDatabase();
            var mapper = this.GetMapper();


            var firstRent = new RentAgreement
            {
                Id = 1,
                Description = "Some",
                ParkingSlotDescription = "None",
                MonthlyPrice = 2000,
                StartDate = new DateTime(2018, 3, 3),
                IsActual = true
            };
            await db.RentAgreements.AddAsync(firstRent);
            await db.SaveChangesAsync();
            var rentService = new RentsService(mapper, db, null);

            var result = await rentService.TerminateAsync(1);
            var tereminatedRent = await db.RentAgreements.FindAsync(1);

            result
                .Should()
                .BeTrue();
            tereminatedRent
                .Should()
                .Match<RentAgreement>(ra => ra.IsActual == false);
        }

        [Fact]
        public async Task TerminateAsync_SouldReturn_False_IfEntityDoNotExist()
        {
            var db = this.GetDatabase();
            var mapper = this.GetMapper();


            var firstRent = new RentAgreement
            {
                Id = 1,
                Description = "Some",
                ParkingSlotDescription = "None",
                MonthlyPrice = 2000,
                StartDate = new DateTime(2018, 3, 3),
                IsActual = true
            };
            await db.RentAgreements.AddAsync(firstRent);
            await db.SaveChangesAsync();
            var rentService = new RentsService(mapper, db, null);

            var result = await rentService.TerminateAsync(2);

            var tereminatedRent = await db.RentAgreements.FindAsync(2);

            result
                .Should()
                .BeFalse();
            tereminatedRent
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task UploadContractAsync_SouldReturn_True_IfEntityExistAndContentIsCorrect()
        {
            var db = this.GetDatabase();
            var mapper = this.GetMapper();


            var firstRent = new RentAgreement
            {
                Id = 1,
                Description = "Some",
                ParkingSlotDescription = "None",
                MonthlyPrice = 2000,
                StartDate = new DateTime(2018, 3, 3),
                IsActual = true
            };
            await db.RentAgreements.AddAsync(firstRent);
            await db.SaveChangesAsync();
            var rentService = new RentsService(mapper, db, null);
            var contractContent = new byte[] { 121 };
            //Act
            var result = await rentService.UploadContractAsync(contractContent,1);
            var uploadedRent = await db.RentAgreements.FindAsync(1);
            //Assert
            result
                .Should()
                .BeTrue();
            uploadedRent
                .Should()
                .Match<RentAgreement>(ra => ra.Contracts
                    .Any(x=>x.ScannedContract.Length==contractContent.Length));
        }

        [Fact]
        public async Task UploadContractAsync_SouldReturn_False_IfEntityD0NotExist()
        {
            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstRent = new RentAgreement
            {
                Id = 1,
                Description = "Some",
                ParkingSlotDescription = "None",
                MonthlyPrice = 2000,
                StartDate = new DateTime(2018, 3, 3),
                IsActual = true
            };
            await db.RentAgreements.AddAsync(firstRent);
            await db.SaveChangesAsync();
            var rentService = new RentsService(mapper, db, null);
            var contractContent = new byte[] { 121 };
            //Act
            var result = await rentService.UploadContractAsync(contractContent, 2);
            var uploadedRent = await db.RentAgreements.FindAsync(2);
            //Assert
            result
                .Should()
                .BeFalse();
            uploadedRent
                .Should()
                .BeNull();
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
