using StudentManagementSystemDb.DTOs;
namespace StudentManagementSystemDb.Interfances
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllAsync();
        Task<CourseDto?> GetByIdAsync(int id);
        Task<CourseDto?> CreateAsync(CreateCourseDto dto);
        Task<CourseDto?> UpdateAsync(int id,UpdateCourseDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExitsAsync(int Id);
    }
}
