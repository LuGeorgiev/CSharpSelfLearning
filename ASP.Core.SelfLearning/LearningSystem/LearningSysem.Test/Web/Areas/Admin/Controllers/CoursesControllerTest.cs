namespace LearningSysem.Test.Web.Areas.Admin.Controllers
{
    using FluentAssertions;
    using LearningSystem.Web;
    using LearningSystem.Web.Areas.Admin.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using Xunit;
    using Mocks;
    using Moq;
    using LearningSystem.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using LearningSystem.Web.Areas.Admin.Models.Courses;
    using System;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Identity;
    using LearningSystem.Services.Admin;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;

    public class CoursesControllerTest
    {
        private const string FirstUserId = "1";
        private const string SecondUserId = "2";
        private const string FirstUserName = "First";
        private const string SecondtUserName = "Second";

        [Fact]
        public void CoursesControllerShouldBeInAdminArea()
        {
            //Arrange
            var controller = typeof(CoursesController);

            //Act
            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AreaAttribute))
                as AreaAttribute;

            //Assert
            areaAttribute.Should().NotBeNull();
            areaAttribute.RouteValue.Should().Be(WebConstants.AdminArea);
        }

        [Fact]
        public void CoursesControllerShouldBeOnlyForAdminUsers()
        {
            //Arrange
            var controller = typeof(CoursesController);

            //Act
            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AuthorizeAttribute))
                as AuthorizeAttribute;

            //Assert
            areaAttribute.Should().NotBeNull();
            areaAttribute.Roles.Should().Be(WebConstants.AdministratorRole);
        }

        [Fact]
        public async Task GetCreateShouldReturnViewWithCorrectModel()
        {
            //A
            var userManager = this.GetUserManagerMock();
            var controller = new CoursesController(userManager.Object, null);

            //Act
            var result = await controller.Create();

            //Assert
            result
                .Should()
                .BeOfType<ViewResult>();

            var model = result.As<ViewResult>().Model;
            model.Should()
                .BeOfType<AddCourseFormModel>();

            var formModel = model.As<AddCourseFormModel>();

            formModel.StartDate.Year.Should().Be(DateTime.UtcNow.Year);
            formModel.StartDate.Month.Should().Be(DateTime.UtcNow.Month);
            formModel.StartDate.Day.Should().Be(DateTime.UtcNow.Day);

            var endDate = DateTime.UtcNow.AddDays(30);
            formModel.EndDate.Year.Should().Be(endDate.Year);
            formModel.EndDate.Month.Should().Be(endDate.Month);
            formModel.EndDate.Day.Should().Be(endDate.Day);
            
            this.AssertTrainersSelectList(formModel.Trainers);
        }

        [Fact]
        public async Task PostCreatShouldReturnViewWithCorrectModellWhenPostModelIsInvalid()
        {
            //Arrange
            var userManager = this.GetUserManagerMock();
            var controller = new CoursesController(userManager.Object, null);
            controller.ModelState.AddModelError(string.Empty, "Error");

            //Act
            var result = await controller.Create(new AddCourseFormModel());

            //Assert
            result
              .Should()
              .BeOfType<ViewResult>();

            var model = result.As<ViewResult>().Model;
            model.Should()
                .BeOfType<AddCourseFormModel>();

            var formModel = model.As<AddCourseFormModel>();
            this.AssertTrainersSelectList(formModel.Trainers);
        }

        [Fact]
        public async Task PostCreateShouldReturnRedirectWithValidModel()
        {
            //Arrange
            const string nameValue = "Name";
            const string descriptionValue = "Description";
            var startDateValue = new DateTime(2000, 12, 10);
            var endDateValue = new DateTime(2000, 12, 15);
            const string trainerIdValue = "1";

            string modelName =null;
            string modeldescription = null;
            DateTime modelStartDate=DateTime.UtcNow;
            DateTime modelEndDate=DateTime.UtcNow;
            string modelTrainerId = null;
            string successMessage = null;

            var adminCourseService = new Mock<IAdminCourseService>();
            adminCourseService
                .Setup(c => c.CreateAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>(),
                    It.IsAny<string>()))
                .Callback((string name, string description, DateTime startDate, DateTime endDate, string trainerId)=>
                {
                    modelName = name;
                    modeldescription = description;
                    modelStartDate = startDate;
                    modelEndDate = endDate;
                    modelTrainerId = trainerId;
                })
                .Returns(Task.CompletedTask);

            var tempData = new Mock<ITempDataDictionary>();
            tempData.SetupSet(t => t[WebConstants.TempDataSuccessMsgKey]= It.IsAny<string>())
                .Callback((string key, object message)=>successMessage=message as string);

            var controller = new CoursesController(null, adminCourseService.Object);
            controller.TempData = tempData.Object;

            //Act
            var result = await controller.Create(new AddCourseFormModel
            {
                Name=nameValue,
                Description=descriptionValue,
                StartDate = startDateValue,
                EndDate = endDateValue,
                TrainerId=trainerIdValue
            });

            //Assert
            modelName.Should().Be(nameValue);
            modeldescription.Should().Be(descriptionValue);
            modelStartDate.Should().Be(startDateValue);
            modelEndDate.Should().Be(endDateValue.AddDays(1));
            modelTrainerId.Should().Be(trainerIdValue);

            successMessage.Should().Be($"Coures {nameValue} created successfully!");

            result.Should().BeOfType<RedirectToActionResult>();

            result.As<RedirectToActionResult>().ActionName.Should().Be("Index");
            result.As<RedirectToActionResult>().ControllerName.Should().Be("Home");
            result.As<RedirectToActionResult>().RouteValues.Keys.Should().Contain("area");
            result.As<RedirectToActionResult>().RouteValues.Values.Should().Contain(string.Empty);
        }

        private Mock<UserManager<User>> GetUserManagerMock()
        {
            var userManager = UserManagerMock.New;
            userManager
                .Setup(u => u.GetUsersInRoleAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<User>
                {
                    new User{ Id=FirstUserId, UserName=FirstUserName},
                    new User{ Id=SecondUserId, UserName=SecondtUserName }
                });

            return userManager;
        }

        private void AssertTrainersSelectList(IEnumerable<SelectListItem> trainers)
        {
            trainers
                .Should()
                .Match(items => items.Count() == 2);
            trainers
                .First().Should().Match(u => u.As<SelectListItem>().Value == FirstUserId);
            trainers
                .First().Should().Match(u => u.As<SelectListItem>().Text ==FirstUserName);
            trainers
                .Last().Should().Match(u => u.As<SelectListItem>().Value == SecondUserId);
            trainers
                .Last().Should().Match(u => u.As<SelectListItem>().Text == SecondtUserName);
        }
    }
}
