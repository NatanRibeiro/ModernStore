using FluentValidator;

namespace ModernStore.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            new ValidationContract<Name>(this)
                .IsRequired(x => x.FirstName, "First Name is mandatory!")
                .HasMinLenght(x => x.FirstName, 3)
                .HasMaxLenght(x => x.FirstName, 60)
                .IsRequired(x => x.LastName, "Last Name is mandatory!")
                .HasMinLenght(x => x.LastName, 3)
                .HasMaxLenght(x => x.LastName, 60);
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        
    }
}
