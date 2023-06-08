using PostgreSql_API_3.Entities;
using PostgreSql_API_3.Models;

namespace PostgreSqlExample.Controllers
{
    public class ClassroomDbController
    {
        private SchoolContext _context;

        public ClassroomDbController(SchoolContext context)
        {
            _context = context;
        }

        public List<ClassroomModel> GetClassrooms() 
        {
            List<ClassroomModel> classroomList = new List<ClassroomModel>();
            _context.Classrooms.ToList().ForEach(classroom => classroomList.Add(new ClassroomModel()
            {
                id = classroom.Id,
                grade = classroom.Grade,
                branch = classroom.Branch,
                //Students = classroom.Students,
                // TEST ET
            }));
            return classroomList;
        }

        public ClassroomModel GetClassroomById(int id)
        {
            Classroom classroom = _context.Classrooms.Where(classroom => classroom.Id.Equals(id)).FirstOrDefault()!;
            return new ClassroomModel()
            {
                id = classroom.Id,
                grade = classroom.Grade,
                branch = classroom.Branch,
                //Students = classroom.Students,
                // TEST ET
            };
        }

        public void CreateClassroom(ClassroomModel classroom)
        {
            _context.Classrooms.Add(new Classroom()
            {
                Id = classroom.id,
                Grade = classroom.grade,
                Branch = classroom.branch,
                //Students = classroom.Students,
                // TEST ET
            });
            _context.SaveChanges();
        }

        public void UpdateClassroom(ClassroomModel classroom)
        {
            Classroom _classroom = _context.Classrooms.Where(_classroom => _classroom.Id.Equals(classroom.id)).FirstOrDefault()!;
            _classroom.Grade = classroom.grade;
            _classroom.Branch = classroom.branch;
            //_classroom.Students = classroom.Students,
            // TEST ET
            _context.SaveChanges();
        }

        public void DeleteClassroomById(int id)
        {
            Classroom classroom = _context.Classrooms.Where(classroom => classroom.Id.Equals(id)).FirstOrDefault()!;
            _context.Classrooms.Remove(classroom);
            _context.SaveChanges();
        }
    }
}
