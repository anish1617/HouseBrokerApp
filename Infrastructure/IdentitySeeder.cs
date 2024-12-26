using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class IdentitySeeder
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var roles = new[] { "HouseSeeker", "Broker" };

            foreach(var role in roles)
            {
                if(!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // optional to create admin user
            var adminEmail = "admin@housebroker.com";
            var adminPassword = "Admin@123";

            if(await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail };
                await userManager.CreateAsync(adminUser, adminPassword);
                await userManager.AddToRoleAsync(adminUser, "Broker");
            }
        }
    }
}
