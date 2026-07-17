using StudentManagementSystemDb.DTOs;
using StudentManagementSystemDb.Models;
namespace StudentManagementSystemDb.Interfances
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllAsync(
           int? courseId,
               string? sortBy,
               bool isDescending,
               int page,
               int pageSize);

        Task<StudentDto?>GetByIdAsync(int id);
        Task<StudentDto?> CreateAsync(CreateStudentDto dto);
        Task<StudentDto?> UpdateAsync(int id,UpdateStudentDto dto);
        Task<bool> DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);
    }

}
