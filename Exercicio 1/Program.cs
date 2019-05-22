using System;
using System.Collections.Generic;
using Exercicio_1.Entities.Enums;
using Exercicio_1.Entities;
using System.Globalization;

namespace Exercicio_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Entrada de dados do cliente
            Console.WriteLine("Enter Client Data: ");
            Console.WriteLine();
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birthday: ");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());

            //Instanciado o cliente
            Client client = new Client(name, email, birthdate);

            Console.WriteLine();

            //Entrada de dados do pedido
            Console.WriteLine("Enter order Data: ");
            Console.Write("Status: ");
            Enum.TryParse<OrderStatus>(Console.ReadLine(), out OrderStatus status);
            Console.WriteLine();
            Console.WriteLine("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            //Instanciado o pedido
            Order order = new Order(DateTime.Now, status, client);
            //Declara uma nova lista de itens
            for ( int i = 1; i <= n; i++)
            {
                //Entrada de dados do produto
                Console.WriteLine($"Enter de #{i} item data: ");
                Console.Write("Product name: ");
                string namePrd = Console.ReadLine();
                Console.Write("Product price: ");
                double pricePrd = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int Qty = int.Parse(Console.ReadLine());
                //Instanciado um novo produto
                Product product = new Product(namePrd, pricePrd);

                //instancia a nova lista de itens passando o produto
                OrderItem orderItem = new OrderItem();
                orderItem.Quantity = Qty;
                orderItem.Price = pricePrd;
                orderItem.Product = product;
                //Adiciona a lista de itens no pedido
                order.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine(order);

        }
    }
}
