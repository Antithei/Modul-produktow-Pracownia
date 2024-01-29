using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<RazorPagesMovieContext>>()))
            {
                if (context == null || context.Product == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext or Products");
                }

                // Look for any products.
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }

                context.Product.AddRange(
                    new Product
                    {
                        Title = "Butter",
                        Description = "bsdfukbs",
                        CreationDate = DateTime.Parse("2023-01-01"),
                        ImageUrl = "url_to_image_for_product_1",
                        IsDeleted = false
                    },

                    new Product
                    {
                        Title = "Product 2",
                        Description = "Description for Product 2",
                        CreationDate = DateTime.Parse("2023-01-02"),
                        ImageUrl = "url_to_image_for_product_2",
                        IsDeleted = false
                    },

                    new Product
                    {
                        Title = "Product 3",
                        Description = "Description for Product 3",
                        CreationDate = DateTime.Parse("2023-01-03"),
                        ImageUrl = "url_to_image_for_product_3",
                        IsDeleted = false
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
