namespace StudentDbApiCRUD.DTOs
{
    public class UpdateStudentDto
    {
        public string? FullName { get; set; }
        public string? Email { get; set; } = null;
        public int Age { get; set; }
    }
}
