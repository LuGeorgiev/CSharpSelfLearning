
namespace BookShop.Services.Models.Author
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;

    public class AuthorDetailServiceModel : IMapFrom<Author>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<string> Books { get; set; }

        public void ConfigureMapping(Profile mapper)
        => mapper
            .CreateMap<Author, AuthorDetailServiceModel>()
            .ForMember(a => a.Books, cfg => cfg
                .MapFrom(a => a.Books
                    .Select(b => b.Title)));
    }
}
