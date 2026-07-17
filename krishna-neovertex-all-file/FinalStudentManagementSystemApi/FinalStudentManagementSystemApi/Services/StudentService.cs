using FinalStudentManagementSystemApi.DTOs.Student;
using FinalStudentManagementSystemApi.Interfaces;
using FinalStudentManagementSystemApi.Models;
namespace FinalStudentManagementSystemApi.Services

{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // Get All Students
        public async Task<IEnumerable<StudentResponseDto>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();

            return students.Select(student => new StudentResponseDto
            {
                Id = student.Id,
                FullName = student.FullName,
                Age = student.Age,
                Email = student.Email,
                Address = student.Address,
                CreatedAt = student.CreatedAt
            });
        }

        // Get Student By Id
        public async Task<StudentResponseDto?> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null)
                return null;

            return new StudentResponseDto
            {
                Id = student.Id,
                FullName = student.FullName,
                Age = student.Age,
                Email = student.Email,
                Address = student.Address,
                CreatedAt = student.CreatedAt
            };
        }

        // Create Student
        public async Task<StudentResponseDto> CreateAsync(StudentCreateDto dto)
        {
            var student = new Student
            {
                FullName = dto.FullName,
                Age = dto.Age,
                Email = dto.Email,
                Address = dto.Address,
                CreatedAt = DateTime.UtcNow
            };

            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveChangesAsync();

            return new StudentResponseDto
            {
                Id = student.Id,
                FullName = student.FullName,
                Age = student.Age,
                Email = student.Email,
                Address = student.Address,
                CreatedAt = student.CreatedAt
            };
        }

        // Update Student
        public async Task<bool> UpdateAsync(int id, StudentUpdateDto dto)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null)
                return false;

            student.FullName = dto.FullName;
            student.Age = dto.Age;
            student.Email = dto.Email;
            student.Address = dto.Address;

            _studentRepository.Update(student);
            await _studentRepository.SaveChangesAsync();

            return true;
        }

        // Delete Student
        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null)
                return false;

            _studentRepository.Delete(student);
            await _studentRepository.SaveChangesAsync();

            return true;
        }
    }
}
