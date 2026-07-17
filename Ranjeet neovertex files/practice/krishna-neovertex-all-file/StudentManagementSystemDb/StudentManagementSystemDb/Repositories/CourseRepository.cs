using Microsoft.EntityFrameworkCore;
using StudentManagementSystemDb.Data;
using StudentManagementSystemDb.Interfances;
using StudentManagementSystemDb.Models;

namespace StudentManagementSystemDb.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get All Courses
        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses
                .Include(c => c.Students)
                .ToListAsync();
        }

        // Get Course By Id
        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        // Add Course
        public async Task<Course> AddAsync(Course course)
        {
            await _context.Courses.AddAsync(course);

            await _context.SaveChangesAsync();

            return course;
        }

        // Update Course
        public async Task<Course?> UpdateAsync(Course course)
        {
            var existingCourse = await _context.Courses.FindAsync(course.Id);

            if (existingCourse == null)
            {
                return null;
            }

            existingCourse.CourseName = course.CourseName;
            existingCourse.CourseDescription = course.CourseDescription;

            await _context.SaveChangesAsync();

            return existingCourse;
        }

        // Delete Course
        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return false;
            }

            _context.Courses.Remove(course);

            await _context.SaveChangesAsync();

            return true;
        }

        // Check Course Exists
        public async Task<bool> ExitsAsync(int id)
        {
            return await _context.Courses.AnyAsync(c => c.Id == id);
        }
    }
}