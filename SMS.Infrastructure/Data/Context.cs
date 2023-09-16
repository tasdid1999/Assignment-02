using Microsoft.EntityFrameworkCore;
using SMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }


       public DbSet<Student> students { get; set; }

       public DbSet<Gender> genders { get; set; }

       public DbSet<Teacher> teachers { get; set; }
       
       public DbSet<Course> courses { get; set; }   

       public DbSet<TeacherCourse> teacherCourses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherCourse>()
                .HasKey(tc => new { tc.TeacherId, tc.CourseId });

            modelBuilder.Entity<TeacherCourse>()
                .HasOne(tc => tc.Teacher)
                .WithMany(t => t.TeacherCourses)
                .HasForeignKey(tc => tc.TeacherId);

            modelBuilder.Entity<TeacherCourse>()
                .HasOne(tc => tc.Course)
                .WithMany(c => c.TeacherCourses)
                .HasForeignKey(tc => tc.CourseId);

        }

    }
}
