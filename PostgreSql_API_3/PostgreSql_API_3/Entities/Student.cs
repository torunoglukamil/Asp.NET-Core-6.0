using System;
using System.Collections.Generic;

namespace PostgreSql_API_3.Entities;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public short Age { get; set; }

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public int ClassroomId { get; set; }

    public virtual Classroom Classroom { get; set; } = null!;
}
