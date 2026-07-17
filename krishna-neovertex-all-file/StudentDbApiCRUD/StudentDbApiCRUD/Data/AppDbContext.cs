using Microsoft.EntityFrameworkCore;
using StudentDbApiCRUD.Data;
using StudentDbApiCRUD.Models;
namespace StudentDbApiCRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
