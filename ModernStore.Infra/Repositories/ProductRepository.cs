using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;
using ModernStore.Shared;

namespace ModernStore.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ModernStoreDataContext _context;

        public ProductRepository(ModernStoreDataContext context) => _context = context;

        public Product Get(Guid id) => _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == id);

        public IEnumerable<GetProductListCommandResult> Get()
        {
            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn.Query<GetProductListCommandResult>("SELECT [Id], [Title], [Price], [Image] FROM [Product]");
            }
        }

        public void Save(Order order) => _context.Orders.Add(order);
    }
}