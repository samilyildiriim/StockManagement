using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // Navigation Property: One-to-Many
        public List<Product> Products { get; set; }
    }
}