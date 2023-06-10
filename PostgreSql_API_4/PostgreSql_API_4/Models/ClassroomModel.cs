namespace PostgreSql_API_4.Models;

public class ClassroomModel
{
    public int id { get; set; }
    public short grade { get; set; }
    public string branch { get; set; } = null!;
}
