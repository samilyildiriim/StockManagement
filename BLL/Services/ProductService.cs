using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    // Way 1: (If you don't use IService<Product, ProductModel>)
    // public interface IProductService
    // {
    //     public IQueryable<ProductModel> Query();
    //     public ServiceBase Create(Product record);
    //     public ServiceBase Update(Product record);
    //     public ServiceBase Delete(int id);
    //
    // }
    // public class ProductService : ServiceBase, IProductService 
    
    // Way 2:
    public class ProductService : ServiceBase, IService<Product, ProductModel>
    {
        public ProductService(Db db) : base(db)
        {
        }

        public IQueryable<ProductModel> Query()
        {
            return _Db.Products.Include(p => p.Category).OrderByDescending(p => p.Price).ThenBy(p => p.Name).ThenBy(p => p.Quantity)
                .Select(p => new ProductModel() { Record = p });

        }

        public ServiceBase Create(Product record)
        {
            if (_Db.Products.Any(p =>
                    p.Name.ToLower() == record.Name.ToLower().Trim() && p.Price == record.Price &&
                    p.Quantity == record.Quantity))
                return Error("Product with the same name, price and quantity already exists!");

            record.Name = record.Name?.ToLower();
            _Db.Products.Add(record);
            _Db.SaveChanges();

            return Success("Product created successfully.");
        }

        public ServiceBase Update(Product record)
        {
            if (_Db.Products.Any(p => p.Id != record.Id && p.Name.ToLower() == record.Name.ToLower().Trim() &&
                                      p.Price == record.Price && p.Quantity == record.Quantity))
                return Error("Product with the same name, price and quantity already exists!");

            record.Name = record.Name?.Trim();
            _Db.Products.Update(record);
            _Db.SaveChanges();

            return Success("Product updated successfully.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _Db.Products.Include(p => p.OrderItems).SingleOrDefault(p => p.Id == id);
            if (entity is null)
                return Error("Product cannot be found!");
            
            _Db.OrderItems.RemoveRange(entity.OrderItems);
            _Db.Products.Remove(entity);
            _Db.SaveChanges();

            return Success("Product deleted successfully.");
        }
    }

}