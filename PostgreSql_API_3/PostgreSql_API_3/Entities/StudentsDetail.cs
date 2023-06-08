using System;
using System.Collections.Generic;

namespace PostgreSql_API_3.Entities;

public partial class StudentsDetail
{
    public int? FirstName { get; set; }

    public string? LastName { get; set; }

    public short? Age { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? ClassroomId { get; set; }

    public short? Grade { get; set; }

    public string? Branch { get; set; }
}
