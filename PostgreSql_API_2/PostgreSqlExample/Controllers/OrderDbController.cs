using PostgreSqlExample.Context;
using PostgreSqlExample.Entities;
using PostgreSqlExample.Models;

namespace PostgreSqlExample.Controllers
{
    public class OrderDbController
    {
        private EntityDbContext _context;

        public OrderDbController(EntityDbContext context)
        {
            _context = context;
        }

        public List<OrderModel> GetOrders()
        {
            List<OrderModel> orderList = new List<OrderModel>();
            _context.Orders.ToList().ForEach(order => orderList.Add(new OrderModel()
            {
                id = order.id,
                //product_id = order.Product.id,
                // HATA VERİYOR
                name = order.name,
                address = order.address,
                phone = order.phone,
            }));
            return orderList;
        }

        public OrderModel? GetOrderById(int orderId)
        {
            OrderEntity? order = _context.Orders.Where(order => order.id.Equals(orderId)).FirstOrDefault();
            if (order == null)
            {
                return null;
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

        public bool CreateOrder(OrderModel order)
        {
            OrderEntity? _order = _context.Orders.Where(_order => _order.id.Equals(order.id)).FirstOrDefault();
            ProductEntity? product = _context.Products.Where(product => product.id.Equals(order.product_id)).FirstOrDefault();
            if (product == null || _order != null)
            {
                return false;
            }
            _context.Orders.Add(new OrderEntity()
            {
                id = order.id,
                Product = product,
                name = order.name,
                address = order.address,
                phone = order.phone,
            });
            _context.SaveChanges();
            return true;
        }

        public bool UpdateOrder(OrderModel order)
        {
            OrderEntity? _order = _context.Orders.Where(_order => _order.id.Equals(order.id)).FirstOrDefault();
            if (_order == null)
            {
                return false;
            }
            _order.address = order.address;
            _order.phone = order.phone;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteOrderById(int orderId)
        {
            OrderEntity? order = _context.Orders.Where(order => order.id.Equals(orderId)).FirstOrDefault();
            if (order == null)
            {
                return false;
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return true;
        }
    }
}
