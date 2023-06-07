using PostgreSqlExample.Context;
using PostgreSqlExample.Entities;

namespace PostgreSqlExample.Models
{
    public class OrderDbHelper
    {
        private EntityDbContext _context;

        public OrderDbHelper(EntityDbContext context)
        {
            _context = context;
        }

        public List<OrderModel> GetOrders()
        {
            List<OrderModel> orders = new List<OrderModel>();
            _context.Orders.ToList().ForEach(order => orders.Add(new OrderModel()
            {
                id = order.id,
                //product_id = order.Product.id,
                // HATA VERİYOR
                name = order.name,
                address = order.address,
                phone = order.phone,
            }));
            return orders;
        }

        public OrderModel? GetOrderById(int id)
        {
            OrderEntity? order = _context.Orders.Where(order => order.id.Equals(id)).FirstOrDefault();
            if (order == null)
            {
                return null!;
            }
            return new OrderModel()
            {
                id = order.id,
                product_id = order.Product.id,
                name = order.name,
                address = order.address,
                phone = order.phone,
            };
        }

        public void CreateOrder(OrderModel order)
        {
            ProductEntity? product = _context.Products.Where(product => product.id.Equals(order.product_id)).FirstOrDefault();
            if (product != null)
            {
                _context.Orders.Add(new OrderEntity()
                {
                    id = order.id,
                    Product = product,
                    name = order.name,
                    address = order.address,
                    phone = order.phone,
                });
                _context.SaveChanges();
            }
        }

        public void UpdateOrder(OrderModel order)
        {
            OrderEntity? _order = _context.Orders.Where(_order => _order.id.Equals(order.id)).FirstOrDefault();
            if (_order != null)
            {
                _order.address = order.address;
                _order.phone = order.phone;
                _context.SaveChanges();
            }
        }

        public void DeleteOrderById(int id)
        {
            OrderEntity? order = _context.Orders.Where(order => order.id.Equals(id)).FirstOrDefault();
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
