using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Services.Implementation;
using EstateManagment.Services.Models.Clients;
using EstateManagment.Web.Common.Mapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EstateManagment.Services.Tests
{
    public class ClientsServiceTests
    {
        [Fact]
        public async Task AllAsync_SouldReturn_EmptyCollection_IfNoDeletedUsersInDb()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstClient = new Client { Id = 1, Name = "Zahari", IsDeleted = false };
            var secondClient = new Client { Id = 2, Name = "Asen", IsDeleted = false };
            var thirdClient = new Client { Id = 3, Name = "Parkash", IsDeleted = false };
            await db.Clients.AddRangeAsync(firstClient, secondClient, thirdClient);
            await db.SaveChangesAsync();
            var clientService = new ClientsService(db, mapper);

            bool isDeleted = true;
            var result = await clientService.AllAsync(isDeleted);

            result.Should()
                .BeEmpty()
                .And
                .HaveCount(0);
        }

        [Fact]
        public async Task AllAsync_SouldReturn_CollectionWithThreeClientsOrdered_IfThreeActiveClientsInDb()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstClient = new Client { Id = 1, Name = "Zahari", IsDeleted = false };
            var secondClient = new Client { Id = 2, Name = "Asen", IsDeleted = false };
            var thirdClient = new Client { Id = 3, Name = "Parkash", IsDeleted = false };
            await db.Clients.AddRangeAsync(firstClient, secondClient, thirdClient);
            await db.SaveChangesAsync();
            var clientService = new ClientsService(db, mapper);

            bool isDeleted = false;
            var result = await clientService.AllAsync(isDeleted);

            result.Should()
                .NotBeEmpty()
                .And
                .HaveCount(3)
                .And
                .Match(c =>
                    c.ElementAt(0).Name == "Asen"
                    && c.ElementAt(2).Name == "Zahari");
        }

        [Fact]
        public async Task AllAsync_SouldReturn_CollectionWithFilteredClients_IfThereAreActiveAndNotActive()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstClient = new Client { Id = 1, Name = "Zahari", IsDeleted = false };
            var secondClient = new Client { Id = 2, Name = "Asen", IsDeleted = true };
            var thirdClient = new Client { Id = 3, Name = "Parkash", IsDeleted = false };
            await db.Clients.AddRangeAsync(firstClient, secondClient, thirdClient);
            await db.SaveChangesAsync();
            var clientService = new ClientsService(db, mapper);

            bool isDeleted = false;
            var result = await clientService.AllAsync(isDeleted);

            result.Should()
                .NotBeEmpty()
                .And
                .HaveCount(2)
                .And
                .Match(c =>
                    c.ElementAt(0).Name == "Parkash"
                    && c.ElementAt(1).Name == "Zahari");
        }

        [Fact]
        public async Task CreateAsync_ShouldReturn_True_IfInputDataIsCorrect()
        {
            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var clientService = new ClientsService(db, mapper);

            const string name = "Петров 96";
            const string address = "София Младост 6";
            const string bulstat = "BG063698652";
            const string EGN = "9865321455";
            const string acountableName = "Иван Петров";
            const string contactName = "Иван Петров";
            const string telephone = "0895 69 32 14";
            const string notes = "без забележки";

            //Act
            var result = await clientService.CreateAsync(name, address, bulstat, EGN, acountableName, contactName, telephone, notes);

            var savedEntry = await db.Clients.FirstOrDefaultAsync(x => x.Name == "Петров 96");

            //Assert
            result
                .Should()
                .BeTrue();

            savedEntry
                .Should()
                .NotBeNull();
        }

        [Fact]
        public async Task EditAsync_ShouldReturn_True_AfterEntytyISEdited()
        {
            var db = this.GetDatabase();
            var mapper = this.GetMapper();


            var client = new Client
            {
                Name = "Петров 96",
                Address = "София Младост 6",
                Bulstat = "BG063698652",
                EGN = "9865321455",
                AccountableName = "Иван Петров",
                ContactName = "Иван Петров",
                Telephone = "0895 69 32 14",
                Notes = "без забележки",
                IsDeleted = false
            };
            await db.Clients.AddAsync(client);
            await db.SaveChangesAsync();
            var clientService = new ClientsService(db, mapper);
            //Act
            var result = await clientService.EditAsync(1, "Иван NEW", "София 6 NEW", "Иван Петров", "9865321455", false, "Петров 96", "без забележки", "0895 69 32 14");

            var savedEntry = await db.Clients.FirstOrDefaultAsync(x => x.Name == "Петров 96");

            //Assert
            result
                .Should()
                .BeTrue();

            savedEntry
                .Should()
                .NotBeNull();

            savedEntry
                .Should()
                .BeOfType<Client>();

            savedEntry
                .Should()
                .Match<Client>(x => x.AccountableName == "Иван NEW"
                    && x.Address == "София 6 NEW"
                    && x.Telephone == "0895 69 32 14");


        }

        [Fact]
        public async Task EditAsync_ShouldReturn_False_IfClientDoNotExists()
        {
            var db = this.GetDatabase();
            var mapper = this.GetMapper();


            var client = new Client
            {
                Name = "Петров 96",
                Address = "София Младост 6",
                Bulstat = "BG063698652",
                EGN = "9865321455",
                AccountableName = "Иван Петров",
                ContactName = "Иван Петров",
                Telephone = "0895 69 32 14",
                Notes = "без забележки",
                IsDeleted = false
            };
            await db.Clients.AddAsync(client);
            await db.SaveChangesAsync();
            var clientService = new ClientsService(db, mapper);
            //Act

            var result = await clientService.EditAsync(2, "Иван NEW", "София 6 NEW", "Иван Петров", "9865321455", false, "Петров 96", "без забележки", "0895 69 32 14");

            var savedEntry = await db.FindAsync<Client>(2);

            //Assert
            result
                .Should()
                .BeFalse();

            savedEntry
                .Should()
                .BeNull();


        }

        [Fact]
        public async Task GetAsync_ShouldReturn_CorrectClient_IfClientExist()
        {
            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstClient = new Client { Id = 1, Name = "Zahari" };
            var secondClient = new Client { Id = 2, Name = "Asen" };
            var thirdClient = new Client { Id = 3, Name = "Parkash" };
            await db.Clients.AddRangeAsync(firstClient, secondClient, thirdClient);
            await db.SaveChangesAsync();
            var clientService = new ClientsService(db, mapper);

            var result = await clientService.GetAsync(2);

            //Assert
            result
                .Should()
                .NotBeNull()
                .And
                .Match<ClientViewModel>(x => x.Name == "Asen");
        }

        [Fact]
        public async Task GetAsync_ShouldReturn_Null_IfClientDoNotExists()
        {
            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstClient = new Client { Id = 1, Name = "Zahari" };
            var secondClient = new Client { Id = 2, Name = "Asen" };
            var thirdClient = new Client { Id = 3, Name = "Parkash" };
            await db.Clients.AddRangeAsync(firstClient, secondClient, thirdClient);
            await db.SaveChangesAsync();
            var clientService = new ClientsService(db, mapper);

            var result = await clientService.GetAsync(4);

            //Assert
            result
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task GetIdByNameAsync_ShouldReturn_CorrectId_IfClientExists()
        {
            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstClient = new Client { Id = 1, Name = "Zahari" };
            var secondClient = new Client { Id = 2, Name = "Asen" };
            var thirdClient = new Client { Id = 3, Name = "Parkash" };
            await db.Clients.AddRangeAsync(firstClient, secondClient, thirdClient);
            await db.SaveChangesAsync();
            var clientService = new ClientsService(db, mapper);

            var result = await clientService.GetIdByNameAsync("Parkash");

            //Assert
            result
                .Should()
                .Equals(3);
        }

        [Fact]
        public async Task GetIdByNameAsync_ShouldReturn_Zero_IfClientDoNotExists()
        {
            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstClient = new Client { Id = 1, Name = "Zahari" };
            var secondClient = new Client { Id = 2, Name = "Asen" };
            var thirdClient = new Client { Id = 3, Name = "Parkash" };
            await db.Clients.AddRangeAsync(firstClient, secondClient, thirdClient);
            await db.SaveChangesAsync();
            var clientService = new ClientsService(db, mapper);

            var result = await clientService.GetIdByNameAsync("Iva");

            //Assert
            result
                .Should()
                .Equals(0);
        }


        [Fact]
        public async Task RessurectAsync_SouldReturn_True_ClientExistsAndWasDeleted()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstClient = new Client { Id = 1, Name = "Zahari", IsDeleted = false };
            var secondClient = new Client { Id = 2, Name = "Asen", IsDeleted = true };
            var thirdClient = new Client { Id = 3, Name = "Parkash", IsDeleted = true };
            await db.Clients.AddRangeAsync(firstClient, secondClient, thirdClient);
            await db.SaveChangesAsync();
            var clientService = new ClientsService(db, mapper);
                        
            var result = await clientService.ResurectAsync(3);

            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public async Task RessurectAsync_SouldReturn_False_ClientExistsButNotDeleted()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstClient = new Client { Id = 1, Name = "Zahari", IsDeleted = false };
            var secondClient = new Client { Id = 2, Name = "Asen", IsDeleted = true };
            var thirdClient = new Client { Id = 3, Name = "Parkash", IsDeleted = true };
            await db.Clients.AddRangeAsync(firstClient, secondClient, thirdClient);
            await db.SaveChangesAsync();
            var clientService = new ClientsService(db, mapper);

            var result = await clientService.ResurectAsync(1);

            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public async Task RessurectAsync_SouldReturn_False_IfClientDoNotExists()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstClient = new Client { Id = 1, Name = "Zahari", IsDeleted = false };
            var secondClient = new Client { Id = 2, Name = "Asen", IsDeleted = true };
            var thirdClient = new Client { Id = 3, Name = "Parkash", IsDeleted = true };
            await db.Clients.AddRangeAsync(firstClient, secondClient, thirdClient);
            await db.SaveChangesAsync();
            var clientService = new ClientsService(db, mapper);

            var result = await clientService.ResurectAsync(4);

            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public async Task GetDetailsAsync_ShouldReturnAllDetails_IfClientExists()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstClient = new Client { Id = 1, Name = "Zahari"};
            var secondClient = new Client { Id = 2, Name = "Asen" };
            var thirdClient = new Client { Id = 3, Name = "Parkash" };
            await db.Clients.AddRangeAsync(firstClient, secondClient, thirdClient);
            await db.SaveChangesAsync();
            var clientService = new ClientsService(db, mapper);

            var result = await clientService.GetDetailsAsync(3);
 
            result
                .Should()
                .BeOfType<ClientDetailsModel>()
                .And
                .Match<ClientDetailsModel>(x=>x.Name== "Parkash");
        }

        [Fact]
        public async Task GetDetailsAsync_ShouldReturnNull_IfClientDoNotExists()
        {

            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstClient = new Client { Id = 1, Name = "Zahari" };
            var secondClient = new Client { Id = 2, Name = "Asen" };
            var thirdClient = new Client { Id = 3, Name = "Parkash" };
            await db.Clients.AddRangeAsync(firstClient, secondClient, thirdClient);
            await db.SaveChangesAsync();
            var clientService = new ClientsService(db, mapper);

            var result = await clientService.GetDetailsAsync(4);

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
            var config = new MapperConfiguration(cfg=> 
            {
                cfg.AddProfile(new MappingProfile());
            });

            return config.CreateMapper();
        }
    }
}
