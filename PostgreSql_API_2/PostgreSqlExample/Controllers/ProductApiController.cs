using Microsoft.AspNetCore.Mvc;
using PostgreSqlExample.Context;
using PostgreSqlExample.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostgreSqlExample.Controllers
{
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly ProductDbController _db;

        public ProductApiController(EntityDbContext context)
        {
            _db = new ProductDbController(context);
        }

        // GET: api/<ApiController>
        [HttpGet]
        [Route("api/[controller]/GetProducts")]
        public IActionResult Get()
        {
            try
            {
                List<ProductModel> productList = _db.GetProducts();
                return Ok(productList);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET api/<ApiController>/5
        [HttpGet]
        [Route("api/[controller]/GetProductById/{id}")]
        public IActionResult Get(int productId)
        {
            try
            {
                ProductModel? product = _db.GetProductById(productId);
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
                bool result = _db.CreateProduct(product);
                if (!result)
                {
                    NotFound();
                }
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
        public IActionResult Put([FromBody] ProductModel product)
        {
            try
            {
                bool result = _db.UpdateProduct(product);
                if (!result)
                {
                    NotFound();
                }
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
        public IActionResult Delete(int productId)
        {
            try
            {
                bool result = _db.DeleteProductById(productId);
                if (!result)
                {
                    NotFound();
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
