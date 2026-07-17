namespace StudentDbApiCRUD.DTOs
{
    public class CreateStudentDto
    {
       public string? FullName { get; set; }
        public string? Email { get; set; } = null;
        public int Age { get; set; }
    }
}
