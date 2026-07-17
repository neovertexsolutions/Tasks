using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystemDb.DTOs
{
    public class CreateStudentDto
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }= string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Range(1,50)]
        public int Age { get; set; }
        [Required]
        public int courseID { get; set; }

        
    }
}
