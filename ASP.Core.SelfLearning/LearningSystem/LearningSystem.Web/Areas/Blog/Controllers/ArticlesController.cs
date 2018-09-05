
namespace LearningSystem.Web.Areas.Blog.Controllers
{
    
    using Infrastructure.Extensions;
    using LearningSystem.Data.Models;
    using LearningSystem.Services.Blog;
    using LearningSystem.Services.Html;
    using LearningSystem.Web.Areas.Blog.Models.Articles;
    using LearningSystem.Web.Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    using static WebConstants;

    [Area(BlogArea)]
    [Authorize(Roles = BlogAuthorRole)]
    public class ArticlesController : Controller
    {
        private readonly IHtmlService html;
        private readonly IBlogArticleService articles;
        private readonly UserManager<User> userManager;

        public ArticlesController(IHtmlService html, IBlogArticleService articles, UserManager<User> userManager)
        {
            this.html = html;
            this.articles = articles;
            this.userManager = userManager;
        }


        public IActionResult Create() 
            =>View();

        [AllowAnonymous]
        public async Task<IActionResult> Index(int page=1)
            => View(new ArticleListingViewModel
            {
                Articles= await this.articles.AllAsync(page),
                TotalArticles= await this.articles.TotalAsync(),
                CurrentPage=page
            });

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
            => this.ViewOrNotFound(await this.articles.ById(id));

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(PublishArticleFormModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model); //due to the Validate Filter this is not needed aslo Validate summary in VIEW is not needed
            //}

            model.Content = this.html.Sanitize(model.Content);

            var userId = this.userManager.GetUserId(User);
            await this.articles.CreateAsync(model.Title, model.Content, userId);

            return RedirectToAction(nameof(Index));
        }
    }
}
