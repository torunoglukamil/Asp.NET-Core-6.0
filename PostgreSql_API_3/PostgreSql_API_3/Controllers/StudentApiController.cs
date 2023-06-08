using Microsoft.AspNetCore.Mvc;
using PostgreSql_API_3.Entities;
using PostgreSql_API_3.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostgreSqlExample.Controllers
{
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly StudentDbController _db;

        public StudentApiController(SchoolContext context)
        {
            _db = new StudentDbController(context);
        }

        // GET: api/<ApiController>
        [HttpGet]
        [Route("api/[controller]/GetStudents")]
        public IActionResult Get()
        {
            try
            {
                List<StudentModel> studentList = _db.GetStudents();
                return Ok(studentList);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET api/<ApiController>/5
        [HttpGet]
        [Route("api/[controller]/GetStudentById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                StudentModel student = _db.GetStudentById(id);
                return Ok(student);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST api/<ApiController>
        [HttpPost]
        [Route("api/[controller]/CreateStudent")]
        public IActionResult Post([FromBody] StudentModel student)
        {
            try
            {
                _db.CreateStudent(student);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // PUT api/<ApiController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateStudent")]
        public IActionResult Put([FromBody] StudentModel student)
        {
            try
            {
                _db.UpdateStudent(student);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE api/<ApiController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteStudentById/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _db.DeleteStudentById(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
