using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentWebApi.DTOs;
using studentWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace studentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> Students = new List<Student>
        {
            new Student
            {
            Id = 1,
            FullName = "krishna",
            Email = "krishnabhandari2062@gmail.com",
            PhoneNumber = "1234567890",
            Course = "Computer Science",
            Age = 20,
            CreatedAt = DateTime.Now
                }
        };
        // GET all: api/Student
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            if(!Students.Any())
            {
                return NotFound("There is no any students details found");
            }
            var result = Students.Select(s => new StudentResponseDto
            {
                Id = s.Id,
                FullName = s.FullName,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                Course = s.Course,
                Age = s.Age,
                CreatedAt = s.CreatedAt
            }).ToList();

            return Ok(Students);

        }

        // GET by id: api/Student/{id} response dto
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound("student isnot found");
            }
            var result = new StudentResponseDto
            {
                Id = student.Id,
                FullName = student.FullName,
                Email = student.Email,
                Course = student.Course,
            };
            return Ok(result);

        }

        // post api/Student
        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDto dto)
        {
            // ? ifeslse
            int newId = Students.Any()
                ? Students.Max(s => s.Id) + 1 : 1; // Generate new Id based on existing students

            var student = new Student
            {
                Id = newId,
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Course = dto.Course,
                Age = dto.Age,
                CreatedAt = DateTime.Now
            };
            Students.Add(student);

            return Ok(student);

        }

        // put api/Student
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, UpdateStudentDto dto)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound("student is not found");
            }
            student.FullName = dto.FullName;
            student.Email = dto.Email;
            student.PhoneNumber = dto.PhoneNumber;
            student.Course = dto.Course;
            student.Age = dto.Age;
            return Ok(student);

        }

        // delete api/Student
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound("student is not found");
            }
            Students.Remove(student);
            return Ok("student is deleted successfully");

        }
    }
}
