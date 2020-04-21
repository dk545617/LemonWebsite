using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lemon.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Lemon.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
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
            }
        }
    }
}
