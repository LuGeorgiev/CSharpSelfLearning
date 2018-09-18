namespace LearningSysem.Test.Web.Controllers
{
    using FluentAssertions;
    using LearningSystem.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using System.Linq;
    using Moq;
    using System.Threading.Tasks;
    using Xunit;
    using LearningSystem.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using LearningSystem.Services;
    using LearningSystem.Services.Models;
    using LearningSysem.Test.Mocks;

    public class UserControllerTest
    {
        [Fact]
        public void DownloadCertificateSouldBeForAuthorizedUsers()
        {
            //Arrange
            var method = typeof(UsersController)
                .GetMethod(nameof(UsersController.DownloadCertificate));

            //Act
            var attributes = method
                .GetCustomAttributes(true);

            //Assert
            attributes
                .Should()
                .Match(attr => attr.Any(a => a.GetType() == typeof(AuthorizeAttribute)));
        }

        [Fact]
        public async Task ProfileShouldReturNotFoundWithInvalidUserName()
        {
            //Arrange
            var userManager = UserManagerMock.New;
            var controller = new UsersController(null, userManager.Object);

            //Act
            var result = await controller.Profile("Username");

            //Assert
            result
                .Should()
                .BeOfType<NotFoundResult>();
        
        }

        [Fact]
        public async Task ProfileShouldReturnViewWithVCorrectModelWithUsername()
        {
            //Arrange
            const string userId = "SomeId";
            const string userName = "Username";

            var userManager = UserManagerMock.New;

            userManager
                .Setup(u => u.FindByNameAsync(It.IsAny<string>())) //every time returns fake
                .ReturnsAsync(new User { Id= userId });

            var userService = new Mock<IUserService>();
            userService
                .Setup(u => u.ProfileAsync(It.Is<string>(id=>id==userId))) //returns someUsername only if userId is teh input
                .ReturnsAsync(new UserProfileServiceModel { UserName = userName });

            var controller = new UsersController(userService.Object, userManager.Object);

            //Act
            var result = await controller.Profile(userName);

            //Assert
            result.Should()
                .BeOfType<ViewResult>()
                .Subject
                .Model
                .Should()
                .Match(m => m.As<UserProfileServiceModel>().UserName == userName);
        }

        // TO BE used as static property 
        //private Mock<UserManager<User>> GetUserManagerMock()
        //    =>new Mock<UserManager<User>>(
        //        Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
        
    }
}
