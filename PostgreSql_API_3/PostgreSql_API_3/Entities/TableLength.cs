using System;
using System.Collections.Generic;

namespace PostgreSql_API_3.Entities;

public partial class TableLength
{
    public string TableName { get; set; } = null!;

    public int Length { get; set; }
}
