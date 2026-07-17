using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementApiControllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentManagementStstemApiController : ControllerBase
    {
       
        //  DAY 2 
        public List<string> student = new List<string>()
        {
           

            "krishna bhandari",
            "rahul pal",
            "ranjeet khatteri",
            "abina bhusal",
            "binod sha"
        };

        // GET ALL STUDENTS
        [HttpGet("all")]
        public List<string> GetStudents()
        {
            return student;
        }
        

        
        [HttpPost]
        public IActionResult AddStudent(string name)
        {
        if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Student name cannot be empty.");
            }
            student.Add(name); // create new student create()
            return Ok($"Student '{name}' added successfully.");
        }

        [HttpPut("{id}")]
        public IActionResult EditStudent(int id, string name)
        {
            if (id < 0 || id >= student.Count)
            {
                return NotFound($"Student with id '{id}' not found.");
            }
        if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Student name cannot be empty.");
            }
            student[id] = name;
            return Ok($"Student update '{name}'.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
         if (id < 0 || id >= student.Count)
            {
                return NotFound($"Student with id '{id}' not found.");
            }
        if (string.IsNullOrEmpty(student[id]))
            {
                return BadRequest("Student name cannot be empty.");
            }
            student.RemoveAt(id);
            return Ok($"Student with id '{id}' deleted successfully.");
        }
      
        // GET STUDENT BY ID (Route Parameter)
        [HttpGet("{id}")]
        public string getStudent(int id)
        {
            return student[id];
        }

        // GET STUDENT USING QUERY PARAMETER
        [HttpGet("string")]
        public IActionResult GetStudentQuery(int id, string name)
        {
            return Ok($"ID: {id}, Name: {name}");
        }
        
 /**
        
        //  DAY 1 

        [HttpGet]
        public IActionResult GetStudent()
        {
            return Ok(new
            {
                message = "Welcome to Student Management System API"
            });
        }
        **/
    }
}