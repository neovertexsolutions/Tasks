using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemDb.DTOs;
using StudentManagementSystemDb.Interfances;

namespace StudentManagementSystemDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            int? courseid,
            string? sortBy,
            bool isDescending = false,
            int page = 1,
            int pageSize = 10)
        {
            var students = await _studentService.GetAllAsync(
                courseid,
                sortBy,
                isDescending,
                page,
                pageSize);

            return Ok(students);
        }

        // GET: api/student/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound(new
                {
                    Message = "Student not found."
                });
            }

            return Ok(student);
        }

        // POST: api/student
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = await _studentService.CreateAsync(dto);

            if (student == null)
            {
                return BadRequest("Unable to create student.");
            }

            return CreatedAtAction(nameof(GetById),
                new { id = student.Id },
                student);
        }

        // PUT: api/student/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateStudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = await _studentService.UpdateAsync(id, dto);

            if (student == null)
            {
                return NotFound(new
                {
                    Message = "Student not found."
                });
            }

            return Ok(student);
        }

        // DELETE: api/student/id
        [HttpDelete("{id}")]   
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _studentService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    Message = "Student not found."
                });
            }

            return Ok(new
            {
                Message = "Student deleted successfully."
            });
        }
    }
}