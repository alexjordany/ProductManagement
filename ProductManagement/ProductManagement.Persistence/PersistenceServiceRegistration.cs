using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductManagement.Application.Contracts.Persistence;
using ProductManagement.Persistence.Repositories;

namespace ProductManagement.Persistence;

public static class PersistenceServiceRegistration
{

    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment)
    {
        if(!environment.IsEnvironment("Development"))
            services.AddDbContext<ProductManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("PMConnectionString"));
            });

        services.AddDbContext<ProductManagementDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ProductManagementConnectionString"));
        });


        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}