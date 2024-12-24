using System.ComponentModel;
using BLL.DAL;

namespace BLL.Models
{
    public class ProductModel // DTO: Data Transfer Object
    {
        public Product Record { get; set; }

        // Display Name for Name
        [DisplayName("Product Name")]
        public string Name => Record.Name;
        
        // This property is useful when you need to access the price in its numeric form
        // (e.g., performing calculations, comparisons, or saving the value).
        [DisplayName("Price")]
        public decimal Price => Record.Price;
        
        [DisplayName("Description")]
        public string Description => Record.Description ?? string.Empty;  // Ensuring non-null for view
        
        [DisplayName("Quantity Available")]
        public int Quantity => Record.Quantity;
        public string Category => Record.Category?.Name; // To handle null Category safely
    }
}