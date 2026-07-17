using day5studentapihandling.DTOs;
using day5studentapihandling.Interfaces;
using day5studentapihandling.Models;

namespace day5studentapihandling.Services
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new List<Student>();

        public List<Student> GetAll()
        {
            return students;
        }

        public Student GetById(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        //  EMAIL EXISTS CHECK (with optional excludeId for update)
        public bool EmailExists(string email, int? excludeId = null)
        {
            return students.Any(x =>
                x.Email.ToLower() == email.ToLower()
                && (!excludeId.HasValue || x.Id != excludeId));
        }

        // New Gmail validation rule
        private bool IsValidGmail(string email)
        {
            return email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase);
        }

        public Student Create(CreateStudentDto dto)
        {
            // Gmail validation
            if (!IsValidGmail(dto.Email))
            {
                throw new Exception("Only @gmail.com email addresses are allowed");
            }

            //  Duplicate check
            if (EmailExists(dto.Email))
            {
                throw new Exception("Email already exists");
            }

            var student = new Student
            {
                Id = students.Count > 0 ? students.Max(x => x.Id) + 1 : 1,
                FullName = dto.FullName,
                Email = dto.Email,
                Age = dto.Age,
                PhoneNumber = dto.PhoneNumber,
                Course = dto.Course
            };

            students.Add(student);
            return student;
        }

        public Student Update(int id, UpdateStudentDto dto)
        {
            var student = GetById(id);
            if (student == null) return null;

            // email check on update 
            if (!string.IsNullOrWhiteSpace(dto.Email))
            {
                if (!IsValidGmail(dto.Email))
                {
                    throw new Exception("Only @gmail.com email addresses are allowed");
                }

                if (EmailExists(dto.Email, id))
                {
                    throw new Exception("Email already exists");
                }

                student.Email = dto.Email;
            }

            if (!string.IsNullOrWhiteSpace(dto.FullName))
                student.FullName = dto.FullName;

            if (dto.Age.HasValue)
                student.Age = dto.Age.Value;

            if (!string.IsNullOrWhiteSpace(dto.PhoneNumber))
                student.PhoneNumber = dto.PhoneNumber;

            if (!string.IsNullOrWhiteSpace(dto.Course))
                student.Course = dto.Course;

            return student;
        }

        public bool Delete(int id)
        {
            var student = GetById(id);
            if (student == null) return false;

            students.Remove(student);
            return true;
        }
        public List<Student> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return students;

            keyword = keyword.ToLower();

            return students.Where(x =>
                x.Id.ToString() == keyword ||  // search by ID
                x.FullName.ToLower().Contains(keyword) // search by name
            ).ToList();
        }

      
    }
}