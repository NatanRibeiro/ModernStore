using FluentValidator;
using ModernStore.Shared.Commands;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.ValueObjects;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Services;
using ModernStore.Domain.Resources;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Commands.Inputs;

namespace ModernStore.Domain.Commands.Handlers
{
    public class CustomerCommandHandler : Notifiable, ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        public CustomerCommandHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(RegisterCustomerCommand command)
        {
            //Step 1 - Check if already exists
            if (_customerRepository.DocumentExists(command.Document))
            {
                AddNotification("Document", "This document already is in use!");
                return null;
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
            _emailService.Send(
                customer.Name.ToString(), 
                customer.Email.Address, 
                string.Format(EmailTemplates.WelcomeEmailTitle, customer.Name), 
                string.Format(EmailTemplates.WelcomeEmailBody, customer.Name)
                );

            //Step 6 - Return something
            return new RegisterCustomerCommandResult(customer.Id, customer.Name.ToString());
        }
    }
}
