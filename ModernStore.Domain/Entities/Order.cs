using FluentValidator;
using ModernStore.Domain.Enums;
using ModernStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModernStore.Domain.Entities
{
    public class Order : Entity
    {
        protected Order()
        {
            
        }

        public Order(Customer customer, decimal deliveryFee, decimal discount)
        {
            this.Customer = customer;
            this.CreateDate = DateTime.Now;
            this.Number = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            this.Status = EOrderStatus.Created;
            this.DeliveryFee = deliveryFee;
            this.Discount = discount;
            this._items = new List<OrderItem>();

            new ValidationContract<Order>(this)
                .IsGreaterThan(x => x.DeliveryFee, 0)
                .IsGreaterThan(x => x.Discount, -1);
        }

        public void AddItem(OrderItem item)
        {
            AddNotifications(item.Notifications);

            if (item.IsValid())
                _items.Add(item);
        }

        private readonly IList<OrderItem> _items;

        public DateTime CreateDate { get; private set; }

        public string Number { get; private set; }

        public EOrderStatus Status { get; private set; }

        public ICollection<OrderItem> Items { get { return _items.ToArray(); }}

        public decimal DeliveryFee { get; private set; }

        public decimal Discount { get; private set; }

        public Customer Customer { get; private set; }

        public decimal SubTotal() => Items.Sum(x => x.Total());

        public decimal Total() => SubTotal() + DeliveryFee - Discount;
    }
}
