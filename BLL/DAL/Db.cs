using Microsoft.EntityFrameworkCore;

namespace BLL.DAL
{
    // The DbContext class is the central part of Entity Framework.
    // It represents the session with the database, providing APIs to query and save data.
    // It maps entities to database tables and provides a bridge between the application and the database.
    public class Db : DbContext
    {
        public DbSet<Product> Products { get; set; }    // Represents the Product Table
        public DbSet<Category> Categories { get; set; } // Represents the Category Table
     
        // In order to use defined database, send the connectionString to the Db() constructor
        // Inject the object containing the connectionString to the Db.cs class
        
        public Db(DbContextOptions options) : base(options)
        {
            
        }
    }
}