using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Contracts.Persistence;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Persistence.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ProductManagementDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Product>> GetProductsByName(string name)
    {
        var productsByName = await _dbContext.Products.Where(x =>
                x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase) || string.IsNullOrWhiteSpace(name))
            .ToListAsync();
        return productsByName;
    }
}