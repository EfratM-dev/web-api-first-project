using Entities;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService orderService;
        IProductService productsService;


        public OrdersController(IOrderService orderService, IProductService productsService)
        {
            this.orderService = orderService;
            this.productsService = productsService;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            if (orderService.GetById(id) != null)
            {
                return await orderService.GetById(id);
            }
            return NoContent();
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {
            //decimal orderSum = 0;

            //foreach (OrderItem orderItem in order.OrderItems)
            //{
            //    orderSum += orderItem.Quantity * (await productsService.GetById(orderItem.ProductId)).Price;
            //}
            //order.OrderSum = orderSum;
            order = await orderService.Post(order);
            return CreatedAtAction(nameof(Get), new { Id = order.Id }, order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
