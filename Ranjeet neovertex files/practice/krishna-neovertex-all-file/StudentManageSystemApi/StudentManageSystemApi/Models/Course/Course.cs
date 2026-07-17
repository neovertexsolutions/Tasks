using System. ComponentModel. DataAnnotations;
using StudentManageSystemApi.Models.Base;
using StudentManageSystemApi.Models.Student;
namespace StudentManageSystemApi.Models.Course
{
    public class Course : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string CourseName { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string CourseCode { get; set; } = string.Empty;
        [Required]
        [Range(1,6)]
        public int CreditHours { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        // Navigation property for the many-to-many relationship with Student
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    }
}
