using System. ComponentModel. DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StudentManageSystemApi.Models.Base;
using StudentManageSystemApi.Models.Identity;

namespace StudentManageSystemApi.Models.Student
{
    public class Student: BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Department { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string Semester { get; set; } = string.Empty;
        
        public string? ProfileImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
        // foreign key for the User entity
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; } = null;

        // Navigation property for the many-to-many relationship with Course
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
