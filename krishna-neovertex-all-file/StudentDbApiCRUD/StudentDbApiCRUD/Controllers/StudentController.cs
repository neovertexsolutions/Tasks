using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentDbApiCRUD.Data;
using StudentDbApiCRUD.DTOs;
using StudentDbApiCRUD.Models;
using StudentDbApiCRUD.Data;
using StudentDbApiCRUD.DTOs;
using StudentDbApiCRUD.Models;

namespace StudentDbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context; 

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateStudentDto dto)
        {
            var student = new Student
            {
                FullName = dto.FullName,
                Age = dto.Age,
                Email = dto.Email
            };

            await _context.Students.AddAsync(student);

            await _context.SaveChangesAsync();

            return Ok("student create sucessfully.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students =
                await _context.Students.ToListAsync();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student =
                await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound("student not found");
            }

            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            UpdateStudentDto dto)
        {
            var student =
                await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound("student not found.");
            }
            student.FullName = dto.FullName;
            student.Age = dto.Age;
            student.Email = dto.Email;

            _context.Students.Update(student);

            await _context.SaveChangesAsync();

            return Ok("student update sucessfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student =
                await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();

            return Ok("student deleted");
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(
            string name)
        {
            var students = await _context.Students
                .Where(x => x.FullName.Contains(name))
                .ToListAsync();

            return Ok(students);
        }
    }
}