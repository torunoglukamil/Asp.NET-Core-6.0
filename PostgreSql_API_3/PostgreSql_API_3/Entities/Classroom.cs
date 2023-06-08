using System;
using System.Collections.Generic;

namespace PostgreSql_API_3.Entities;

public partial class Classroom
{
    public int Id { get; set; }

    public short Grade { get; set; }

    public string Branch { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
