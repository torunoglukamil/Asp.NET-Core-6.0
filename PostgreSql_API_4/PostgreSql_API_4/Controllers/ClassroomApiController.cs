using Microsoft.AspNetCore.Mvc;
using PostgreSql_API_4.Helpers;
using PostgreSql_API_4.Models;

namespace PostgreSqlExample.Controllers
{
    [ApiController]
    public class ClassroomApiController : ControllerBase
    {
        private readonly ClassroomDbController _db;

        public ClassroomApiController(DbHelper db)
        {
            _db = new ClassroomDbController(db);
        }

        [HttpGet]
        [Route("api/[controller]/GetClassrooms")]
        public IActionResult Get()
        {
            ResponseModel response = _db.GetClassrooms();
            if(response.Type == ResponseType.Success)
            {
                return Ok(response.Data);
            }
            return BadRequest(response.Data);
        }
    }
}
