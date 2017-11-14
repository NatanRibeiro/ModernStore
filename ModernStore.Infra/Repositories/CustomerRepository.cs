using System;
using System.Data.Entity;
using System.Linq;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;

namespace ModernStore.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ModernStoreDataContext _context;

        public CustomerRepository(ModernStoreDataContext context) => _context = context;

        public Customer Get(Guid id) => _context.Customers.Include(x => x.User).FirstOrDefault(x => x.Id == id);

        public Customer Get(string document) => _context.Customers.Include(x => x.Document).FirstOrDefault(x => x.Document.Number == document);

        public Customer GetByUserId(Guid id) => _context.Customers.Include(x => x.User).AsNoTracking().FirstOrDefault(x => x.User.Id == id);

        public void Update(Customer customer) => _context.Entry(customer).State = EntityState.Modified;

        public bool DocumentExists(string document) => _context.Customers.Include(x => x.Document).AsNoTracking().Any(x => x.Document.Number == document);

        public void Save(Customer customer) => _context.Customers.Add(customer);
    }
}
