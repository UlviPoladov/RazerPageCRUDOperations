using Microsoft.EntityFrameworkCore;
using WebApplication2.Entities;

namespace WebApplication2.Data
{
    public class ProductDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductDBContext(DbContextOptions <ProductDBContext> options )
            : base( options )
        {
            
        }


    }
}
