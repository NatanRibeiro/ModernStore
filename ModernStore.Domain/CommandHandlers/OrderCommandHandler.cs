﻿using FluentValidator;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.CommandHandlers
{
    public class OrderCommandHandler : Notifiable, ICommandHandler<RegisterOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(ICustomerRepository customerRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public void Handle(RegisterOrderCommand command)
        {
            //Step 1 - Check if already exists
            var customer = _customerRepository.GetByUserId(command.Customer);
            var order = new Order(customer, command.DeliveryFee, command.Discount);

            //Step 2 - Update the entity
            foreach (var item in command.Items)
            {
                var product = _productRepository.Get(item.Product);
                order.AddItem(new OrderItem(product, item.Quantity));
            }

            AddNotifications(order.Notifications);

            //Step 3 - Update the database
            if (order.IsValid())
                _orderRepository.Save(order);
        }
    }
}
