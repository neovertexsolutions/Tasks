namespace FinalStudentManagementSystemApi.DTOs.Student
{
    public class StudentResponseDto
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
