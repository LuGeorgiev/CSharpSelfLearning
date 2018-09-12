﻿namespace BookShop.Api.Models.Books
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class CreateBookRequestModel
    {       
        [Required]
        [MinLength(BookTitleMinLength)]
        [MaxLength(BookTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Copies { get; set; }

        public int? Edition { get; set; }

        public int? AgeRestriction { get; set; }
                
        public DateTime ReleaseDate { get; set; }

        public int AuthorId { get; set; }

        public string Categories { get; set; }
    }
}
