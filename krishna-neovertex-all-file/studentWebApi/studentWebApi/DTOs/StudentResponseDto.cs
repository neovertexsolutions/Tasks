
namespace studentWebApi.DTOs
{
    public class StudentResponseDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }
        public string? PhoneNumber { get; internal set; }
        public int Age { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
    }
}
