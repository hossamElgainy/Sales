using Microsoft.AspNetCore.Identity;
using SalesProject.Domain.DomaimModels.Users;

namespace SalesProject.DataSeeding
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var adminRole = "User";

            // Ensure the admin role exists
            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }
           
            var defaultUser = new ApplicationUser { UserName = "hossamelsayed676@gmail.com", Email = "hossamelsayed676@gmail.com", EmailConfirmed = true };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                var result = await userManager.CreateAsync(defaultUser, "Hossam#103");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(defaultUser, adminRole);
                }
            }
        }
    }
}
