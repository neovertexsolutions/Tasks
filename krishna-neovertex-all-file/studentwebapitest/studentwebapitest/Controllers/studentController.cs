using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace studentwebapitest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentController : ControllerBase
    {
        public List <string> students = new List<string>()
        {
            "student1",
            "student2",
            "student3",
            "student4",
            "student5",
            "stident6"
        };
        [HttpGet]
        public List <string> Get()
        {
            return students;
        }
    }
}
