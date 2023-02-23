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

        //var dbContext = new MockDbContext();
        //var unitOfWork = new UnitOfWork(dbContext, repositoryFactory);

        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            //var controller = new OrderProcessingController();

            //OrderDTO order = new OrderDTO();
            //OrderDTO ooo = new OrderDTO();

            //ooo.CustomerId = 1;
            //ooo.OrderId = 777646361;
            //ooo.TotalPrice = 120.00m;
            //List<ProductDTO> products = new List<ProductDTO>();

            //for (int i = 0; i < 5; i++)
            //{
            //    ProductDTO product = new ProductDTO();

            //    product.ProductId = i + 1;
            //    product.PricePerUnit = i + 1.13m;
            //    product.Quantity = i + 2;
            //    product.ProductType = i % 2 == 0 ? BVStore.Domain.Enums.ProductType.Physical : BVStore.Domain.Enums.ProductType.Online;
            //    if (i == 4)
            //    {
            //        product.ProductType = BVStore.Domain.Enums.ProductType.VideoMembership;
            //    }

            //    products.Add(product);
            //}

            //ooo.Products = products;


            //var result = controller.PurchaseOrder(ooo) as List<Product>;
            //Assert.AreEqual(testProducts.Count, result.Count);
        }

    }
}