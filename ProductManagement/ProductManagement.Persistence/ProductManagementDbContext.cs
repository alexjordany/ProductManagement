using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Persistence;

public class ProductManagementDbContext : DbContext
{
    public ProductManagementDbContext(DbContextOptions options) : base(options)
    {
            
    }
    
    public DbSet<Product> Products { get; set; }
}