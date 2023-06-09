﻿namespace PostgreSql_API_3.Models;

public class StudentModel
{
    public int id { get; set; }

    public string first_name { get; set; } = null!;

    public string last_name { get; set; } = null!;

    public short age { get; set; }

    public string email { get; set; } = null!;

    public string? phone { get; set; }

    public int classroom_id { get; set; }

    public ClassroomModel? Classroom { get; set; }
}
