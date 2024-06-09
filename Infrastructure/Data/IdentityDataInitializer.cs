using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class IdentityDataInitializer
    {
        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedSuperUser(userManager);
        }
        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("SuperUser").Result)
            {
                var role = new IdentityRole { Name = "SuperUser" };
                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole { Name = "User" };
                roleManager.CreateAsync(role).Wait();
            }
        }
        private static void SeedSuperUser(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("superuser@example.com").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "superuser",
                    Email = "superuser@example.com"
                };

                var result = userManager.CreateAsync(user, "SuperPassword123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "SuperUser").Wait();
                }
            }
        }
    }
}
