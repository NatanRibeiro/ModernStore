using System;
using FluentValidator;
using ModernStore.Domain.Commands;
using ModernStore.Shared.Commands;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.ValueObjects;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.CommandHandlers
{
    public class CustomerCommandHandler : Notifiable, ICommandHandler<UpdateCustomerCommand>, ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Handle(UpdateCustomerCommand command)
        {
            //Step 1 - Check if already exists
            var customer = _customerRepository.Get(command.Id);

            //Step 2 - Check if exists
            if (customer == null)
            {
                AddNotification("Customer", "Client not found");
                return;
            }

            //Step 3 - Update the entity
            var name = new Name(command.FirstName, command.LastName);
            customer.Update(name, command.Birthdate);

            //Step 4 - Update the database
            if (IsValid())
                _customerRepository.Update(customer);
        }

        public void Handle(RegisterCustomerCommand command)
        {
            //Step 1 - Check if already exists
            if (_customerRepository.DocumentExists(command.Document))
            {
                AddNotification("Document", "This document already is in use!");
                return;
            }

            //Step 2 - Create a new client
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var user = new User(command.Username, command.Password, command.ConfirmPassword);
            var customer = new Customer(name, email, document, user);

            //Step 3 - Add notifications
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(user.Notifications);
            AddNotifications(customer.Notifications);

            //Step 4 - Insert into database
            if (IsValid())
                _customerRepository.Save(customer);

            //Step 5 - Send a Welcome email.
            if (IsValid())
                _customerRepository.Update(customer);

        }
    }
}
