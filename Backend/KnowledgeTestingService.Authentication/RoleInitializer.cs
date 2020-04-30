using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace KnowledgeTestingService.Authentication
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string adminUserName = "Admin";
            const string adminEmail = "admin@gmail.com";
            const string adminPassword = "Qwerty123#";

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                var adminUser = new User { UserName = adminUserName, Email = adminEmail };
                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "admin");
                    await userManager.AddToRoleAsync(adminUser, "user");
                    await userManager.SetLockoutEnabledAsync(adminUser, false);
                }
            }
        }
    }
}