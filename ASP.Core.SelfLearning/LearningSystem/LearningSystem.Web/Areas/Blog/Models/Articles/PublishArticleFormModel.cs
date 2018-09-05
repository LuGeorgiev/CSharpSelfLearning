
namespace LearningSystem.Web.Areas.Blog.Models.Articles
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class PublishArticleFormModel
    {
        [Required]
        [StringLength(ArticleTitleMaxLength,
            MinimumLength = ArticleTitleMinLength)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublisheDate { get; set; }
    }
}
