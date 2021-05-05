using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialData.Data
{
    public class UserCreator
    {
        UserManager<IdentityUser> User;


        public static void SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            CreateUsers(userManager);
        }

        public static void CreateUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("user@mail.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "user@mail.com";
                user.Email = "user@mail.com";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "User123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }


            if (userManager.FindByNameAsync("admin@mail.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "admin@mail.com";
                user.Email = "admin@mail.com";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "Admin123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrator";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }


        public UserCreator(UserManager<IdentityUser> user)
        {
            User = user;
        }

    }
}
