
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace day5studentapihandling.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Course { get; set; }

        public static implicit operator Student(List<Student> v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator ModelStateDictionary(Student v)
        {
            throw new NotImplementedException();
        }
    }
}
