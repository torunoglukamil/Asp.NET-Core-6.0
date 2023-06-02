using PostgreSqlExample.Context;
using PostgreSqlExample.Entities;

namespace PostgreSqlExample.Models
{
    public class DbHelper
    {
        private EntityDbContext _context;

        public DbHelper(EntityDbContext context)
        {
            _context = context;
        }

        public List<ProductModel> GetProducts() 
        { 
            List<ProductModel> products = new List<ProductModel>();
            _context.Products.ToList().ForEach(product => products.Add(new ProductModel()
            {
                id = product.id,
                name = product.name,
                brand = product.brand,
                size = product.size,
                price = product.price,
            }));
            return products;
        }

        public ProductModel? GetProductById(int id)
        {
            var product = _context.Products.Where(product => product.id.Equals(id)).FirstOrDefault();
            if(product == null)
            {
                return null!;
            }
            return new ProductModel()
            {
                id = product.id,
                name = product.name,
                brand = product.brand,
                size = product.size,
                price = product.price,
            };
        }

        public void SaveOrder(OrderModel orderModel)
        {
            if(orderModel.id > 0)
            {
                var order = _context.Orders.Where(order => order.id.Equals(orderModel.id)).FirstOrDefault();
                if(order != null)
                {
                    order.phone = orderModel.phone;
                    order.address = orderModel.address;
                }
            }
            else
            {
               _context.Orders.Add(new Order()
               {
                   phone = orderModel.phone,
                   address = orderModel.address,
                   name = orderModel.name,
                   Product = _context.Products.Where(product => product.id.Equals(orderModel.product_id)).FirstOrDefault(),
               });
            }
            _context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = _context.Orders.Where(order => order.id.Equals(id)).FirstOrDefault();
            if(order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
