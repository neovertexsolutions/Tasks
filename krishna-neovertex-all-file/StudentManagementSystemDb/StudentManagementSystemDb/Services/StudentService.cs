using StudentManagementSystemDb.DTOs;
using StudentManagementSystemDb.Interfances;
using StudentManagementSystemDb.Models;

namespace StudentManagementSystemDb.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // Get All Students (Filtering + Sorting + Pagination)
        public async Task<IEnumerable<StudentDto>> GetAllAsync(
            int? courseid,
            string? sortBy,
            bool isDescending,
            int page,
            int pageSize)
        {
            var students = await _studentRepository.GetAllAsync(
                courseid,
                sortBy,
                isDescending,
                page,
                pageSize);

            return students.Select(student => new StudentDto
            {
                Id = student.id,
                FullName = student.FullName,
                Email = student.email,
                Age = student.age,
                CourseId = student.CourseId,
                CourseName = student.Course != null
                                ? student.Course.CourseName
                                : string.Empty
            }); 
        }

        // Get Student By Id
        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null)
                return null;

            return new StudentDto
            {
                Id = student.id,
                FullName = student.FullName,
                Email = student.email,
                Age = student.age,
                CourseId = student.CourseId,
                CourseName = student.Course != null
                                ? student.Course.CourseName
                                : string.Empty
            };
        }

        // Create Student
        public async Task<StudentDto?> CreateAsync(CreateStudentDto dto)
        {
            var student = new Student
            {
                FullName = dto.FullName,
                email = dto.Email,
                age = dto.Age,
                CourseId = dto.courseID
            };

            var createdStudent = await _studentRepository.AddAsync(student);

            if (createdStudent == null)
                return null;

            var result = await _studentRepository.GetByIdAsync(createdStudent.id);

            return new StudentDto
            {
                Id = result!.id,
                FullName = result.FullName,
                Email = result.email,
                Age = result.age,
                CourseId = result.CourseId,
                CourseName = result.Course?.CourseName ?? string.Empty
            };
        }

        // Update Student
        public async Task<StudentDto?> UpdateAsync(int id, UpdateStudentDto dto)
        {
            var student = new Student
            {
                id = id,
                FullName = dto.FullName ?? string.Empty,
                email = dto.Email ?? string.Empty,
                age = dto.Age,
                CourseId = dto.CourseId
            };

            var updatedStudent = await _studentRepository.UpdateAsync(student);

            if (updatedStudent == null)
                return null;

            var result = await _studentRepository.GetByIdAsync(updatedStudent.id);

            return new StudentDto
            {
                Id = result!.id,
                FullName = result.FullName,
                Email = result.email,
                Age = result.age,
                CourseId = result.CourseId,
                CourseName = result.Course?.CourseName ?? string.Empty
            };
        }

        // Delete Student
        public async Task<bool> DeleteAsync(int id)
        {
            return await _studentRepository.DeleteAsync(id);
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _studentRepository.ExistsAsync(id);
        }
    }
}