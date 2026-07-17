namespace StudentManagementApiDB.Models
{
    public class Student
    {
        public  int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }

        /**
          public  int Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public int Age { get; set; }

        or 

        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
         **/

    }
}
