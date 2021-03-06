namespace EFDbFirstApproachExample.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Company.DataLayer.CompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Company.DataLayer.CompanyDbContext context)
        {
            //context.Brands.AddOrUpdate(new Models.Brand { BrandID = 1, BrandName = "Samsung" }, new Models.Brand { BrandID = 2, BrandName = "Apple" }, new Models.Brand { BrandID = 3, BrandName = "Sony" }, new Models.Brand { BrandID = 4, BrandName = "HP" });
            //context.Categories.AddOrUpdate(new Models.Category { CategoryID = 1, CategoryName = "Electronics" }, new Models.Category { CategoryID = 2, CategoryName = "Home Appliances" });
            //context.Products.AddOrUpdate(new Models.Product { ProductID = 1, ProductName = "Samsung Galaxy Mobile", CategoryID = 1, BrandID = 1, DOP = DateTime.Now, Active = true, Photo = null, Price = 10000, AvailabilityStatus = "Instock" });
        }
    }
}
