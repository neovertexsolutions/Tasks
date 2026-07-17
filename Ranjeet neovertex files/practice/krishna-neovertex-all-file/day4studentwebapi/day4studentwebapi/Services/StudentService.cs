using day4studentwebapi.Interfaces;
using day4studentwebapi.Models;

namespace day4studentwebapi.Services
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new()
        {
            new Student
            {
                Id= 1,
                Name = "krishna bhandari",
                Email = "krishna@gmail.com",
                Age = 20,
                Grade = "A",
                Address = "butwal",
                Course = "Computer Science"
            },
            new Student
            {
                Id= 2,
                Name = "Ranjeet khatteri",
                Email = "ranjeet@gmail.com",
                Age = 22,
                Grade = "B",
                Address = "butwal",
                Course = "Mathematics"
            },
            new Student
            {
                Id= 3,
                Name = "Abina bhusal",
                Email = "abina@gmail.com",
                Age = 18,
                Grade = "B",
                Address = "butwal",
                Course = "Data Science"
            }
        };

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public Student? GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public Student Create(Student student)
        {

            if (string.IsNullOrWhiteSpace(student.Name))
            {
                throw new Exception("Name is required.");
            }

            if (string.IsNullOrWhiteSpace(student.Email))
            {
                throw new Exception("Email is required.");
            }

            if (student.Age < 18 || student.Age > 60)
            {
                throw new Exception("Age must be between 18 and 60.");
            }

            if (string.IsNullOrWhiteSpace(student.Course))
            {
                throw new Exception("Course is required.");
            }

            if (students.Any(s =>
                s.Email.Equals(student.Email, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("Email already exists.");
            }

            int newId = students.Any()
                ? students.Max(s => s.Id) + 1
                : 1;

            student.Id = newId;

            students.Add(student);

            return student;
        }

        public Student Update(Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);

            if (existingStudent == null)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(student.Name))
            {
                throw new Exception("Name is required.");
            }

            if (string.IsNullOrWhiteSpace(student.Email))
            {
                throw new Exception("Email is required.");
            }

            if (student.Age < 18 || student.Age > 60)
            {
                throw new Exception("Age must be between 18 and 60.");
            }

            if (string.IsNullOrWhiteSpace(student.Course))
            {
                throw new Exception("Course is required.");
            }

            bool emailExists = students.Any(s =>
                s.Id != student.Id &&
                s.Email.Equals(student.Email, StringComparison.OrdinalIgnoreCase));

            if (emailExists)
            {
                throw new Exception("Email already exists.");
            }

            existingStudent.Name = student.Name;
            existingStudent.Email = student.Email;
            existingStudent.Age = student.Age;
            existingStudent.Grade = student.Grade;
            existingStudent.Address = student.Address;
            existingStudent.Course = student.Course;

            return existingStudent;
        }

        public bool Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return false;
            }

            students.Remove(student);

            return true;
        }

        public Student? Update(int id, Student student)
        {
            throw new NotImplementedException();
        }

        // Interface bata call garda yo method execute hunxa
        object IStudentService.Update(Student student)
        {
            return Update(student);
        }
    }
}