using Microsoft.AspNetCore.Identity;
using ProductManagement.Identity.Models;

namespace ProductManagement.Identity.Seed;

public static class CreateFirstUser
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
    {
        var applicationUser = new ApplicationUser
        {
            FirstName = "Admin",
            LastName = "Admin",
            UserName = "adminuser",
            Email = "admin@productmanagement.com",
            EmailConfirmed = true
        };

        var user = await userManager.FindByEmailAsync(applicationUser.Email);
        if (user == null)
        {
            await userManager.CreateAsync(applicationUser, "Admin&2022?");
        }
    }
}