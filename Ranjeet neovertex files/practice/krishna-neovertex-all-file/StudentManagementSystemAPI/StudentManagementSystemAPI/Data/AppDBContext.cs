using StudentManagementSystemAPI.Models;

namespace StudentManagementSystemAPI.Data
{
    public class AppDBContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
