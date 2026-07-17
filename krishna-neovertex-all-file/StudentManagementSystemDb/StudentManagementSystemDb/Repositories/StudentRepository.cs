using Microsoft.EntityFrameworkCore;
using StudentManagementSystemDb.Data;
using StudentManagementSystemDb.Interfances;
using StudentManagementSystemDb.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace StudentManagementSystemDb.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }
        // get all students with filter sorting and pagination
        public async Task<IEnumerable<Student>> GetAllAsync(
            int? courseId,
            string? sortBy,
            bool IsDecending,
            int page,
            int pageSize)
        {
            var Query = _context.Students
                .Include(s => s.Course)
                .AsQueryable();
            //filter
            if (courseId.HasValue)
            {
                Query = Query.Where(s => s.CourseId == courseId.Value);
            }
            //sorting
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "name":
                        Query = IsDecending
                            ? Query.OrderByDescending(s => s.FullName) : Query.OrderBy(s => s.FullName);
                        break;
                    case "age":
                        Query = IsDecending
                         ? Query.OrderByDescending(s => s.age) : Query.OrderBy(s => s.age);
                        break;
                    case "email":
                        Query = IsDecending
                             ? Query.OrderByDescending(s => s.email)
                             : Query.OrderBy(s => s.email);
                        break;

                    case "course":
                        Query = IsDecending
                            ? Query.OrderByDescending(s => s.Course!.CourseName)
                            : Query.OrderBy(s => s.Course!.CourseName);
                        break;

                    default:
                        Query = Query.OrderBy(s => s.id);
                        break;
                }
            }
            else
            {
                Query = Query.OrderBy(s => s.id);

            }
            //pagination
            Query = Query
               // skip the previous pages and continuew the rquired page
               .Skip((page - 1) * pageSize)
               .Take(pageSize);// take the required page size

            return await Query.ToListAsync();
        }

        // Get Student By Id
        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students
                .Include(s => s.Course)
                .FirstOrDefaultAsync(s => s.id == id);
        }

        // Add Student
        public async Task<Student?> AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return student;
        }

        // Update Student
        public async Task<Student?> UpdateAsync(Student student)
        {
            var existingStudent = await _context.Students.FindAsync(student.id);

            if (existingStudent == null)
            {
                return null;
            }

            existingStudent.FullName = student.FullName;
            existingStudent.email = student.email;
            existingStudent.age = student.age;
            existingStudent.CourseId = student.CourseId;

            await _context.SaveChangesAsync();

            return existingStudent;
        }

        // Delete Student
        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return false;
            }

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();

            return true;
        }

        // Check Student Exists
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Students.AnyAsync(s => s.id == id);
        }
    }

}
