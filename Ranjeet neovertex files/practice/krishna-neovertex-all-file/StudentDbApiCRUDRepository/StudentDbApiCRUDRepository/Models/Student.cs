using System.ComponentModel.DataAnnotations;

namespace StudentDbApiCRUDRepository.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Range(1, 100)]
        public int Age { get; set; }

        [Required]
        public string? Address { get; set; }
    }
}