using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(100)]
        public string Role { get; set; } // e.g., Admin, Manager, Staff
    }
}