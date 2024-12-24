using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        // Foreign Key
        public int OrderId { get; set; }

        // Navigation Property
        public Order Order { get; set; }

        // Foreign Key
        public int ProductId { get; set; }

        // Navigation Property
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}