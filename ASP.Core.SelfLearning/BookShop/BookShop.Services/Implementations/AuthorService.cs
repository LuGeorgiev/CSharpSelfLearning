using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShop.Data;
using BookShop.Data.Models;
using BookShop.Services.Models.Author;
using BookShop.Services.Models.Books;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly BookShopDbContext db;
        private readonly IMapper mapper;

        public AuthorService(BookShopDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

      

        public async Task<int> CreateAsync(string firstName, string lastName)
        {
            var author = new Author
            {
                FirstName = firstName,
                LastName = lastName
            };

            this.db.Authors.Add(author);
            await this.db.SaveChangesAsync();

            return author.Id;
        }

        public async Task<AuthorDetailServiceModel> DetailsAsync(int id)
        {
            var author = await this.db
            .Authors
            .FirstOrDefaultAsync(a => a.Id == id);

            var mappedAuthor = mapper
                .Map<AuthorDetailServiceModel>(author);

            return mappedAuthor;
        }

        public async Task<IEnumerable<BookWithCategoriesServiceModel>> BooksAsync(int authorId)
        {
            var books = await this.db
                .Books
                .Where(b => b.AuthorId == authorId)
                .ToListAsync();

            var mappedBooks = mapper.Map<IEnumerable<BookWithCategoriesServiceModel>>(books);

            return mappedBooks;
        }

        public async Task<bool> ExistAsync(int authorId)
            => await this.db.Authors.AnyAsync(a => a.Id == authorId);
            
    }
}
