using PostgreSqlExample.Context;
using PostgreSqlExample.Entities;
using PostgreSqlExample.Models;

namespace PostgreSqlExample.Controllers
{
    public class ProductDbController
    {
        private EntityDbContext _context;

        public ProductDbController(EntityDbContext context)
        {
            _context = context;
        }

        public List<ProductModel> GetProducts() 
        { 
            List<ProductModel> productList = new List<ProductModel>();
            _context.Products.ToList().ForEach(product => productList.Add(new ProductModel()
            {
                id = product.id,
                name = product.name,
                brand = product.brand,
                size = product.size,
                price = product.price,
            }));
            return productList;
        }

        public ProductModel? GetProductById(int productId)
        {
            ProductEntity? product = _context.Products.Where(product => product.id.Equals(productId)).FirstOrDefault();
            if(product == null)
            {
                return null;
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

        public bool CreateProduct(ProductModel product)
        {
            ProductEntity? _product = _context.Products.Where(_product => _product.id.Equals(product.id)).FirstOrDefault();
            if (_product != null)
            {
                return false;
            }
            _context.Products.Add(new ProductEntity()
            {
                id = product.id,
                name = product.name,
                brand = product.brand,
                size = product.size,
                price = product.price,
            });
            _context.SaveChanges();
            return true;
        }

        public bool UpdateProduct(ProductModel product)
        {
            ProductEntity? _product = _context.Products.Where(_product => _product.id.Equals(product.id)).FirstOrDefault();
            if (_product == null)
            {
                return false;
            }
            _product.name = product.name;
            _product.brand = product.brand;
            _product.size = product.size;
            _product.price = product.price;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteProductById(int productId)
        {
            ProductEntity? product = _context.Products.Where(product => product.id.Equals(productId)).FirstOrDefault();
            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }
    }
}
