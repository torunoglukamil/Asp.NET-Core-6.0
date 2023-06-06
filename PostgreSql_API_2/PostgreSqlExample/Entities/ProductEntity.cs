using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgreSqlExample.Entities
{
    [Table("products")]
    public class ProductEntity
    {
        [Key, Required]
        public int id { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public int size { get; set; }
        public decimal price { get; set; }
    }
}
