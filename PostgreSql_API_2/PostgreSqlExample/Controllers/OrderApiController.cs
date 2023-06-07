using Microsoft.AspNetCore.Mvc;
using PostgreSqlExample.Context;
using PostgreSqlExample.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostgreSqlExample.Controllers
{
    [ApiController]
    public class OrderApiController : ControllerBase
    {
        private readonly OrderDbController _db;

        public OrderApiController(EntityDbContext context)
        {
            _db = new OrderDbController(context);
        }

        // GET: api/<ApiController>
        [HttpGet]
        [Route("api/[controller]/GetOrders")]
        public IActionResult Get()
        {
            try
            {
                List<OrderModel> orders = _db.GetOrders();
                if (!orders.Any())
                {
                    return NotFound();
                }
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET api/<ApiController>/5
        [HttpGet]
        [Route("api/[controller]/GeOrderById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                OrderModel? order = _db.GetOrderById(id);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST api/<ApiController>
        [HttpPost]
        [Route("api/[controller]/CreateOrder")]
        public IActionResult Post([FromBody] OrderModel order)
        {
            try
            {
                _db.CreateOrder(order);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // PUT api/<ApiController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateOrder")]
        public IActionResult Put(int id, [FromBody] OrderModel order)
        {
            try
            {
                _db.UpdateOrder(order);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE api/<ApiController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteOrderById/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _db.DeleteOrderById(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
