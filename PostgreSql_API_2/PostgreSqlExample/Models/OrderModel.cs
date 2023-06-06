namespace PostgreSqlExample.Models
{
    public class OrderModel
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
    }
}
