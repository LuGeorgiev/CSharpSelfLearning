
namespace BookShop.Api.Controllers
{
    using Infrastructure.Extensions;
    using BookShop.Services;
    using Microsoft.AspNetCore.Mvc;

    using static WebApiConstants;
    using BookShop.Api.Models.Authors;
    using System.Threading.Tasks;
    using BookShop.Api.Infrastructure.Filters;

    public class AuthorsController:BaseApiController
    {
        private readonly IAuthorService authors;

        public AuthorsController(IAuthorService authors)
        {
            this.authors = authors;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.authors.DetailsAsync(id));

        [HttpGet(WithId + "/books")]
        public async Task<IActionResult> GetBooks(int id)
            => this.Ok(await this.authors.BooksAsync(id));

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody]AuthorRequestModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var id = await this.authors.CreateAsync(model.FirstName, model.LastName);

            return Ok(id);
        }
    }
}
