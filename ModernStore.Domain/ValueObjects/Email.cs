using FluentValidator;

namespace ModernStore.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        protected Email()
        {
            
        }

        public Email(string address)
        {
            this.Address = address;

            new ValidationContract<Email>(this)
                .IsEmail(x => x.Address, "Invalid Email!");
        }

        public string Address { get; private set; }
    }
}
