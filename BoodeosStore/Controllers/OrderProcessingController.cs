using BoodeosStore.Services;
using BVStore.Domain.Models;
using BVStore.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BoodeosStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderProcessingController : ControllerBase
    {
        private OrderService _service;

        private readonly ILogger<OrderProcessingController> _logger;

        public OrderProcessingController(ILogger<OrderProcessingController> logger, OrderService service)
        {
            _logger = logger;
            _service = service;
        }


        [HttpGet(Name = "GetOrders")]
        public string Get()
        {
            var test = _service.GetOrders(2);
            //_service.Test();
            //var test = _unitOfWork.ProductRepository.Get().ToList();

            return string.Empty;
        }

        [HttpPost(Name="PurchaseOrder")]
        public IActionResult PurchaseOrder(OrderDTO orderDTO)
        {
            try
            {
                var result = _service.ProcessOrder(orderDTO);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost(Name = "ProcessOrder")]
        public IActionResult ProcessOrder()
        {
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

            _service.ProcessOrder(ooo);

            return Ok("test");
        }
    }
}
