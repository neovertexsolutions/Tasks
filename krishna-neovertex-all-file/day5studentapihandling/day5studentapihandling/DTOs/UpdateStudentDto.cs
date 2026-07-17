using System.ComponentModel.DataAnnotations;

namespace day5studentapihandling.DTOs
{
    public class UpdateStudentDto
    {
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Full Name must be between 3 and 100 characters")]
        public string? FullName { get; set; }

        [RegularExpression(
            @"^[a-zA-Z0-9._%+-]+@gmail\.com$",
            ErrorMessage = "Only @gmail.com email addresses are allowed")]
        public string? Email { get; set; }

        [Range(18, 60,
            ErrorMessage = "Age must be between 18 and 60")]
        public int? Age { get; set; }

        [RegularExpression(@"^[0-9]{10}$",
            ErrorMessage = "Phone Number must contain exactly 10 digits")]
        public string? PhoneNumber { get; set; }

        [MinLength(1, ErrorMessage = "Course cannot be empty")]
        public string? Course { get; set; }
    }
}