using Microsoft.AspNetCore.Mvc;
using PostgreSqlExample.Context;
using PostgreSqlExample.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostgreSqlExample.Controllers
{
    [ApiController]
    public class ShoppingApiController : ControllerBase
    {
        private readonly DbHelper _db;

        public ShoppingApiController(EntityDbContext context)
        {
            _db = new DbHelper(context);
        }

        // GET: api/<ApiController>
        [HttpGet]
        [Route("api/[controller]/GetProducts")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var products = _db.GetProducts();
                if(!products.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetApiResponse(type, products));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseHandler.GetExeptionResponse(e));
            }
        }

        // GET api/<ApiController>/5
        [HttpGet]
        [Route("api/[controller]/GetProductById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var product = _db.GetProductById(id);
                if (product == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetApiResponse(type, product));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseHandler.GetExeptionResponse(e));
            }
        }

        // POST api/<ApiController>
        [HttpPost]
        [Route("api/[controller]/SaveOrder")]
        public IActionResult Post([FromBody] OrderModel model)
        {
            try
            {
                _db.SaveOrder(model);
                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, model));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseHandler.GetExeptionResponse(e));
            }
        }

        // PUT api/<ApiController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateOrder")]
        public IActionResult Put(int id, [FromBody] OrderModel model)
        {
            try
            {
                _db.SaveOrder(model);
                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, model));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseHandler.GetExeptionResponse(e));
            }
        }

        // DELETE api/<ApiController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteOrder/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _db.DeleteOrder(id);
                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, "Successfully Deleted"));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseHandler.GetExeptionResponse(e));
            }
        }
    }
}
