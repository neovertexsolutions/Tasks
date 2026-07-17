using Microsoft.EntityFrameworkCore;
using StudentManageSystemApi.Models.Course;
using StudentManageSystemApi.Models.Student;
using StudentManageSystemApi.Models.Identity;
namespace StudentManageSystemApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
       // identty
       public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        // student
        public DbSet<Student> Students { get; set; }

        // course
        public DbSet<Course> Courses { get; set; }

        // junction table 
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // studentcourse composite key 
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new
                {
                    sc.StudentId,
                    sc.CourseId
                });
        }
    }
}
