namespace BookShop.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using BookShop.Common.Extensions;
    using BookShop.Data;
    using BookShop.Data.Models;
    using BookShop.Services.Models.Books;
    using Microsoft.EntityFrameworkCore;

    public class BookService : IBookService
    {
        private readonly BookShopDbContext db;
        private readonly IMapper mapper;

        public BookService(BookShopDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<BookListingServiceModel>> AllAsync(string searchText)
        {
            var books = await this.db
                .Books
                .Where(b => b.Title.ToLower().Contains(searchText.ToLower()))
                .OrderBy(b=>b.Title)
                .Take(10)
                .ToListAsync();

            var mappedBook = mapper.Map<IEnumerable<BookListingServiceModel>>(books);
            return mappedBook;
        }

        public async Task<int> Create(string title, 
            string description, 
            decimal price, 
            int copies, 
            int? edition, 
            int? ageRestriction, 
            DateTime releaseDate, 
            int autthorId, 
            string categories)
        {
            var categoryNames = categories
                .ToLower()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToHashSet();

            var existingCategories = await this.db
                .Categories
                .Where(c => categoryNames.Contains(c.Name.ToLower()))
                .ToListAsync();

            var allCategories = new List<Category>(existingCategories);

            foreach (var categoryName in categoryNames)
            {
                if (existingCategories.All(c=>c.Name!=categoryName))
                {
                    var category = new Category
                    {
                        Name=categoryName
                    };
                    allCategories.Add(category);
                    this.db.Add(category);
                }
            }
            await this.db.SaveChangesAsync();

            var book = new Book
            {
                Title=title,
                Description=description,
                Price=price,
                Copies=copies,
                Edition=edition,
                AgeRestriction=ageRestriction,
                ReleaseDate=releaseDate,
                AuthorId=autthorId
            };

            allCategories.ForEach(c => book.Categories.Add(new BookCategory
            {
                CategoryId = c.Id
            }));

            this.db.Books.Add(book);
            await this.db.SaveChangesAsync();

            return book.Id;
        }

        public async Task<BookDetailsServiceModel> DetailsAsync(int id)
        {
            var book = await this.db
                .Books
                .Include(b=>b.Categories)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();

            var mappedBook = mapper.Map<BookDetailsServiceModel>(book);
            return mappedBook;
        }
    }
}
