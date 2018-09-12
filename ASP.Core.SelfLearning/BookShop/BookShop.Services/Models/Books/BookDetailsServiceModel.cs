using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Services.Models.Books
{
    using Author;
    using AutoMapper;
    using BookShop.Common.Mapping;
    using BookShop.Data.Models;
    using System.Linq;

    public class BookDetailsServiceModel 
        : BookWithCategoriesServiceModel, IMapFrom<Book>, IHaveCustomMapping
    {
        public string Author { get; set; }

        public override void ConfigureMapping(Profile mapper)        
            => mapper.CreateMap<Book, BookDetailsServiceModel>()
            .ForMember(b => b.Categories, cfg => cfg
                  .MapFrom(b => b.Categories
                    .Select(c => c.Category.Name)))
            .ForMember(b=>b.Author, cfg=>cfg
                  .MapFrom(b=>b.Author.FirstName+" "+b.Author.LastName));
        
    }
}
