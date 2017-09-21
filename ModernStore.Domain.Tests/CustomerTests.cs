using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class CustomerTests : Shared.Entities
    {
        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidFirstNameShouldReturnANotification()
        {
            var customer = new Customer(this.nameOnlyLast, this.email, this.validDocument, this.user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidLastNameShouldReturnANotification()
        {
            var customer = new Customer(this.nameOnlyFirst, this.email, this.validDocument, this.user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidEmailShouldReturnANotification()
        {
            var customer = new Customer(this.name, this.invalidEmail, this.validDocument, this.user);
            Assert.IsFalse(customer.IsValid());
        }
    }
}
