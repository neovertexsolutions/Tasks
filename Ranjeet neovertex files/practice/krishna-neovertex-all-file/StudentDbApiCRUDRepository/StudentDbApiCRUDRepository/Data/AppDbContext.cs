using Microsoft.EntityFrameworkCore;
using StudentDbApiCRUDRepository.Data;
using StudentDbApiCRUDRepository.Models;
namespace StudentDbApiCRUDRepository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
    }
}
