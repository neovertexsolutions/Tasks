using System.ComponentModel.DataAnnotations;
namespace StudentManagementSystemDb.DTOs
{
    public class CreateCourseDto
    {
        [Required]
        [StringLength(50)]
        public string CourseName { get; set; } = string.Empty;
        [Required]
        [StringLength(500)]
        public string CourseDescription { get; set; } = string.Empty;


    }
}
