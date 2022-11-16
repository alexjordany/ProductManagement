using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Identity.Models;

namespace ProductManagement.Identity;

public class ProductManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public ProductManagementIdentityDbContext(DbContextOptions<ProductManagementIdentityDbContext> options) : base(options)
    {
        
    }
}