using Microsoft.EntityFrameworkCore;
using StudentManagementRepository.Data;
using StudentManagementRepository.Models;
namespace StudentManagementRepository.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
