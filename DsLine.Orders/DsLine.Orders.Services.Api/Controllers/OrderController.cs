using DsLine.Orders.Models.EntitiesDto;
using DsLine.Orders.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DsLine.Orders.Services.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _order;

        public OrderController(IOrderServices order)
        {
            _order = order;
        }
        [HttpPost]
        public ActionResult<object> Post([FromBody] OrderDto order)
        {
            _order.CreateOrderAsync(order);
            return Ok();
        }


        [HttpGet]
        public ActionResult<object> Get()
        {

            return Ok("esta ok");
        }
    }
}