using Microsoft.AspNetCore.Mvc;
using Entities;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/<ProductsController>

        IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            IEnumerable<Product> p = await productService.Get();
            return p == null? NoContent(): Ok(p);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
