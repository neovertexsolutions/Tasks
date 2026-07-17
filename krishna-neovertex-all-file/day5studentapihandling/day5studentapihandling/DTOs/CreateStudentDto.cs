using System.ComponentModel.DataAnnotations;

namespace day5studentapihandling.DTOs
{
    public class CreateStudentDto
    {
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Full Name must be between 3 and 100 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(
            @"^[a-zA-Z0-9._%+-]+@gmail\.com$",
            ErrorMessage = "Only @gmail.com email addresses are allowed")]
        public string Email { get; set; }

        [Range(18, 60,
            ErrorMessage = "Age must be between 18 and 60")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^[0-9]{10}$",
            ErrorMessage = "Phone Number must contain exactly 10 digits")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Course is required")]
        public string Course { get; set; }
    }
}