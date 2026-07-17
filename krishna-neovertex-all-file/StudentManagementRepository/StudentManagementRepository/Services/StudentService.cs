using StudentManagementRepository.DTOs;
using StudentManagementRepository.Interfaces;
using StudentManagementRepository.Models;
namespace StudentManagementRepository.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<StudentDto>> GetAllAsync()
        {
            var students = await _repo.GetAllAsync();

            return students.Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Age = s.Age,
                EmailAddress = s.EmailAddress
            }).ToList();
        }

        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            var s = await _repo.GetByIdAsync(id);
            if (s == null) return null;

            return new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Age = s.Age,
                EmailAddress = s.EmailAddress
            };
        }

        public async Task<StudentDto> CreateAsync(CreateStudentDto studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                Age = studentDto.Age,
                EmailAddress = studentDto.EmailAddress
            };

            await _repo.AddAsync(student);
            await _repo.SaveAsync();

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                EmailAddress = student.EmailAddress
            };
        }

        public async Task<StudentDto?> UpdateAsync(int id, UpdateStudentDto dto)
        {
            var student = await _repo.GetByIdAsync(id);

            if (student == null)
                return null;

            student.Name = dto.Name;
            student.Age = dto.Age;
            student.EmailAddress = dto.EmailAddress;

            await _repo.UpdateAsync(student);
            await _repo.SaveAsync();

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                EmailAddress = student.EmailAddress
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _repo.GetByIdAsync(id);
            if (student == null) return false;

            await _repo.DeleteAsync(student);
            await _repo.SaveAsync();

            return true;
        }

    }
}
