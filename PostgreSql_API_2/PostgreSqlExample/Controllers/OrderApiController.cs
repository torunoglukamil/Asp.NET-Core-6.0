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
                bool result = _db.CreateOrder(order);
                if (!result)
                {
                    return NotFound();
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
        [Route("api/[controller]/UpdateOrder")]
        public IActionResult Put([FromBody] OrderModel order)
        {
            try
            {
                bool result = _db.UpdateOrder(order);
                if (!result)
                {
                    return NotFound();
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
        [Route("api/[controller]/DeleteOrderById/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool result = _db.DeleteOrderById(id);
                if (!result)
                {
                    return NotFound();
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
