using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new() { Name = "Football net", Price = 25 },
            new() { Name = "Surf board", Price = 179 },
            new() { Name = "Running shoes", Price = 95 }
        }.AsQueryable();
    }
}