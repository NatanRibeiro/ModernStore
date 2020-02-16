
using Xunit;

namespace ModernStore.Domain.Test
{
    public class CustomerTests : Shared.Entities
    {
        [Fact]
        public void GivenAnInvalidFirstNameShouldReturnANotification()
        {
            //var customer = new Customer(this.nameOnlyLast, this.email, this.validDocument, this.user);
            //Assert.False(customer.IsValid());
        }

        [Fact]
        public void GivenAnInvalidLastNameShouldReturnANotification()
        {
            //var customer = new Customer(this.nameOnlyFirst, this.email, this.validDocument, this.user);
            //Assert.False(customer.IsValid());
        }

        [Fact]
        public void GivenAnInvalidEmailShouldReturnANotification()
        {
        //    var customer = new Customer(this.name, this.invalidEmail, this.validDocument, this.user);
        //    Assert.False(customer.IsValid());
        }
    }
}
