using Newtonsoft.Json;
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

        public ResponseModel GetClassrooms()
        {
            ResponseModel response = _db.SelectQuery("select * from classrooms order by id");
            if(response.Type == ResponseType.Success) {
                return new ResponseModel()
                {
                    Type = response.Type,
                    Data = JsonConvert.DeserializeObject<List<ClassroomModel>>((string) response.Data)!,
                };
            }
            return response;
        }

        public ResponseModel GetClassroomById(int id)
        {
            ResponseModel response = _db.SelectQuery($"select * from classrooms where id = {id}");
            if (response.Type == ResponseType.Success)
            {
                List<ClassroomModel> classroomList = JsonConvert.DeserializeObject<List<ClassroomModel>>((string) response.Data) ?? new List<ClassroomModel>();
                if (!classroomList.Any())
                {
                    return new ResponseModel()
                    {
                        Type = ResponseType.NotFound,
                        Data = "NotFound",
                    };
                }
                return new ResponseModel()
                {
                    Type = response.Type,
                    Data = classroomList.First(),
                };
            }
            return response;
        }

        public ResponseModel CreateClassroom(ClassroomModel classroom) => _db.CommandQuery($"insert into classrooms (grade, branch) values ({classroom.grade}, '{classroom.branch}')");

        public ResponseModel UpdateClassroom(ClassroomModel classroom) => _db.CommandQuery($"update classrooms set grade = {classroom.grade}, branch = '{classroom.branch}' where id = {classroom.id}");

        public ResponseModel DeleteClassroomById(int id) => _db.CommandQuery($"delete from classrooms where id = {id}");
    }
}
