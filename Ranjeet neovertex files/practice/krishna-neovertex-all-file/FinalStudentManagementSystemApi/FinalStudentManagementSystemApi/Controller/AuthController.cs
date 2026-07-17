using FinalStudentManagementSystemApi.DTOs.Auth;
using FinalStudentManagementSystemApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalStudentManagementSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _userService.RegisterAsync(dto);

            if (!result)
            {
                return BadRequest(new
                {
                    Message = "Email already exists."
                });
            }

            return Ok(new
            {
                Message = "User registered successfully."
            });
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _userService.LoginAsync(dto);

            if (result == null)
            {
                return Unauthorized(new
                {
                    Message = "Invalid Email or Password."
                });
            }

            return Ok(result);
        }
    }
}