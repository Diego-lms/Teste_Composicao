using System;
using System.Collections.Generic;
using Exercicio_1.Entities.Enums;
using System.Text;

namespace Exercicio_1.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }
      
      
        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0;
            foreach(OrderItem item in Items)
            {
                sum += item.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder s1 = new StringBuilder();
            s1.AppendLine("Order Sumary: ");
            s1.Append("Order Moment: ");
            s1.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            s1.Append("Status: ");
            s1.AppendLine(Status.ToString());
            s1.Append("Client: ");
            s1.Append(Client.Name);
            s1.Append(" " + Client.BirthDate.ToString("dd/MM/yyyy"));
            s1.AppendLine(" - " + Client.Email);
            s1.AppendLine("Order Items: ");
            foreach(OrderItem item in Items)
            {
                s1.AppendLine();
                s1.Append(item.Product.Name);
                s1.Append(", $: " + item.Product.Price);
                s1.Append("  Quantity: ");
                s1.Append(", " + item.Quantity);
                s1.Append("  Subtotal: ");
                s1.Append(item.SubTotal());
                s1.AppendLine();
            }
            s1.AppendLine("  Total Price: " + Total());
            return s1.ToString();

        }

    }
}
