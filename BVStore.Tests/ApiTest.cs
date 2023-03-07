using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using BVStore.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BVStore.API.Controllers;
using BVStore.API.Services;
using Microsoft.Extensions.Logging;
using BVStore.Domain.Models;
using System.Diagnostics;
using BVStore.Infrastructure;
using BVStore.Domain.Contracts;
using Moq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BVStore.API.Configuration;

namespace BVStore.Tests
{
    [TestClass]
    public class TestSimpleProductController 
    {
        private OrderService _orderService;

        private static IMapper _mapper;

        public TestSimpleProductController()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new OrderProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [TestMethod]
        public void GetOrdersForCustomer_ShouldReturnCustomerOrders()
        {
            var customerId = 2;
            var order = new Order() { Id = 2, OrderId = 43141 };
            var productRepositoryMock = new Mock<IGenericRepository<Order>>();

            productRepositoryMock.Setup(m => m.GetByID(customerId)).Returns(order).Verifiable();


            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m=>m.OrderRepository).Returns(productRepositoryMock.Object);

            OrderService os = new OrderService(unitOfWorkMock.Object,_mapper);

            var result = os.GetOrders(customerId);

            Assert.IsNotNull(result);
        }

    }
    public static class MockDBSetExtension
    {
        public static void SetSource<T>(this Mock<DbSet<T>> mockSet, IList<T> source) where T : class
        {
            var data = source.AsQueryable();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        }
    }
}