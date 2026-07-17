using FinalStudentManagementSystemApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalStudentManagementSystemApi.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public AdminController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/admin/students
        [HttpGet("students")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentService.GetAllAsync();

            return Ok(students);
        }
    }
}