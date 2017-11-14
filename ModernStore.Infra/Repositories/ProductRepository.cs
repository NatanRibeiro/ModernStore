using System;
using System.Linq;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;

namespace ModernStore.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ModernStoreDataContext _context;

        public ProductRepository(ModernStoreDataContext context) => _context = context;

        public Product Get(Guid id) => _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == id);

        public void Save(Order order) => _context.Orders.Add(order);
    }
}