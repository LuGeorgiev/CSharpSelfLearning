using LearningSystem.Services.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Web.Models.Home
{
    public class SearchFormModel
    {
        public string  SearchText { get; set; }

        [Display(Name = "Courses search")]
        public bool SearchInCourses { get; set; } = true;


        [Display(Name = "Users serach")]
        public bool SearchInUsers { get; set; } = true;

    }
}
