using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemDb.DTOs;
using StudentManagementSystemDb.Interfances;

namespace StudentManagementSystemDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/course
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseService.GetAllAsync();

            return Ok(courses);
        }

        // GET: api/course/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _courseService.GetByIdAsync(id);

            if (course == null)
            {
                return NotFound(new
                {
                    Message = "Course not found."
                });
            }

            return Ok(course);
        }

        // POST: api/course
        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var course = await _courseService.CreateAsync(dto);

            if (course == null)
            {
                return BadRequest(new
                {
                    Message = "Unable to create course."
                });
            }

            return CreatedAtAction(nameof(GetById),
                new { id = course.Id },
                course);
        }

        // PUT: api/course/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCourseDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var course = await _courseService.UpdateAsync(id, dto);

            if (course == null)
            {
                return NotFound(new
                {
                    Message = "Course not found."
                });
            }

            return Ok(course);
        }

        // DELETE: api/course/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _courseService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    Message = "Course not found."
                });
            }

            return Ok(new
            {
                Message = "Course deleted successfully."
            });
        }
    }
}