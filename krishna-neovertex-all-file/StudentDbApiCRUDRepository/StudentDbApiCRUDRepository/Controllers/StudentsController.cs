using Microsoft.AspNetCore.Mvc;
using StudentDbApiCRUDRepository.Interfaces;
using StudentDbApiCRUDRepository.Models;

namespace StudentDbApiCRUDRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _service.GetAllStudents();

            if (students == null || !students.Any())
            {
                return NotFound("No students found.");
            }

            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _service.GetStudentById(id);

            if (student == null)
            {
                return NotFound("Student not found.");
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.AddStudent(student);

            return Ok("Student Added Successfully");
        }

        [HttpPut]
        public IActionResult UpdateStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingStudent = _service.GetStudentById(student.Id);

            if (existingStudent == null)
            {
                return NotFound("Student not found.");
            }

            _service.UpdateStudent(student);

            return Ok("Student Updated Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _service.GetStudentById(id);

            if (student == null)
            {
                return NotFound("Student not found.");
            }

            _service.DeleteStudent(id);

            return Ok("Student Deleted Successfully");
        }
    }
}