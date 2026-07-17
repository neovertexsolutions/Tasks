using day4studentwebapi.Interfaces;
using day4studentwebapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace day4studentwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/Students
        [HttpGet]
        public ActionResult<List<Student>> GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }

        // GET: api/Students/1
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _studentService.GetStudentById(id);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            return Ok(student);
        }

        // POST: api/Students
        [HttpPost]
        public IActionResult Create(Student student)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(student.Name))
                {
                    return BadRequest("Name is required");
                }

                var createdStudent = _studentService.Create(student);

                return Ok(createdStudent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Students/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, Student student)
        {
            try
            {
                if (id != student.Id)
                {
                    return BadRequest("Id mismatch");
                }

                var updatedStudent = _studentService.Update(student);

                if (updatedStudent == null)
                {
                    return NotFound("Student not found");
                }

                return Ok("Updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Students/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _studentService.Delete(id);

            if (!result)
            {
                return NotFound("Student not found");
            }

            return Ok("Deleted successfully");
        }
    }
}