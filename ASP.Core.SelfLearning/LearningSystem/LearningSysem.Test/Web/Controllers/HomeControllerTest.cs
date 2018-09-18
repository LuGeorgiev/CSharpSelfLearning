using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSysem.Test.Web.Controllers
{
    using Xunit;
    using FluentAssertions;
    using LearningSystem.Web.Controllers;
    using System.Threading.Tasks;
    using LearningSystem.Web.Models.Home;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using LearningSystem.Services;
    using LearningSystem.Services.Models;
    using System.Linq;

    public class HomeControllerTest
    {
        [Fact]
        public async Task SearchShouldReturnNoResultWithNoCriteria()
        {
            //Arrange
            var controller = new HomeController(null, null);

            //Act
            var result = await controller.Search(new SearchFormModel
            {
                 SearchInCourses=false,
                 SearchInUsers=false
            });

            //Assert

            result.Should().BeOfType<ViewResult>();
            result.As<ViewResult>().Model.Should().BeOfType<SearchViewModel>();
            var searchViewModel = result.As<ViewResult>().Model.As<SearchViewModel>();

            searchViewModel.Courses.Should().BeEmpty();
            searchViewModel.Users.Should().BeEmpty();
            searchViewModel.SearchedText.Should().BeNull();
        }

        [Fact]
        public async Task SearchShouldReturnViewWithValidModelWhenCoursesAreFilterd()
        {
            //Arrange
            const string searchedText = "text";
            var couresService = new Mock<ICourseService>();
            couresService.Setup(c => c.FindAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<CourseListingServiceModel>()
                {
                    new CourseListingServiceModel {Id=10 }
                });

            var controller = new HomeController(couresService.Object, null);

            //Act
            var result = await controller.Search(new SearchFormModel
            {
                SearchInCourses = true,
                SearchInUsers = false,
                SearchText=searchedText
            });

            //Assert

            result.Should().BeOfType<ViewResult>();

            result.As<ViewResult>().Model.Should().BeOfType<SearchViewModel>();
            var searchViewModel = result.As<ViewResult>().Model.As<SearchViewModel>();

            searchViewModel.Courses.Should().Match(c=>c.As<List<CourseListingServiceModel>>().Count==1);
            searchViewModel.Courses.First().Should().Match(c=>c.As<CourseListingServiceModel>().Id==10);
            searchViewModel.Users.Should().BeEmpty();
            searchViewModel.SearchedText.Should().Be(searchedText);
        }
    }
}
