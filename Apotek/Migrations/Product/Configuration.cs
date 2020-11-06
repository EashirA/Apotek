using Apotek.DbContext;
using Apotek.Models;

namespace Apotek.Migrations.Product
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Apotek.DbContext.ApotekDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Product";
        }

        protected override void Seed(ApotekDbContext context)
        {
            context.CategoriesTable.AddOrUpdate(c => c.CategoryId,
                            new Category
                            {
                                CategoryId = 1,
                                CategoryName = "Tablet",
                                CategoryDescription = "A tablet is a pharmaceutical oral dosage form (OSD). Tablets may be defined as the solid unit dosage form " +
                                                      "of medicament or medicaments with suitable excipients and prepared either by molding or by compression. " +
                                                      "It comprises a mixture of active substances and excipients, usually in powder form, pressed or compacted from " +
                                                      "a powder into a solid dose. "
                            },
                            new Category
                            {
                                CategoryId = 2,
                                CategoryName = "Cosmetics",
                                CategoryDescription = "Cosmetics are substances or products used to enhance or alter the appearance of the face or fragrance and texture" +
                                                      " of the body. Many cosmetics are designed for use of applying to the face and body. " +
                                                      "They are generally mixtures of chemical compounds; some being derived from natural sources " +
                                                      "(such as coconut oil), and many synthetic or artificial."
                            },
                            new Category
                            {
                                CategoryId = 3,
                                CategoryName = "Shampoo",
                                CategoryDescription = "Shampoo is a hair care product, typically in the form of a viscous liquid," +
                                                      " that is used for cleaning hair. Less commonly, shampoo is available in bar form, like a bar " +
                                                      "of soap. Shampoo is used by applying it to wet hair, massaging the product into the hair, and then" +
                                                      " rinsing it out. Some users may follow a shampooing with the use of hair conditioner."
                            }
                            );
            context.SaveChanges();

            context.ProductsTable.AddOrUpdate(x => x.ProductId,
                new Models.Product
                {
                    ProductId = 1,
                    ProductDetail = "Etiam tempor orci eu lobortis elementum nibh tellus molestie.",
                    ProductName = "Pouri Vitamin D ",
                    ProductPrice = 75,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 1),

                },
                new Models.Product
                {
                    ProductId = 2,
                    ProductDetail = "Etiam tempor orci eu lobortis elementum nibh tellus molestie. Neque egestas congue quisque egestas.  ",
                    ProductName = "Omega-3 Aktiv",
                    ProductPrice = 100,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 1),

                },
                new Models.Product
                {
                    ProductId = 3,
                    ProductDetail = " Neque egestas congue quisque egestas.",
                    ProductName = "Wellness Collagen Beauty ",
                    ProductPrice = 150,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 2),

                },
                new Models.Product
                {
                    ProductId = 4,
                    ProductDetail = " Vulputate mi sit amet mauris. Sodales neque sodales ut etiam sit.",
                    ProductName = "Face Night Cream ",
                    ProductPrice = 199,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 2),

                },
                new Models.Product
                {
                    ProductId = 5,
                    ProductDetail = "Sodales neque sodales ut etiam sit. Dignissim suspendisse in est ante in.",
                    ProductName = "Sunsilk Ultra Care",
                    ProductPrice = 80,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 3),

                }, new Models.Product
                {
                    ProductId = 6,
                    ProductDetail = " Dignissim suspendisse in est ante in. ",
                    ProductName = "Palmoliv Natural",
                    ProductPrice = 75,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 3),

                }
                );
            context.SaveChanges();
        }
    }
}
