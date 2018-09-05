
namespace LearningSystem.Services.Blog.Models
{
    using Common.Mapping;
    using Data.Models;
    using System.ComponentModel.DataAnnotations;
    using System;

    using static Data.DataConstants;
    using AutoMapper;

    public class BlogArticleListingServiceModel :IMapFrom<Article>,IHaveCustomMapping
    {
        public int Id { get; set; }
              
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublisheDate { get; set; }

        public string Author { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
            .CreateMap<Article, BlogArticleListingServiceModel>()
            .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
    }
}
