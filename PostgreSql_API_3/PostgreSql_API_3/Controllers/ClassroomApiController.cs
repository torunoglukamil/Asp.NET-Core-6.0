using Microsoft.AspNetCore.Mvc;
using PostgreSql_API_3.Entities;
using PostgreSql_API_3.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostgreSqlExample.Controllers
{
    [ApiController]
    public class ClassroomApiController : ControllerBase
    {
        private readonly ClassroomDbController _db;

        public ClassroomApiController(SchoolContext context)
        {
            _db = new ClassroomDbController(context);
        }

        // GET: api/<ApiController>
        [HttpGet]
        [Route("api/[controller]/GetClassrooms")]
        public IActionResult Get()
        {
            try
            {
                List<ClassroomModel> classroomList = _db.GetClassrooms();
                return Ok(classroomList);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET api/<ApiController>/5
        [HttpGet]
        [Route("api/[controller]/GetClassroomById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                ClassroomModel classroom = _db.GetClassroomById(id);
                return Ok(classroom);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST api/<ApiController>
        [HttpPost]
        [Route("api/[controller]/CreateClassroom")]
        public IActionResult Post([FromBody] ClassroomModel classroom)
        {
            try
            {
                _db.CreateClassroom(classroom);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // PUT api/<ApiController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateClassroom")]
        public IActionResult Put([FromBody] ClassroomModel classroom)
        {
            try
            {
                _db.UpdateClassroom(classroom);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE api/<ApiController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteClassroomById/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _db.DeleteClassroomById(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
