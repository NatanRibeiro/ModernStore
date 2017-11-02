using FluentValidator;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class OrderItem : Entity
    {
        protected OrderItem()
        {
            
        }

        public OrderItem(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
            this.Price = Product.Price;

            new ValidationContract<OrderItem>(this)
                .IsGreaterThan(x => x.Quantity, 1)
                .IsGreaterThan(x => x.Product.QuantityOnHand, Quantity + 1, $"Oops, quantity available for this product: { this.Product.QuantityOnHand }");

            this.Product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }

        public int Quantity { get; private set; }

        public decimal Price { get; private set; }

        public decimal Total() => this.Price * this.Quantity;
    }
}