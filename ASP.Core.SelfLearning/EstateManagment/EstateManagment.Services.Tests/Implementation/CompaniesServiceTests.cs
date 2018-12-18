using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Services.Implementation;
using EstateManagment.Services.Models.Companies;
using EstateManagment.Web.Common.Mapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EstateManagment.Services.Tests.Implementation
{
    public class CompaniesServiceTests
    {
        [Fact]
        public async Task AllAsync_SouldReturn_CollectionWithThreeCompanies_IfThreeAreInDb()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstCompany = new Company { Id = 1, Name = "Свеплина", Bulstat="903097356"};
            var secondCompany = new Company { Id = 2, Name = "Просперитет", Bulstat = "BG909087356" };
            var thirdCompany = new Company { Id = 3, Name = "Тотал Щета", Bulstat = "903099066" };
            await db.Companies.AddRangeAsync(firstCompany, secondCompany, thirdCompany);
            await db.SaveChangesAsync();
            var companyService = new CompaniesService(db, mapper);

            var result = await companyService.AllAsync();

            result
                .Should()
                .NotBeEmpty()
                .And
                .HaveCount(3)
                .And
                .Match(c =>
                    c.ElementAt(0).Name == "Свеплина"
                    && c.ElementAt(1).Bulstat == "BG909087356"
                    && c.ElementAt(2).Name == "Тотал Щета");
        }

        [Fact]
        public async Task AllAsync_SouldReturn_Null_IfNoCompaniesInDb()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();
          ;
            var companyService = new CompaniesService(db, mapper);

            var result = await companyService.AllAsync();

            result
                .Should()
                .BeEmpty();
        }

        [Fact]
        public async Task CreateAsync_ShouldReturn_True_IfInputDataIsCorrect()
        {
            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var companyServiec = new CompaniesService(db, mapper);

            const string name = "Петров 96";
            const string address = "София Младост 6";
            const string bulstat = "BG063698652";
            const string accountablePerson = "Ivan Metodiev";

            //Act
            var result = await companyServiec.CreateAsync(name, address, bulstat,accountablePerson );

            var savedEntry = await db.Companies.FirstOrDefaultAsync(x => x.Name == "Петров 96");

            //Assert
            result
                .Should()
                .BeTrue();

            savedEntry
                .Should()
                .NotBeNull()
                .And
                .BeOfType<Company>()
                .And
                .Match<Company>(x=>x.Bulstat == "BG063698652"
                    && x.Name == "Петров 96");
        }

        [Fact]
        public async Task EditAsync_SouldReturn_True_IfEditDataPassedCorrectly()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstCompany = new Company { Id = 1, Name = "Свеплина", Bulstat = "903097356", AccountablePerson="H", Address="k" };
            var secondCompany = new Company { Id = 2, Name = "Просперитет", Bulstat = "BG909087356" , AccountablePerson= "Y", Address="ko"};
            var thirdCompany = new Company { Id = 3, Name = "Тотал Щета", Bulstat = "903099066", AccountablePerson="opk", Address="top" };
            await db.Companies.AddRangeAsync(firstCompany, secondCompany, thirdCompany);
            await db.SaveChangesAsync();
            var companyService = new CompaniesService(db, mapper);

            var result = await companyService.EditAsync(2,"Ръст", "090987134","Мария","Бусманци 67");
            var editedCompany = await db.Companies.FindAsync(2);

            result
                .Should()
                .BeTrue();

            editedCompany
                .Should()
                .BeOfType<Company>()
                .And
                .Match<Company>(c => c.Name== "Ръст"
                    && c.Bulstat== "090987134"
                    && c.AccountablePerson== "Мария"
                    && c.Address== "Бусманци 67");
        }

        [Fact]
        public async Task EditAsync_SouldReturn_False_IfCompanyDonotExists()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstCompany = new Company { Id = 1, Name = "Свеплина", Bulstat = "903097356", AccountablePerson = "H", Address = "k" };
            var secondCompany = new Company { Id = 2, Name = "Просперитет", Bulstat = "BG909087356", AccountablePerson = "Y", Address = "ko" };
            var thirdCompany = new Company { Id = 3, Name = "Тотал Щета", Bulstat = "903099066", AccountablePerson = "opk", Address = "top" };
            await db.Companies.AddRangeAsync(firstCompany, secondCompany, thirdCompany);
            await db.SaveChangesAsync();
            var companyService = new CompaniesService(db, mapper);

            var result = await companyService.EditAsync(4, "Ръст", "090987134", "Мария", "Бусманци 67");
            var editedCompany = await db.Companies.FindAsync(4);

            result
                .Should()
                .BeFalse();

            editedCompany
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task GetAsync_SouldReturn_CorrectModel_IfCompanyExists()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstCompany = new Company { Id = 1, Name = "Свеплина", Bulstat = "903097356", AccountablePerson = "H", Address = "k" };
            var secondCompany = new Company { Id = 2, Name = "Просперитет", Bulstat = "BG909087356", AccountablePerson = "Y", Address = "ko" };
            var thirdCompany = new Company { Id = 3, Name = "Тотал Щета", Bulstat = "903099066", AccountablePerson = "opk", Address = "top" };
            await db.Companies.AddRangeAsync(firstCompany, secondCompany, thirdCompany);
            await db.SaveChangesAsync();
            var companyService = new CompaniesService(db, mapper);

            var result = await companyService.GetAsync(2);

            result
                .Should()
                .BeOfType<CompanyDetailsModel>()
                .And
                .Match<CompanyDetailsModel>(c=>c.AccountablePerson== "Y"
                    && c.Address=="ko"
                    && c.Bulstat == "BG909087356"
                    && c.Name == "Просперитет");
           
        }

        [Fact]
        public async Task GetAsync_SouldReturn_Null_IfCompanyDoNotExists()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstCompany = new Company { Id = 1, Name = "Свеплина", Bulstat = "903097356", AccountablePerson = "H", Address = "k" };
            var secondCompany = new Company { Id = 2, Name = "Просперитет", Bulstat = "BG909087356", AccountablePerson = "Y", Address = "ko" };
            var thirdCompany = new Company { Id = 3, Name = "Тотал Щета", Bulstat = "903099066", AccountablePerson = "opk", Address = "top" };
            await db.Companies.AddRangeAsync(firstCompany, secondCompany, thirdCompany);
            await db.SaveChangesAsync();
            var companyService = new CompaniesService(db, mapper);

            var result = await companyService.GetAsync(4);

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
