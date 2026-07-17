using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudentManagementSystemDb.Models
{
    public class Student
    {
        [Key] // primary key 
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string email { get; set; }= string.Empty;

        [Range(1, 50)]
        public int age { get; set; }

        // foreign key
        public int CourseId { get; set; }

        // navigation property
        [ForeignKey("CourseId")]
        public Course ? Course {  get; set; }

    }
}
