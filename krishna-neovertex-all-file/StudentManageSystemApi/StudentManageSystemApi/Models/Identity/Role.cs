using System.ComponentModel.DataAnnotations;
using StudentManageSystemApi.Models.Base;
namespace StudentManageSystemApi.Models.Identity
{
    public class Role : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        // Navigation property for the many-to-many relationship with User
        public ICollection<Role> UserRoles { get; set; } = new List<Role>();
    }
}
