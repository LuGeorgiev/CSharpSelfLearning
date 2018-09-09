﻿
namespace LearningSystem.Web.Models.ManageViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class IndexViewModel
    {
        public string Username { get; set; }

        [Required]
        [MaxLength(UserNameMaxLength)]
        [MinLength(UserNameMinLength)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
