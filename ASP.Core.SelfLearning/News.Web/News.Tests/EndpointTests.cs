namespace News.Tests
{
    using Data;
    using Data.Models;
    using Web.Controllers;
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Xunit;
    using System.Globalization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class EndpointTests
    {
        private NewsDbContext Context
        {
            get
            {
                var dbOptions = new DbContextOptionsBuilder<NewsDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new NewsDbContext(dbOptions);
            }
        }

        [Fact]
        public void NewsControllerGetAllNewsShould_ReturnOkStatusCode()
        {
            var db = this.Context;
            this.PopulateData(db);
            var newsController = new NewsController(db);

            Assert.IsType<OkObjectResult>( newsController.GetAllNews());
        }

        [Fact]
        public void NewsControllerGetAllNewsShould_ReturnCorrectData()
        {
            var db = this.Context;
            this.PopulateData(db);
            var newsController = new NewsController(db);

            var returnedData = (newsController.GetAllNews() as OkObjectResult).Value as IEnumerable<News>;
            var testData = this.GetTestData();

            foreach (var returnedModel in returnedData)
            {
                var testModel = testData.FirstOrDefault(n => n.Id == returnedModel.Id);
                Assert.NotNull(testModel);
                Assert.True(this.CompareNewsExact(returnedModel, testModel));
            }
        }

        [Fact]
        public void NewsControllerPostNewsWithCorrectDataShould_ReturnCreatedStatusCode()
        {
            var db = this.Context;            
            var newsController = new NewsController(db);
            var testModel = this.GetTestData().First();

            //Act and assert
            Assert.IsType<CreatedAtActionResult>(newsController.PostNews(testModel));
        }

        [Fact]
        public void NewsControllerPostNewsWithCorrectDataShould_ReturnCreatedSNews()
        {
            var db = this.Context;
            var newsController = new NewsController(db);

            //Act
            var testModel = this.GetTestData().First();
            var returnedModel = (newsController.PostNews(testModel) as CreatedAtActionResult).Value as News;

            //Act and assert
            Assert.True(this.CompareNewsExact(returnedModel,testModel));
        }

        [Fact]
        public void NewsControllerPostNewsWithIncorrectDataShould_ReturnBadRequestStatusCode()
        {
            var db = this.Context;
            var newsController = new NewsController(db);

            //Act
            var testModel = this.GetTestData().First();
            testModel.Title = null;
            newsController.ModelState.AddModelError("InvalidData", "InvalidData");

            //Act and assert
            Assert.IsType<BadRequestObjectResult>(newsController.PostNews(testModel));
        }

        private IEnumerable<News> GetTestData()
        {
            return new List<News>()
            {
                new News {Id=1, Title="Something", Content="Big Sth", PublishedDate= DateTime.ParseExact("05/06/2017", "dd/MM/yyyy",CultureInfo.InvariantCulture) },
                new News {Id=2, Title="Nothing", Content="Little Sth", PublishedDate= DateTime.ParseExact("07/11/2017", "dd/MM/yyyy",CultureInfo.InvariantCulture) },
                new News {Id=3, Title="No news", Content="No Sth", PublishedDate= DateTime.ParseExact("12/01/2011", "dd/MM/yyyy",CultureInfo.InvariantCulture) },
                new News {Id=4, Title="C# is cool", Content="Any Sth", PublishedDate= DateTime.ParseExact("17/11/2013", "dd/MM/yyyy",CultureInfo.InvariantCulture) },
            };
            
        }

        private void PopulateData(NewsDbContext db)
        {
            db.News.AddRange(this.GetTestData());
            db.SaveChanges();
        }

        private bool CompareNewsExact(News thisNews, News otherNews)
            => thisNews.Id == otherNews.Id
            && thisNews.Title == otherNews.Title
            && thisNews.Content == otherNews.Content
            && thisNews.PublishedDate == otherNews.PublishedDate;
    }
}
