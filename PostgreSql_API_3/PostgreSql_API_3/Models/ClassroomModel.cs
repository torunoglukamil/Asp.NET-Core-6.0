namespace PostgreSql_API_3.Models;

public class ClassroomModel
{
    public int id { get; set; }

    public short grade { get; set; }

    public string branch { get; set; } = null!;

    public ICollection<StudentModel>? Students { get; set; } = new List<StudentModel>();
}
