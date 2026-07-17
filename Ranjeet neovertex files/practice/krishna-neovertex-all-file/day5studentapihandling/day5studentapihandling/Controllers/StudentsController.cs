using day5studentapihandling.DTOs;
using day5studentapihandling.Interfaces;
using day5studentapihandling.Models;
using day5studentapihandling.Responses;
using day5studentapihandling.Services;
using Microsoft.AspNetCore.Mvc;

namespace day5studentapihandling.Controllers
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
            return Ok(new ApiResponse<List<Student>>
            {
                Success = true,
                Message = "Students retrieved successfully",
                Date = _service.GetAll()
            });
        }

        [HttpGet("search")]
        public IActionResult GetStudent(string keyword)
        {
            var result = _service.Search(keyword);

            if (result == null || result.Count == 0)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "No student found",
                    Date = null
                });
            }

            return Ok(new ApiResponse<List<Student>>
            {
                Success = true,
                Message = "Search result found",
                Date = result
            });
        }

        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Validation Failed",
                    Date = ModelState
                });
            }

            try
            {
                var result = _service.Create(dto);

                return Ok(new ApiResponse<Student>
                {
                    Success = true,
                    Message = "Student created successfully",
                    Date = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Date = null
                });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, UpdateStudentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Validation Failed",
                    Date = ModelState
                });
            }

            try
            {
                var result = _service.Update(id, dto);

                if (result == null)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Student not found",
                        Date = null
                    });
                }

                return Ok(new ApiResponse<Student>
                {
                    Success = true,
                    Message = "Student updated successfully",
                    Date = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Date = null
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var result = _service.Delete(id);

            if (!result)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Student not found",
                    Date = null
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Student deleted successfully",
                Date = null
            });
        }
    }
}