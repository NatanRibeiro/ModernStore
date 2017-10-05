
using ModernStore.Domain.Entities;
using System.Data.Entity;

namespace ModernStore.Infra.Contexts
{
    public class ModernStoreDataContext : DbContext
    {
        public ModernStoreDataContext()
            //: base("ModernStoreConnectionString")
            : base(@"Server=NATAN;Database=ModernStore;Trusted_Connection=True;")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Customer> Customers {get; set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
