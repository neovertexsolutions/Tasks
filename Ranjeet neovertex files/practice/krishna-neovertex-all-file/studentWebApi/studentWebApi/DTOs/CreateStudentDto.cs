namespace studentWebApi.DTOs
{
    // DTO (Data Transfer Object) for creating a new student
    public class CreateStudentDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Course { get; set; }
        public int Age { get; set; }
    }
}
