using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lemon.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Lemon.Models
{
    public static class SeedData
    {
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            var userManager = app.ApplicationServices.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
            context.Database.Migrate();

            if (!context.Roles.Any())
            {
                IdentityRole role = new IdentityRole("Admin");
                var x = await roleManager.CreateAsync(role);
            }
            
            if (!context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "lemonadmin@lemon.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "lemonadmin@lemon.com"
                };
                var x = await userManager.CreateAsync(user, "i@maLemony1");
            }

            if (!context.UserRoles.Any())
            {
                var roleUser = await GetDefaultUser(userManager, "lemonadmin@lemon.com");
                var x = await userManager.AddToRoleAsync(roleUser, "Admin");

            }

            if (!context.Purchases.Any())
            {
                context.Purchases.AddRange(
                    new Purchase
                    {
                        PurchaseName = "Lemon Zester",
                        Description = "A handy tool that will add some citrusy zest to your cooking",
                        Price = 12.95f
                    },
                    new Purchase
                    {
                        PurchaseName = "Big Lemon",
                        Description = "This is a big lemon!",
                        Price = 30
                    },
                    new Purchase
                    {
                        PurchaseName = "Moist Lemon",
                        Description = "A juicy lemon",
                        Price = 15
                    },
                    new Purchase
                    {
                        PurchaseName = "Lemon Shoes",
                        Description = "All natural remedy for athlete's foot",
                        Price = 90
                    },
                    new Purchase
                    {
                        PurchaseName = "Lemon Stationary",
                        Description = "Hand-write letters and send them on a summer's breeze",
                        Price = 9.95f
                    },
                    new Purchase
                    {
                        PurchaseName = "Lemon Envelopes",
                        Description = "Go great with Lemon Stationary",
                        Price = 21.95f
                    },
                    new Purchase
                    {
                        PurchaseName = "Lemon Tree",
                        Description = "An entire, living lemon tree.",
                        Price = 295.95f
                    },
                    new Purchase
                    {
                        PurchaseName = "A case of lemons",
                        Description = "Forty pounds of fresh lemons in corrugated cardboard with artwork",
                        Price = 39.95f
                    },
                    new Purchase
                    {
                        PurchaseName = "Lemon Shirt",
                        Description = "It's like a hawaiian shirt, but with Lemon Print instead. Includes Free Straw Hat",
                        Price = 24.95f
                    }
                );
                context.SaveChanges();
            }//end purchases

            if (!context.Fruits.Any())
            {
                context.Fruits.AddRange(
                    new Fruit
                    {
                        Name = "Eureka",
                        Soil = "Well-Draining",
                        Feature = "Year round fruit",
                        Water = "Generously"
                    },

                    new Fruit
                    {
                        Name = "Pink Variegated",
                        Soil = "Well-Draining",
                        Feature = "Pink Flesh",
                        Water = "Generously"
                    },
                    new Fruit
                    {
                        Name = "Lisbon",
                        Soil = "Well-Draining",
                        Feature = "Heat and wind tolerant",
                        Water = "Medium"
                    },
                    new Fruit
                    {
                        Name = "Meyer",
                        Soil = "Well-Draining",
                        Feature = "Dwarf variety",
                        Water = "Moist Soil"
                    },
                    new Fruit
                    {
                        Name = "Primofiori",
                        Soil = "Well-Draining",
                        Feature = "Fruits Heavily",
                        Water = "Moist Soil"
                    },
                    new Fruit
                    {
                        Name = "Verna",
                        Soil = "Well-Draining",
                        Feature = "Vigorous Growth",
                        Water = "Moist Soil"
                    }

                );
                context.SaveChanges();
            }//end fruits
        }//end EnsurePopulated

        private static async Task<ApplicationUser> GetDefaultUser(UserManager<ApplicationUser> um,  string email)
        {
            var createdUser = await um.FindByEmailAsync(email);
            return createdUser;
        }


    }
}
