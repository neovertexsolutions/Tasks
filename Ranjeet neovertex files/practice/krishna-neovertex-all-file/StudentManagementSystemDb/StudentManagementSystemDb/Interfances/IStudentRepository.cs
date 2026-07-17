using StudentManagementSystemDb.Models;
namespace StudentManagementSystemDb.Interfances
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync(
        int? courseid,
            string? sortBy,
            bool isDescending,
            int page,
            int pageSize);

        Task<Student?> GetByIdAsync(int id);
        Task<Student?> AddAsync(Student student);
        Task<Student?> UpdateAsync(Student student);
        Task<bool> DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}
