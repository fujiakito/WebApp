using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Tests
{
    [TestClass]
    public class TestProductsController
    {
        [TestMethod]
        public void PostProduct_ShouldReturnSameProduct()
        {
            var controller = new ProductsController(new TestWebAppContext());

            var item = new PutProductsDto
            {
                Id = Guid.NewGuid().ToString(),
                Timestamp = DateTime.Now,
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Test1", Quantity = 20, SaleAmount = 10 }
                }
            };

            Task.Run(async () =>
            {
                var result = await controller.PostProduct(item) as CreatedAtRouteNegotiatedContentResult<PutProductsDto>;

                Assert.IsNotNull(result);
                Assert.AreEqual(result.RouteName, "DefaultApi");
                Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
                Assert.AreEqual(result.Content.Timestamp, item.Timestamp);
            });
        }

        [TestMethod]
        public void GetProducts_ShouldReturnAllProducts()
        {
            var context = new TestWebAppContext();

            context.Products.Add(new Product { Id = 1, Name = "Demo1", Quantity = 20, SaleAmount = 10 });
            context.Products.Add(new Product { Id = 2, Name = "Demo2", Quantity = 30, SaleAmount = 10 });
            context.Products.Add(new Product { Id = 3, Name = "Demo3", Quantity = 40, SaleAmount = 10 });

            var controller = new ProductsController(context);

            var result = controller.GetProducts();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Products.Count);
        }
    }
}
