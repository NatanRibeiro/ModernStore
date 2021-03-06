﻿using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class Product : Entity
    {
        protected Product()
        {
            
        }

        public Product(string title, decimal price, string image, int quantityOnHand)
        {
            this.Title = title;
            this.Price = price;
            this.Image = image;
            this.QuantityOnHand = quantityOnHand;
        }

        public string Title { get; private set; }

        public decimal Price { get; private set; }

        public string Image { get; private set; }

        public int QuantityOnHand { get; private set; }

        public void DecreaseQuantity(int quantity) => this.QuantityOnHand -= quantity;
    }
}
