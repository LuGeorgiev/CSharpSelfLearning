namespace LearningSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CourseNameMaxLength,
            MinimumLength =CourseNameMinLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(CourseDescriptionMaxLength)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
                
        public string TrainerId { get; set; }

        public User Trainer { get; set; }

        public List<StudentCourse> Stiudents { get; set; } = new List<StudentCourse>();
    }
}
