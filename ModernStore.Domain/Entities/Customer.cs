using System;
using ModernStore.Shared.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(Name name, Email email, Document document, User user)
        {
            this.Name = name;
            this.Birthdate = null;
            this.Email = email;
            this.User = user;
            this.Document = document;

            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(document.Notifications);
        }

        public void Update(Name name, DateTime birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public bool IsValid() => this.Notifications.Count < 0;
        
        public Name Name { get; private set; } 

        public DateTime? Birthdate { get; private set; }

        public User User { get; private set; }

        public Email Email { get; private set; }

        public Document Document { get; private set; }
    }
}