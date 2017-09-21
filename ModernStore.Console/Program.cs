using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;
using System;

namespace ModernStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = new Name("Natan", "Dutra");
            var email = new Email("natan_r.dutra@hotmail.com");
            var document = new Document("1234567890");
            var user = new User("natan.dutra", "123456789");
            var customer = new Customer(name, email, document, user);
            var mouse = new Product("mouse", 299, "mouse.png", 20);
            var mousePad = new Product("mouse pad", 23, "mouse.png", 20);
            var teclado = new Product("teclado", 333, "mouse.png", 20);

            Console.WriteLine($"Previously, the quantity on hand was for Mouse was: { mouse.QuantityOnHand}");
            Console.WriteLine($"Previously, the quantity on hand was for Mouse Pad was: { mousePad.QuantityOnHand}");
            Console.WriteLine($"Previously, the quantity on hand was for Teclado was: { teclado.QuantityOnHand}");

            var order = new Order(customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));
            order.AddItem(new OrderItem(mousePad, 2));
            order.AddItem(new OrderItem(teclado, 2));

            Console.WriteLine($"Numero do Pedido: {order.Number}");
            Console.WriteLine($"Order  Date: {order.CreateDate : dd/MM/yyyy}");
            Console.WriteLine($"Discount: {order.Discount}");
            Console.WriteLine($"Delivery Fee: {order.DeliveryFee}");
            Console.WriteLine($"Sub Total: {order.SubTotal()}");
            Console.WriteLine($"Total: {order.Total()}");
            Console.WriteLine($"Client: {order.Customer.Name.ToString()}");

            Console.WriteLine($"Now, the quantity on hand was for Mouse is: { mouse.QuantityOnHand}");
            Console.WriteLine($"Now, the quantity on hand was for Mouse Pad is: { mousePad.QuantityOnHand}");
            Console.WriteLine($"Now, the quantity on hand was for Teclado is: { teclado.QuantityOnHand}");
            Console.ReadKey();
        }
    }
}
