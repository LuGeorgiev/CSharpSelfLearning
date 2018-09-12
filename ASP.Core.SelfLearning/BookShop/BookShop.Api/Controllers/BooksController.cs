namespace BookShop.Api.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Models.Books;
    using Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    using static WebApiConstants;

    public class BooksController :BaseApiController
    {
        private readonly IBookService books;
        private readonly IAuthorService authors;

        public BooksController(IBookService books, IAuthorService authors)
        {
            this.books = books;
            this.authors = authors;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.books.DetailsAsync(id));

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string search)
               => this.Ok(await this.books.AllAsync(search));

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody] CreateBookRequestModel model)
        {
            if (!await this.authors.ExistAsync(model.AuthorId))
            {
                return BadRequest("Author Do not exist!");
            }

            var bookId = await this.books.Create(
                model.Title,
                model.Description,
                model.Price,
                model.Copies,
                model.Edition,
                model.AgeRestriction,
                model.ReleaseDate,
                model.AuthorId,
                model.Categories);

            return Ok(bookId);
        }
    }
}
