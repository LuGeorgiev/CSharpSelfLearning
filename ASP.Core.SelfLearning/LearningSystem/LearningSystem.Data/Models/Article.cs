



namespace LearningSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Article
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ArticleTitleMaxLength, 
            MinimumLength =ArticleTitleMinLength)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublisheDate{ get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}
