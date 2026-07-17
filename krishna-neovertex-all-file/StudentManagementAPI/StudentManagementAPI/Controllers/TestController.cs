using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementAPI.Controllers // This line defines the namespace for the controller. It is a common convention to use the format "ProjectName.Controllers" for API controllers. In this case, the project name is "StudentManagementAPI", so the namespace is "StudentManagementAPI.Controllers".
{
    [Route("api/[controller]")] // This attribute defines the route for the controller. The [controller] token will be replaced with the name of the controller, which is "Test" in this case. So the route for this controller will be "api/test".
    [ApiController] // This attribute indicates that this class is an API controller. It enables some features like automatic model validation and binding source parameter inference.
    public class TestController : ControllerBase // This class inherits from ControllerBase, which is a base class for API controllers. It provides some common functionality for handling HTTP requests and responses.
    {
        public List<string> student = new List<string>() // This is a public field that holds a list of strings representing student names. It is initialized with two names: "krishna" and "bhandari".
        {
            "krishna",
            "bhandari"
        };
        [HttpGet] // This attribute indicates that the following method will handle HTTP GET requests. When a client sends a GET request to the route "api/test", this method will be invoked.
        public List <string> Get() // This is a public method that returns a list of strings. It is decorated with the [HttpGet] attribute, which means that it will handle HTTP GET requests sent to the route "api/test". When this method is called, it simply returns the list of student names.
        {
            return student; // This line returns the list of student names to the client that made the GET request. The response will be in JSON format by default, and it will contain an array of strings with the values "krishna" and "bhandari".
        }
    }
}
