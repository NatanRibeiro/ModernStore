using ModernStore.Domain.Entities;
using System;
using ModernStore.Domain.Commands.Results;

namespace ModernStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);

        Customer GetByUsername(string username);

        GetCustomerCommandResult Get(string username);

        Customer GetByUserId(Guid id);

        void Update(Customer customer);

        bool DocumentExists(string document);

        void Save(Customer customer);
    }
}
