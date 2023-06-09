using PostgreSql_API_4.Helpers;
using PostgreSql_API_4.Models;

namespace PostgreSqlExample.Controllers
{
    public class ClassroomDbController
    {
        private readonly DbHelper _db;

        public ClassroomDbController(DbHelper db)
        {
            _db = db;
        }

        public ResponseModel GetClassrooms() => _db.SelectQuery("select * from classroom order by id");
    }
}
