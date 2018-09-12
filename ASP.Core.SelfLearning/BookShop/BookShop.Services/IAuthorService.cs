namespace BookShop.Services
{
    using Models.Author;
    using Models.Books;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAuthorService
    {
        Task<AuthorDetailServiceModel> DetailsAsync (int id);

        Task<int> CreateAsync (string firstName, string lastName);

        Task<IEnumerable<BookWithCategoriesServiceModel>> BooksAsync (int authorId);

        Task<bool> ExistAsync(int authorId);
    }
}
