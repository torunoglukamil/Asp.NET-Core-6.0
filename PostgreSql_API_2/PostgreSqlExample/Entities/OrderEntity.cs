using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgreSqlExample.Entities
{
    [Table("orders")]
    public class OrderEntity
    {
        [Key, Required]
        public int id { get; set; }
        public virtual ProductEntity Product { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
    }
}
