
namespace LearningSystem.Services.Blog.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using LearningSystem.Data;
    using LearningSystem.Data.Models;
    using LearningSystem.Services.Blog.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static ServiceConstants;

    public class BlogArticleService:IBlogArticleService
    {
        private readonly LearningSystemDbContext db;
        private readonly IMapper mapper;

        public BlogArticleService(LearningSystemDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<BlogArticleListingServiceModel>> AllAsync(int page=1 )
        {
            var articles = await this.db.Articles
                .OrderByDescending(a => a.PublisheDate)
                .Skip((page - 1) * BlogArticlesPageSize)
                .Take(BlogArticlesPageSize)
                .ToListAsync();

            return mapper.Map<IEnumerable<BlogArticleListingServiceModel>>(articles);               

        }

        public async Task<BlogArticleDetailsServiceModel> ById(int id)
        {
            var article = await db.Articles
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            return mapper.Map<BlogArticleDetailsServiceModel>(article);
        }

        public async Task CreateAsync(string title, string content, string authotId)
        {
            var article = new Article
            {
                Title=title,
                Content=content,
                PublisheDate=DateTime.UtcNow,
                AuthorId=authotId
            };

            this.db.Add(article);
            await this.db.SaveChangesAsync();
        }

        public async Task<int> TotalAsync()
            => await this.db.Articles
            .CountAsync();
    }
}
