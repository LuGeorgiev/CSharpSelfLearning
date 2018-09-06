using AutoMapper;
using LearningSystem.Common.Mapping;
using LearningSystem.Data.Models;
using LearningSystem.Services.Models;
using System;

namespace LearningSystem.Web.Models.Courses
{
    public class CourseDetailsViewModel 
    {
        public CourseDetailsServiceModel Course { get; set; }

        public bool UserIsEnrolledInCourse { get; set; }
    }
}
