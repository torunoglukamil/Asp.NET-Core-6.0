using PostgreSqlExample.Context;
using PostgreSqlExample.Entities;

namespace PostgreSqlExample.Models
{
    public class ProductDbHelper
    {
        private EntityDbContext _context;

        public ProductDbHelper(EntityDbContext context)
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
            ProductEntity? product = _context.Products.Where(product => product.id.Equals(id)).FirstOrDefault();
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

        public void CreateProduct(ProductModel product)
        {
            _context.Products.Add(new ProductEntity()
            {
                id = product.id,
                name = product.name,
                brand = product.brand,
                size = product.size,
                price = product.price,
            });
            _context.SaveChanges();
        }

        public void UpdateProduct(ProductModel product)
        {
            ProductEntity? _product = _context.Products.Where(_product => _product.id.Equals(product.id)).FirstOrDefault();
            if (_product != null)
            {
                _product.name = product.name;
                _product.brand = product.brand;
                _product.size = product.size;
                _product.price = product.price;
            }
            _context.SaveChanges();
        }

        public void DeleteProductById(int id)
        {
            ProductEntity? product = _context.Products.Where(product => product.id.Equals(id)).FirstOrDefault();
            if(product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
