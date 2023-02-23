using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using BVStore.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoodeosStore.Controllers;
using BoodeosStore.Services;
using Microsoft.Extensions.Logging;
using BVStore.Domain.Models;
using System.Diagnostics;
using BVStore.Infrastructure;

namespace BVStore.Tests
{
    [TestClass]
    public class TestSimpleProductController 
    {
        private OrderService _orderService;

        var dbContext = new MockDbContext();
        var repositoryFactory = new MemoryRepositoryFactory();
        var unitOfWork = new UnitOfWork(dbContext, repositoryFactory);

        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            _orderService = orderService;   
            var testProducts = GetTestProducts();
            var controller = new OrderProcessingController(logger,orderService);

            OrderDTO order = new OrderDTO();
            OrderDTO ooo = new OrderDTO();

            ooo.CustomerId = 1;
            ooo.OrderId = 777646361;
            ooo.TotalPrice = 120.00m;
            List<ProductDTO> products = new List<ProductDTO>();

            for (int i = 0; i < 5; i++)
            {
                ProductDTO product = new ProductDTO();

                product.ProductId = i + 1;
                product.PricePerUnit = i + 1.13m;
                product.Quantity = i + 2;
                product.ProductType = i % 2 == 0 ? BVStore.Domain.Enums.ProductType.Physical : BVStore.Domain.Enums.ProductType.Online;
                if (i == 4)
                {
                    product.ProductType = BVStore.Domain.Enums.ProductType.VideoMembership;
                }

                products.Add(product);
            }

            ooo.Products = products;


            var result = controller.PurchaseOrder(ooo) as List<Product>;
            Assert.AreEqual(testProducts.Count, result.Count);
        }

        //[TestMethod]
        //public async Task GetAllProductsAsync_ShouldReturnAllProducts()
        //{
        //    var testProducts = GetTestProducts();
        //    var controller = new SimpleProductController(testProducts);

        //    var result = await controller.GetAllProductsAsync() as List<Product>;
        //    Assert.AreEqual(testProducts.Count, result.Count);
        //}

        //[TestMethod]
        //public void GetProduct_ShouldReturnCorrectProduct()
        //{
        //    var testProducts = GetTestProducts();
        //    var controller = new SimpleProductController(testProducts);

        //    var result = controller.GetProduct(4) as OkNegotiatedContentResult<Product>;
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(testProducts[3].Name, result.Content.Name);
        //}

        //[TestMethod]
        //public async Task GetProductAsync_ShouldReturnCorrectProduct()
        //{
        //    var testProducts = GetTestProducts();
        //    var controller = new SimpleProductController(testProducts);

        //    var result = await controller.GetProductAsync(4) as OkNegotiatedContentResult<Product>;
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(testProducts[3].Name, result.Content.Name);
        //}

        //[TestMethod]
        //public void GetProduct_ShouldNotFindProduct()
        //{
        //    var controller = new SimpleProductController(GetTestProducts());

        //    var result = controller.GetProduct(999);
        //    Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        //}

        private List<Product> GetTestProducts()
        {
            var testProducts = new List<Product>();
            testProducts.Add(new Product { Id = 1, Name = "Demo1", Price = 1 });
            testProducts.Add(new Product { Id = 2, Name = "Demo2", Price = 3.75M });
            testProducts.Add(new Product { Id = 3, Name = "Demo3", Price = 16.99M });
            testProducts.Add(new Product { Id = 4, Name = "Demo4", Price = 11.00M });

            return testProducts;
        }
    }
}