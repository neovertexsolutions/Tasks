using StudentDbApi.Data;
using Microsoft.EntityFrameworkCore;
using StudentDbApi.Models;
namespace StudentDbApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
    }
}
