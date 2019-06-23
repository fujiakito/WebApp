namespace WebApp.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApp.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Products.AddOrUpdate(p => p.Id,
                new Models.Product { Id = 1, Name = "Item 1", Quantity = 10, SaleAmount = 100 },
                new Models.Product { Id = 2, Name = "Item 2", Quantity = 10, SaleAmount = 100 },
                new Models.Product { Id = 3, Name = "Item 3", Quantity = 10, SaleAmount = 100 },
                new Models.Product { Id = 4, Name = "Item 4", Quantity = 10, SaleAmount = 100 },
                new Models.Product { Id = 5, Name = "Item 5", Quantity = 10, SaleAmount = 100 },
                new Models.Product { Id = 6, Name = "Item 6", Quantity = 10, SaleAmount = 100 },
                new Models.Product { Id = 7, Name = "Item 7", Quantity = 10, SaleAmount = 100 },
                new Models.Product { Id = 8, Name = "Item 8", Quantity = 10, SaleAmount = 100 },
                new Models.Product { Id = 9, Name = "Item 9", Quantity = 10, SaleAmount = 100 },
                new Models.Product { Id = 10, Name = "Item 10", Quantity = 10, SaleAmount = 100 },
                new Models.Product { Id = 11, Name = "Item 11", Quantity = 10, SaleAmount = 100 },
                new Models.Product { Id = 12, Name = "Item 12", Quantity = 10, SaleAmount = 100 },
                new Models.Product { Id = 13, Name = "Item 13", Quantity = 10, SaleAmount = 100 },
                new Models.Product { Id = 14, Name = "Item 14", Quantity = 10, SaleAmount = 100 },
                new Models.Product { Id = 15, Name = "Item 15", Quantity = 10, SaleAmount = 100 },
                new Models.Product { Id = 16, Name = "Item 16", Quantity = 10, SaleAmount = 100 },
                new Models.Product { Id = 17, Name = "Item 17", Quantity = 10, SaleAmount = 100 },
                new Models.Product { Id = 18, Name = "Item 18", Quantity = 10, SaleAmount = 100 },
                new Models.Product { Id = 19, Name = "Item 19", Quantity = 10, SaleAmount = 100 },
                new Models.Product { Id = 20, Name = "Item 20", Quantity = 10, SaleAmount = 100 }
            );
        }
    }
}
