using Microsoft.EntityFrameworkCore;
using StudentManagementSystemDb.Models;

namespace StudentManagementSystemDb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        // create a student table on database with the name of Students
        public DbSet<Student> Students { get; set; }
        // create a course table on database with the name of Courses
        public DbSet<Course> Courses { get; set; }

        // configure the relationship between Student and Course entities
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    CourseName = "Computer Science",
                    CourseDescription = "Computer Science and Engineering"
                },
                new Course
                {
                    Id = 2,
                    CourseName = "Information Technology",
                    CourseDescription = "IT Engineering"
                },
                new Course
                {
                    Id = 3,
                    CourseName = "Civil Engineering",
                    CourseDescription = "Civil Engineering"
                });
        }
    }
}