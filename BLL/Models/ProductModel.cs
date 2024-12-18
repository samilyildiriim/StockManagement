
using BLL.DAL;

namespace BLL.Models
{
    public class ProductModel
    {
        public Product Record { get; set; }

        public string Name => Record.Name;
        public decimal Price => Record.Price;
        public string Description => Record.Description;
        public int Quantity => Record.Quantity;

    }
}