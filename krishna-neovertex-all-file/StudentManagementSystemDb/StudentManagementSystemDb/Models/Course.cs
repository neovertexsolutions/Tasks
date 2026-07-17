using System.ComponentModel.DataAnnotations;
namespace StudentManagementSystemDb.Models
{
    public class Course
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string CourseDescription { get; set; } = string.Empty;

        // "ICollection" navigation property (one course --> many students)
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
