using Xunit;

namespace ModernStore.Domain.Test
{
    public class OrderTests : Shared.Entities
    {
        //private Customer _customer { get { return this.GenerateNewCustomer();} }

        [Fact]
        public void GivenAnOutOfStockProductItShouldReturnAnError()
        {
            //var mouse = new Product("mouse", 299, "mouse.png", 0);
            //var order = new Order(_customer, 8, 10);
            //order.AddItem(new OrderItem(mouse, 2));

            //Assert.False(order.IsValid());
        }

        [Fact]
        public void GivenAnStockProductItShouldUpdateQuantityOnHand()
        {
            //var mouse = new Product("mouse", 299, "mouse.png", 20);
            //var order = new Order(_customer, 8, 10);
            //order.AddItem(new OrderItem(mouse, 2));

            //Assert.True(mouse.QuantityOnHand == 18);
        }

        [Fact]
        public void GivenAValidOrderTheTotalShouldBe310()
        {
            //var mouse = new Product("mouse", 300, "mouse.png", 20);
            //var order = new Order(_customer, 12, 2);
            //order.AddItem(new OrderItem(mouse, 1));

            //Assert.True(order.Total() == 310);
        }
    }
}