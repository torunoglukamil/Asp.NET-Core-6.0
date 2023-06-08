using PostgreSql_API_3.Entities;
using PostgreSql_API_3.Models;

namespace PostgreSqlExample.Controllers
{
    public class StudentDbController
    {
        private SchoolContext _context;

        public StudentDbController(SchoolContext context)
        {
            _context = context;
        }

        public List<StudentModel> GetStudents() 
        {
            List<StudentModel> studentList = new List<StudentModel>();
            _context.Students.ToList().ForEach(student => studentList.Add(new StudentModel()
            {
                id = student.Id,
                first_name = student.FirstName,
                last_name = student.LastName,
                age = student.Age,
                email = student.Email,
                phone = student.Phone,
                classroom_id = student.ClassroomId,
                Classroom = new ClassroomModel()
                {
                    grade = student.Classroom.Grade,
                    branch = student.Classroom.Branch,
                },
            }));
            return studentList;
        }

        public StudentModel GetStudentById(int id)
        {
            Student student = _context.Students.Where(student => student.Id.Equals(id)).FirstOrDefault()!;
            return new StudentModel()
            {
                id = student.Id,
                first_name = student.FirstName,
                last_name = student.LastName,
                age = student.Age,
                email = student.Email,
                phone = student.Phone,
                classroom_id = student.ClassroomId,
                Classroom = new ClassroomModel()
                {
                    grade = student.Classroom.Grade,
                    branch = student.Classroom.Branch,
                },
            };
        }

        public void CreateStudent(StudentModel student)
        {
            _context.Students.Add(new Student()
            {
                Id = student.id,
                FirstName = student.first_name,
                LastName = student.last_name,
                Age = student.age,
                Email = student.email,
                Phone = student.phone,
                ClassroomId = student.classroom_id,
                //Classroom = student.Classroom,
                // TEST ET
            });
            _context.SaveChanges();
        }

        public void UpdateStudent(StudentModel student)
        {
            Student _student = _context.Students.Where(_student => _student.Id.Equals(student.id)).FirstOrDefault()!;
            _student.FirstName = student.first_name;
            _student.LastName = student.last_name;
            _student.Age = student.age;
            _student.Email = student.email;
            _student.Phone = student.phone;
            _student.ClassroomId = student.classroom_id;
            //_student.Classroom = student.Classroom,
            // TEST ET
            _context.SaveChanges();
        }

        public void DeleteStudentById(int id)
        {
            Student student = _context.Students.Where(student => student.Id.Equals(id)).FirstOrDefault()!;
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}
