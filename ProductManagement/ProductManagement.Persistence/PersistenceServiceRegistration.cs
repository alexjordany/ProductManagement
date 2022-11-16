using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Application.Contracts.Persistence;
using ProductManagement.Persistence.Repositories;

namespace ProductManagement.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ProductManagementDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ProductManagementConnectionString"));
        });

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}