using Microsoft.AspNetCore.Mvc;
using PostgreSqlExample.Context;
using PostgreSqlExample.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostgreSqlExample.Controllers
{
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly ProductDbHelper _db;

        public ProductApiController(EntityDbContext context)
        {
            _db = new ProductDbHelper(context);
        }

        // GET: api/<ApiController>
        [HttpGet]
        [Route("api/[controller]/GetProducts")]
        public IActionResult Get()
        {
            try
            {
                List<ProductModel> products = _db.GetProducts();
                if (!products.Any())
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET api/<ApiController>/5
        [HttpGet]
        [Route("api/[controller]/GetProductById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                ProductModel? product = _db.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST api/<ApiController>
        [HttpPost]
        [Route("api/[controller]/CreateProduct")]
        public IActionResult Post([FromBody] ProductModel product)
        {
            try
            {
                _db.CreateProduct(product);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // PUT api/<ApiController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateProduct")]
        public IActionResult Put(int id, [FromBody] ProductModel product)
        {
            try
            {
                _db.UpdateProduct(product);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE api/<ApiController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteProductById/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _db.DeleteProductById(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
