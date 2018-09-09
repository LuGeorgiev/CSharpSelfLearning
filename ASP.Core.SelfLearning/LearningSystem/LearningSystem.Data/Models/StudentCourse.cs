namespace LearningSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class StudentCourse
    {
        public string  StudentId { get; set; }
        public User Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public Grade? Grade { get; set; }

        [MaxLength(DataConstants.CourseExamSybmissionFileMaxLength)]
        public byte[] ExamSubmission { get; set; }
    }
}
