using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Services.Implementation;
using EstateManagment.Services.Models.Users;
using EstateManagment.Services.Tests.Mocks;
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
    public class UsersServiceTests
    {
        [Fact]
        public async Task AllNonAdminsAsync_ShouldReturn_AllUsersThatAreNotAdmins_ExcludingLogged()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var userMnager = UserManagerMock.New;

            var firstUser = new User { Id = "1", UserName = "first" };
            var secondUser = new User { Id = "2", UserName = "second" };
            var thirdUser = new User { Id = "3", UserName = "third" };
            var forthUser = new User { Id = "4", UserName = "forth" };
            var fifthUser = new User { Id = "5", UserName = "fifth" };
            await db.Users.AddRangeAsync(firstUser,secondUser,thirdUser,forthUser,fifthUser);
            await db.SaveChangesAsync();

            userMnager
                .Setup(u => u.GetUsersInRoleAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<User>()
                {
                    firstUser,
                    secondUser
                });

            var userService = new UsersService(mapper, db, userMnager.Object);
            //Act
            var result = await userService.AllNonAdminsAsync("3");
            //Assert
            result
                .Should()
                .NotBeNullOrEmpty()
                .And
                .HaveCount(2)
                .And
                .Match(u => u.ElementAt(0).Id == "4"
                    && u.ElementAt(1).Username == "fifth");

        }

        [Fact]
        public async Task GetUserAsync_ShouldReturn_CorrectUser_IfExistInDb()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var userMnager = UserManagerMock.New;

            var firstUser = new User { Id = "1", UserName = "first" };
            var secondUser = new User { Id = "2", UserName = "second" };
            var thirdUser = new User { Id = "3", UserName = "third" };
            var forthUser = new User { Id = "4", UserName = "forth" };
            var fifthUser = new User { Id = "5", UserName = "fifth" };
            await db.Users.AddRangeAsync(firstUser, secondUser, thirdUser, forthUser, fifthUser);
            await db.SaveChangesAsync();
                     
            var userService = new UsersService(mapper, db, userMnager.Object);
            //Act
            var result = await userService.GetUserAsync("4");
            //Assert
            result
                .Should()
                .BeOfType<User>()
                .And
                .Match<User>(u => u.UserName == "forth");

        }

        [Fact]
        public async Task GetUserAsync_ShouldReturn_Null_IfUserDoNotExistInDb()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var userMnager = UserManagerMock.New;

            var firstUser = new User { Id = "1", UserName = "first" };
            var secondUser = new User { Id = "2", UserName = "second" };
            var thirdUser = new User { Id = "3", UserName = "third" };
            var forthUser = new User { Id = "4", UserName = "forth" };
            var fifthUser = new User { Id = "5", UserName = "fifth" };
            await db.Users.AddRangeAsync(firstUser, secondUser, thirdUser, forthUser, fifthUser);
            await db.SaveChangesAsync();

            var userService = new UsersService(mapper, db, userMnager.Object);
            //Act
            var result = await userService.GetUserAsync("6");
            //Assert
            result
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task GetUserWithRolesAsyn_ShouldReturn_UserWithAllRoles_IfUserExists()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var userMnager = UserManagerMock.New;

            var firstUser = new User { Id = "1", UserName = "first" };
            var secondUser = new User { Id = "2", UserName = "second" };
            var thirdUser = new User { Id = "3", UserName = "third" };
            var forthUser = new User { Id = "4", UserName = "forth" };
            var fifthUser = new User { Id = "5", UserName = "fifth" };
            await db.Users.AddRangeAsync(firstUser, secondUser, thirdUser, forthUser, fifthUser);
            await db.SaveChangesAsync();

            userMnager
                .Setup(u => u.GetRolesAsync(It.IsAny<User>()))
                .ReturnsAsync(new List<string>()
                {
                    "Manager",
                    "Superman"
                });

            var userService = new UsersService(mapper, db, userMnager.Object);
            //Act
            var result = await userService.GetUserWithRolesAsync("3");
            //Assert
            result
                .Should()
                .BeOfType<UserInfoModel>()
                .And                
                .Match<UserInfoModel>(u =>u.Roles.Any(x=>x== "Superman") );

        }

        [Fact]
        public async Task GetUserWithRolesAsyn_ShouldReturn_Null_IfUserDoNotExists()
        {
            var db = GetDatabase();
            var mapper = GetMapper();
            var userMnager = UserManagerMock.New;

            var firstUser = new User { Id = "1", UserName = "first" };
            var secondUser = new User { Id = "2", UserName = "second" };
            var thirdUser = new User { Id = "3", UserName = "third" };
            var forthUser = new User { Id = "4", UserName = "forth" };
            var fifthUser = new User { Id = "5", UserName = "fifth" };
            await db.Users.AddRangeAsync(firstUser, secondUser, thirdUser, forthUser, fifthUser);
            await db.SaveChangesAsync();

            userMnager
                .Setup(u => u.GetRolesAsync(It.IsAny<User>()))
                .ReturnsAsync(new List<string>()
                {
                    "Manager",
                    "Superman"
                });

            var userService = new UsersService(mapper, db, userMnager.Object);
            //Act
            var result = await userService.GetUserWithRolesAsync("6");
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
