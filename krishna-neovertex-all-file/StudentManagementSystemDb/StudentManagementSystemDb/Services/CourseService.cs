using StudentManagementSystemDb.DTOs;
using StudentManagementSystemDb.Interfances;
using StudentManagementSystemDb.Models;
using StudentManagementSystemDb.Repositories;

namespace StudentManagementSystemDb.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // Get All Courses
        public async Task<IEnumerable<CourseDto>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAllAsync();

            return courses.Select(course => new CourseDto
            {
                Id = course.Id,
                CourseName = course.CourseName,
                CourseDescription = course.CourseDescription
            });
        }

        // Get Course By Id
        public async Task<CourseDto?> GetByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course == null)
                return null;

            return new CourseDto
            {
                Id = course.Id,
                CourseName = course.CourseName,
                CourseDescription = course.CourseDescription
            };
        }

        // Create Course
        public async Task<CourseDto?> CreateAsync(CreateCourseDto dto)
        {
            var course = new Course
            {
                CourseName = dto.CourseName,
                CourseDescription = dto.CourseDescription
            };  

            var createdCourse = await _courseRepository.AddAsync(course);

            if (createdCourse == null)
                return null;

            return new CourseDto
            {
                Id = createdCourse.Id,
                CourseName = createdCourse.CourseName,
                CourseDescription = createdCourse.CourseDescription
            };
        }

        // Update Course
        public async Task<CourseDto?> UpdateAsync(int id, UpdateCourseDto dto)
        {
            var course = new Course
            {
                Id = id,
                CourseName = dto.CourseName,
                CourseDescription = dto.CourseDescription
            };

            var updatedCourse = await _courseRepository.UpdateAsync(course);

            if (updatedCourse == null)
                return null;

            return new CourseDto
            {
                Id = updatedCourse.Id,
                CourseName = updatedCourse.CourseName,
                CourseDescription = updatedCourse.CourseDescription
            };
        }

        // Delete Course
        public async Task<bool> DeleteAsync(int id)
        {
            return await _courseRepository.DeleteAsync(id);
        }
        public async Task<bool> ExitsAsync(int Id)
        {
            return await _courseRepository.ExitsAsync(Id);
        }
    }
}