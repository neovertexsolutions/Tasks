using StudentDbApiCRUDRepository.Data;
using StudentDbApiCRUDRepository.Interfaces;
using StudentDbApiCRUDRepository.Models;

namespace StudentDbApiCRUDRepository.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student? GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(x => x.Id == id);
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            var existingStudent = _context.Students.FirstOrDefault(x => x.Id == student.Id);

            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Email = student.Email;
                existingStudent.Age = student.Age;
                existingStudent.Address = student.Address;

                _context.SaveChanges();
            }
        }

        public void DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);

            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}