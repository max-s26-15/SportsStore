using System.Linq;

namespace SportsStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;

        public EFProductRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Product> Products => _context.Products;

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
                _context.Products.Add(product);
            else
            {
                Product dbEntry = _context.Products
                    .FirstOrDefault(p => p.ProductId == product.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            _context.SaveChanges();
        }
    }
}