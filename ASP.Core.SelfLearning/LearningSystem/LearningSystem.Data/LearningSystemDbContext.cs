using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LearningSystem.Data.Models;

namespace LearningSystem.Data
{
    public class LearningSystemDbContext : IdentityDbContext<User>
    {
        public LearningSystemDbContext(DbContextOptions<LearningSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<StudentCourse>()
                .HasKey(st => new { st.CourseId, st.StudentId });

            builder
                .Entity<StudentCourse>()
                .HasOne(x => x.Student)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.StudentId);

            builder.Entity<StudentCourse>()
                .HasOne(x => x.Course)
                .WithMany(x => x.Stiudents)
                .HasForeignKey(x => x.CourseId);

            builder
                .Entity<Course>()
                .HasOne(c => c.Trainer)
                .WithMany(u => u.Trainings)
                .HasForeignKey(c => c.TrainerId);

            builder.Entity<Article>()
                .HasOne(a => a.Author)
                .WithMany(a => a.Articles)
                .HasForeignKey(a => a.AuthorId);

            base.OnModelCreating(builder);
        }
    }
}
