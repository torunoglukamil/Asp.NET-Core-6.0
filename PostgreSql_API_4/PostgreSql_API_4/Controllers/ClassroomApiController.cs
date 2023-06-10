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

        private ObjectResult SendResponse(ResponseModel response)
        {
            switch (response.Type)
            {
                case ResponseType.Success:
                    return Ok(response.Data);
                case ResponseType.NotFound:
                    return NotFound(response.Data);
                default:
                    return BadRequest(response.Data);
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetClassrooms")]
        public IActionResult Get() => SendResponse(_db.GetClassrooms());

        [HttpGet]
        [Route("api/[controller]/GetClassroomById/{id}")]
        public IActionResult Get(int id) => SendResponse(_db.GetClassroomById(id));

        [HttpPost]
        [Route("api/[controller]/CreateClassroom")]
        public IActionResult Post([FromBody] ClassroomModel classroom) => SendResponse(_db.CreateClassroom(classroom));

        [HttpPut]
        [Route("api/[controller]/UpdateClassroom")]
        public IActionResult Put([FromBody] ClassroomModel classroom) => SendResponse(_db.UpdateClassroom(classroom));

        [HttpDelete]
        [Route("api/[controller]/DeleteClassroomById/{id}")]
        public IActionResult Delete(int id) => SendResponse(_db.DeleteClassroomById(id));
    }
}
