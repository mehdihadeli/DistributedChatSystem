﻿using System.Threading.Tasks;
using BlazorChat.Shared;
using Microsoft.AspNetCore.Identity;

namespace Chat.Infrastructure.IdentityData
{
    public static class IdentitySeeder
    {
        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var firstUser = new ApplicationUser
            {
                Email = "mehdi@yahoo.com",
                UserName = "mehdi@yahoo.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var secondUser = new ApplicationUser
            {
                Email = "mehdi1@yahoo.com",
                UserName = "mehdi1@yahoo.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var thirdUser = new ApplicationUser
            {
                Email = "mehdi2@yahoo.com",
                UserName = "mehdi2@yahoo.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var user1 = await userManager.FindByEmailAsync(firstUser.Email);
            var user2 = await userManager.FindByEmailAsync(secondUser.Email);
            var user3 = await userManager.FindByEmailAsync(thirdUser.Email);

            if (user1 == null)
            {
                await userManager.CreateAsync(firstUser, "Mehdi_000000");
            }

            if (user2 == null)
            {
                await userManager.CreateAsync(secondUser, "Mehdi_000000");
            }

            if (user3 == null)
            {
                await userManager.CreateAsync(thirdUser, "Mehdi_000000");
            }
        }
    }
}