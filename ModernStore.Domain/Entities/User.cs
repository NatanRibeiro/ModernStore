using System;

namespace ModernStore.Domain.Entities
{
    public class User
    {
        public User(string username, string password)
        {
            this.Id = Guid.NewGuid();
            this.Username = username;
            this.Password = password;
            this.Active = true;
        }

        public void Activate() => this.Active = true;

        public void DeActivate() => this.Active = false;

        public Guid Id { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public bool Active { get; private set; }
    }
}
