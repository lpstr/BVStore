using BVStore.API.Services;
using BVStore.Domain.Models;
using BVStore.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BVStore.API.Controllers
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
        public IActionResult Get(int customerId)
        {
            try
            {
                var orders = _service.GetOrders(customerId);


                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

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
    }
}
