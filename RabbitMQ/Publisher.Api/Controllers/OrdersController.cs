using Microsoft.AspNetCore.Mvc;
using Publisher.Api.Models;
using Publisher.Api.RabbitMq.IServices;

namespace Publisher.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMessageProducer _messagePublisher;

        public OrdersController(IMessageProducer MessagePublisher)
        {
            _messagePublisher = MessagePublisher;
        }
        [HttpPost("PostOrder")]
        public async Task<IActionResult> PostOrderAsync(Orders orders)
        {
            _messagePublisher.SendMessage(orders);
            return Ok();
        }
    }
}
