using BookShop.Services.Models.Books;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public interface IBookService
    {
        Task<BookDetailsServiceModel> DetailsAsync(int id);

        Task<IEnumerable<BookListingServiceModel>> AllAsync (string searchText);

        Task<int> Create(
            string title,
            string description,
            decimal price,
            int copies,
            int? edition, 
            int? ageRestriction,
            DateTime releaseDate,
            int autthorId,
            string categories);
    }
}
