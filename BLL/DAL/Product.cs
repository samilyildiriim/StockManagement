using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int Quantity { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
        
        public decimal Price { get; set; }

        // Foreign Key
        [Required(ErrorMessage = "Category is required!!")]
        public int CategoryId { get; set; }

        // Navigation Property
        public Category Category { get; set; }

        // Navigation Property: Many-to-Many
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}