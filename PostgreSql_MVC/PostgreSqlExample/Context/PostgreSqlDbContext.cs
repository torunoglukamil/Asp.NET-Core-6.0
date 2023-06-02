using Microsoft.EntityFrameworkCore;
using PostgreSqlExample.Models;

namespace PostgreSqlExample.Context
{
    public class PostgreSqlDbContext : DbContext
    {
        public PostgreSqlDbContext(DbContextOptions<PostgreSqlDbContext> options) : base(options) {}

        public DbSet<Student> Students { get; set; }
    }
}
