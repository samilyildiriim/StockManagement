using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface ICategoryService
    {
        public IQueryable<CategoryModel> Query();
        public ServiceBase Create(Category record);
        public ServiceBase Update(Category record);
        public ServiceBase Delete(int id);
    }

    public class CategoryService : ServiceBase, ICategoryService
    {
        public CategoryService(Db db) : base(db)
        {
        }

        public IQueryable<CategoryModel> Query()
        {
            return _Db.Categories.OrderBy(c => c.Name).Select(c => new CategoryModel() { Record = c });
        }

        public ServiceBase Create(Category record)
        {
            if (_Db.Categories.Any(c => c.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Category with the same name exists!");
            record.Name = record.Name?.Trim();
            _Db.Categories.Add(record);
            _Db.SaveChanges(); // commit to the database
            return Success("Category created successfully.");
        }

        public ServiceBase Update(Category record)
        {
            if (_Db.Categories.Any(c => c.Id != record.Id && c.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Category with the same name exists!");
            
            var entity = _Db.Categories.SingleOrDefault(c => c.Id == record.Id);
            if (entity is null)
                return Error("Category can't be found!");
            
            entity.Name = record.Name?.Trim();
            _Db.Categories.Update(entity);
            _Db.SaveChanges(); // commit to the database
            return Success("Category updated successfully.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _Db.Categories.Include(c => c.Products).SingleOrDefault(c => c.Id == id);
            if (entity is null)
                return Error("Category can't be found!");
            
            if (entity.Products.Any()) // Count > 0
                return Error("Category has relational pets!");
            
            _Db.Categories.Remove(entity);
            _Db.SaveChanges(); // commit to the database
            return Success("Category deleted successfully.");
        }
    }
}
