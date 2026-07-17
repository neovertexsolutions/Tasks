using StudentManagementRepository.DTOs;
using StudentManagementRepository.Models;
namespace StudentManagementRepository.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllAsync();
        Task<StudentDto?> GetByIdAsync(int id);
        Task<StudentDto> CreateAsync(CreateStudentDto dto);
        Task<StudentDto?> UpdateAsync(int id, UpdateStudentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
