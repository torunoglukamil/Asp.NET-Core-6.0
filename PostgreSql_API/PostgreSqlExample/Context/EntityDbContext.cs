using Microsoft.EntityFrameworkCore;
using PostgreSqlExample.Entities;

namespace PostgreSqlExample.Context
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext(DbContextOptions<EntityDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
