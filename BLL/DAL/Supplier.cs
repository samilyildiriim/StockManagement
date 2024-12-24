using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string ContactInfo { get; set; }

        [StringLength(1000)]
        public string Address { get; set; }

        // Navigation Property: One-to-Many
        public List<Product> Products { get; set; }
    }
}