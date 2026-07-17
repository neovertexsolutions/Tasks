using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace day1testcontroller.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class StudentManageApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudent()
        {
            return Ok(new
            { message = "api is working" });
        }
    }
}
