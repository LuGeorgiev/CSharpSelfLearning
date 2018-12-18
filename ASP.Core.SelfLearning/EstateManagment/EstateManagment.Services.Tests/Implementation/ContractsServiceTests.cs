using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Services.Implementation;
using EstateManagment.Web.Common.Mapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EstateManagment.Services.Tests.Implementation
{
    public class ContractsServiceTests
    {

        [Fact]
        public async Task DeleteAsync_ShouldReturn_True_IfContractExistsAndNotDeleted()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstContract = new Contract { Id = 1, IsDeleted=false, ScannedContract = new byte[] { 123 } };
            var secondContract = new Contract { Id = 2, IsDeleted = false, ScannedContract = new byte[] { 1 } };
            var thirdContract = new Contract { Id = 3, IsDeleted=false, ScannedContract = new byte[] { 34 } };

            await db.Contracts.AddRangeAsync(firstContract, secondContract, thirdContract);
            await db.SaveChangesAsync();
            var contractService = new ContractsService( mapper, db);

            var result = await contractService.DeleteAsync(2);
            var deletedContract = await db.Contracts.FindAsync(2);

            result
                .Should()
                .BeTrue();


            deletedContract
                .Should()
                .BeOfType<Contract>()
                .And
                .Match<Contract>(c => c.IsDeleted == true);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturn_False_IfContractDoNotExists()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstContract = new Contract { Id = 1, IsDeleted = false, ScannedContract = new byte[] { 123 } };
            var secondContract = new Contract { Id = 2, IsDeleted = false, ScannedContract = new byte[] { 1 } };
            var thirdContract = new Contract { Id = 3, IsDeleted = false, ScannedContract = new byte[] { 34 } };

            await db.Contracts.AddRangeAsync(firstContract, secondContract, thirdContract);
            await db.SaveChangesAsync();
            var contractService = new ContractsService(mapper, db);

            var result = await contractService.DeleteAsync(4);
            var deletedContract = await db.Contracts.FindAsync(4);

            result
                .Should()
                .BeFalse();

            deletedContract
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task DownloadAsync_ShouldReturn_Null_IfContractDoNotExists()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstContract = new Contract { Id = 1, IsDeleted = false, ScannedContract = new byte[] { 123 } };
            var secondContract = new Contract { Id = 2, IsDeleted = false, ScannedContract = new byte[] { 1 } };
            var thirdContract = new Contract { Id = 3, IsDeleted = false, ScannedContract = new byte[] { 34 } };

            await db.Contracts.AddRangeAsync(firstContract, secondContract, thirdContract);
            await db.SaveChangesAsync();
            var contractService = new ContractsService(mapper, db);

            var result = await contractService.DownloadAsync(4);

            result
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task DownloadAsync_ShouldReturn_CorrectByteArray_IfContractExists()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var firstContract = new Contract { Id = 1, IsDeleted = false, ScannedContract = new byte[] { 123 } };
            var secondContract = new Contract { Id = 2, IsDeleted = false, ScannedContract = new byte[] { 1 } };
            var thirdContract = new Contract { Id = 3, IsDeleted = false, ScannedContract = new byte[] { 34 } };

            await db.Contracts.AddRangeAsync(firstContract, secondContract, thirdContract);
            await db.SaveChangesAsync();
            var contractService = new ContractsService(mapper, db);

            var result = await contractService.DownloadAsync(1);
            var scandContract = new byte[] { 123 };

            result
                .Should()
                .BeOfType<byte[]>()
                .And
                .Match<byte[]>(c=>c.Length==scandContract.Length);
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
