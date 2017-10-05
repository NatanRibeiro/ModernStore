using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.Mappings
{
    class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable("Customer");
            HasKey(x => x.Id);
            Property(x => x.Birthdate);
            Property(x => x.Document.Number);
            Property(x => x.Email.Address);
            Property(x => x.Name.FirstName);
            Property(x => x.Name.LastName);
            Property(x => x.User.Username);
            Property(x => x.User.Password);
            Property(x => x.User.Active);
        }
    }
}
