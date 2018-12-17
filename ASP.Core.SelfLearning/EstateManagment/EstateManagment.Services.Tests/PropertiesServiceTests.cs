using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Data.Models.Enums;
using EstateManagment.Services.Implementation;
using EstateManagment.Services.Models.Property;
using EstateManagment.Web.Common.Mapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EstateManagment.Services.Tests
{
    public class PropertiesServiceTests
    {

        [Fact]
        public async Task AllActiveAsync_SouldReturn_CollectionWithActiveProperties_FromDb()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstProp = new Property { Id = 1, Name = "Голям склад", Area=400, IsActual=true};
            var secondProp = new Property { Id = 2, Name = "Голям склад", Area=300,IsActual =true  };
            var thirdProp = new Property { Id = 3, Name = "Офис", Area=80,IsActual=true };
            var forthProp = new Property { Id = 4, Name = "Стая", Area=20,IsActual=false };
            await db.Properties.AddRangeAsync(firstProp, secondProp, thirdProp,forthProp);
            await db.SaveChangesAsync();

            var propertyService = new PropertiesService(mapper, db);

            var result = await propertyService.AllActiveAsync();

            result
                .Should()
                .NotBeEmpty()
                .And
                .HaveCount(3)
                .And
                .Match(c =>
                    c.ElementAt(0).Id == 1
                    && c.ElementAt(1).Area == 300
                    && c.ElementAt(2).Name == "Офис");
        }

        [Fact]
        public async Task AllActiveAsync_SouldReturn_EmptyCollection_IfAppPrpertiesAreNotActiveInDb()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstProp = new Property { Id = 1, Name = "Голям склад", Area = 400, IsActual = false };
            var secondProp = new Property { Id = 2, Name = "Голям склад", Area = 300, IsActual = false };
            var thirdProp = new Property { Id = 3, Name = "Офис", Area = 80, IsActual = false };
            var forthProp = new Property { Id = 4, Name = "Стая", Area = 20, IsActual = false };
            await db.Properties.AddRangeAsync(firstProp, secondProp, thirdProp, forthProp);
            await db.SaveChangesAsync();

            var propertyService = new PropertiesService(mapper, db);

            var result = await propertyService.AllActiveAsync();

            result
                .Should()
                .BeEmpty();
        }

        [Fact]
        public async Task AllFreeAsync_SouldReturn_CollectionWithFreeProperties_FromDb()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstRentAgreement = new RentAgreement {Id=1, EndDate=new DateTime(2000,12,12) };
            var secondRentAgreement = new RentAgreement {Id=2, EndDate=new DateTime(2002, 12,12) };
            var thirdRentAgreement = new RentAgreement {Id=3, EndDate=new DateTime(2050,12,12) };
            var forthtRentAgreement = new RentAgreement {Id=4, EndDate=new DateTime(2004,12,12) };
            var fifthRentAgreement = new RentAgreement {Id=5, EndDate=null };

            var firstProp = new Property { Id = 1, Name = "Голям склад", Area = 400, IsActual = true,
                PropertyRents = new List<PropertyRent>()
                {
                    new PropertyRent { RentAgreement = firstRentAgreement },
                    new PropertyRent { RentAgreement = secondRentAgreement}
                } };

            var secondProp = new Property { Id = 2, Name = "Голям склад", Area = 300, IsActual = true ,
                PropertyRents = new List<PropertyRent>()
                {
                    new PropertyRent { RentAgreement = thirdRentAgreement }
                }
            };
            var thirdProp = new Property { Id = 3, Name = "Офис", Area = 80, IsActual = true ,
                PropertyRents = new List<PropertyRent>()
                {
                    new PropertyRent { RentAgreement = forthtRentAgreement }
                }
            };
            var forthProp = new Property { Id = 4, Name = "Стая", Area = 20, IsActual = true ,
                PropertyRents = new List<PropertyRent>()
                {
                    new PropertyRent { RentAgreement = fifthRentAgreement }
                }
            };
            await db.Properties.AddRangeAsync(firstProp, secondProp, thirdProp, forthProp);
            await db.SaveChangesAsync();

            var propertyService = new PropertiesService(mapper, db);

            var result = await propertyService.AllFreeAsync();

            result
                .Should()
                .NotBeEmpty()
                .And
                .HaveCount(2)
                .And
                .Match(c =>
                    c.ElementAt(0).Id == 1
                    && c.ElementAt(1).Area == 80);
        }

        [Fact]
        public async Task AllWithCompaniesAsync_SouldReturn_CollectionWithAllPropertiesForEachCompany_FromDb()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();


            var firstProp = new Property
            {
                Id = 1,
                Name = "Голям склад",
                Area = 400,
                IsActual = true
            };
            var secondProp = new Property
            {
                Id = 2,
                Name = "Голям склад",
                Area = 300,
                IsActual = true
            };
            var thirdProp = new Property
            {
                Id = 3,
                Name = "Офис",
                Area = 80,
                IsActual = true
            };
            var forthProp = new Property
            {
                Id = 4,
                Name = "Стая",
                Area = 20,
                IsActual = true
            };

            var companyOne = new Company
            {
                Id = 1,
                Name = "First",
                Properties = new List<Property>() {firstProp }
            };
            var companyTwo = new Company
            {
                Id = 2,
                Name = "Second",
                Properties = new List<Property>() { thirdProp, forthProp,secondProp }
            };
            await db.Companies.AddRangeAsync(companyOne,companyTwo);
            await db.SaveChangesAsync();

            var propertyService = new PropertiesService(mapper, db);

            var result = await propertyService.AllWithCompaniesAsync();

            result
                .Should()
                .NotBeEmpty()
                .And
                .HaveCount(2)
                .And
                .Match(c =>
                    c.ElementAt(0).CompanyId == 1
                    && c.ElementAt(1).CompanyName == "Second"
                        && c.ElementAt(0).Properties.Count()==1);
        }

        [Fact]
        public async Task CreateAsync_SouldReturn_True_IfInputDataIsCorrectFromDb()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();


            var firstProp = new Property
            {
                Id = 3,
                Name = "Голям склад",
                Area = 400,
                IsActual = true
            };   
            var companyOne = new Company
            {
                Id = 1,
                Name = "First",
                Properties = new List<Property>() { firstProp }
            };          
            await db.Companies.AddRangeAsync(companyOne);
            await db.SaveChangesAsync();
            var propertyService = new PropertiesService(mapper, db);
            var model = new CreatePropertyModel
            {
                CompanyId = 1,                
                PropertyName = "Office",
                Description = "No Descriprion",
                Area = 80,
                Type=PropertyType.Office,
                PropertyAddress="Mars"                
            };

            //Act
            var result = await propertyService.CreateAsync(model);
            var addedProperty = await db.Properties.FirstOrDefaultAsync(x => x.Name == "Office");

            //Assert
            result
                .Should()
                .BeTrue();

           addedProperty
                .Should()
                .NotBeNull()
                .And
                .BeOfType<Property>()
                .And
                .Match<Property>(p => p.Type==PropertyType.Office
                    && p.Address=="Mars"
                    && p.Area==80
                    && p.CompanyId==1);
        }

        [Fact]
        public async Task CreateAsync_SouldReturn_False_IfCompanyDoNotExistsDb()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstProp = new Property
            {
                Id = 3,
                Name = "Голям склад",
                Area = 400,
                IsActual = true
            };
            var companyOne = new Company
            {
                Id = 1,
                Name = "First",
                Properties = new List<Property>() { firstProp }
            };
            await db.Companies.AddRangeAsync(companyOne);
            await db.SaveChangesAsync();
            var propertyService = new PropertiesService(mapper, db);

            var model = new CreatePropertyModel
            {
                CompanyId = 2, // ID do not exsist
                PropertyName = "Office",
                Description = "No Descriprion",
                Area = 80,
                Type = PropertyType.Office,
                PropertyAddress = "Mars"
            };

            //Act
            var result = await propertyService.CreateAsync(model);
            var addedProperty = await db.Properties.FirstOrDefaultAsync(x => x.Name == "Office");

            //Assert
            result
                .Should()
                .BeFalse();

            addedProperty
                 .Should()
                 .BeNull();
        }

        [Fact]
        public async Task EditAsync_SouldReturn_True_IfInputDataIsCorrect()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstProp = new Property { Id = 1,  IsActual = true, Description="A lot of" };
            var secondProp = new Property { Id = 2, IsActual = true , Description="None"};

            await db.Properties.AddRangeAsync(firstProp, secondProp);
            await db.SaveChangesAsync();

            var propertyService = new PropertiesService(mapper, db);

            //Act
            var result = await propertyService.EditAsync(1,"Not Active",false);
            var editedProperty = await db.Properties.FirstOrDefaultAsync(x => x.Id == 1);

            //Assert
            result
                .Should()
                .BeTrue();

            editedProperty
                .Should()
                .BeOfType<Property>()
                .And
                .Match<Property>(p=>p.IsActual==false
                    && p.Description== "Not Active");
        }

        [Fact]
        public async Task EditAsync_SouldReturn_False_IfPropertyDoNotExist()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstProp = new Property { Id = 1, IsActual = true, Description = "A lot of" };
            var secondProp = new Property { Id = 2, IsActual = true, Description = "None" };

            await db.Properties.AddRangeAsync(firstProp, secondProp);
            await db.SaveChangesAsync();

            var propertyService = new PropertiesService(mapper, db);

            //Act
            var result = await propertyService.EditAsync(3, "Not Active", false);
            var editedProperty = await db.Properties.FirstOrDefaultAsync(x => x.Id == 3);

            //Assert
            result
                .Should()
                .BeFalse();

            editedProperty
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task GetAsync_SouldReturn_PropertyWithDetails_IfPropertyExist()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstProp = new Property
            {
                Id = 1,
                IsActual = true,
                Description = "A lot of",
                Address = "Drujba",
                Name="Warehouse",
                Area=300,
                Type = PropertyType.Warehouse
            };
            var secondProp = new Property { Id = 2, IsActual = true, Description = "None" };
            await db.Properties.AddRangeAsync(firstProp, secondProp);
            await db.SaveChangesAsync();
            var propertyService = new PropertiesService(mapper, db);

            //Act
            var result = await propertyService.GetAsync(1);

            //Assert
            result
                .Should()
                .BeOfType<PropertyDetailsModel>()
                .And
                .Match<PropertyDetailsModel>(p => p.IsActual == true
                    && p.Description == "A lot of"
                    && p.Address== "Drujba"
                    && p.Name== "Warehouse"
                    && p.Area==300
                    && p.Type== PropertyType.Warehouse);            
        }


        [Fact]
        public async Task GetAsync_SouldReturn_Null_IfPropertyDoNotExist()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstProp = new Property
            {
                Id = 1,
                IsActual = true,
                Description = "A lot of",
                Address = "Drujba",
                Name = "Warehouse",
                Area = 300,
                Type = PropertyType.Warehouse
            };
            var secondProp = new Property { Id = 2, IsActual = true, Description = "None" };
            await db.Properties.AddRangeAsync(firstProp, secondProp);
            await db.SaveChangesAsync();
            var propertyService = new PropertiesService(mapper, db);

            //Act
            var result = await propertyService.GetAsync(3);

            //Assert
            result
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
