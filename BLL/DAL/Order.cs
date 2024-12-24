using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public bool IsPurchase { get; set; } // True for purchase, False for sale

        // Foreign Key
        public int CustomerId { get; set; }

        // Navigation Property
        public Customer Customer { get; set; }

        // Navigation Property: One-to-Many
        public List<OrderItem> OrderItems { get; set; }
    }
}