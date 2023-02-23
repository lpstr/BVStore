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
    }
}
