using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendingWithPlugins.DataService
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal TotalAmount => Items.Sum(item => item.TotalPrice);
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public Order(int orderId, string customerName, DateTime orderDate)
        {
            OrderId = orderId;
            CustomerName = customerName;
            OrderDate = orderDate;
        }

        public void PrintOrderSummary()
        {
            Console.WriteLine($"Order ID: {OrderId}");
            Console.WriteLine($"Customer: {CustomerName}");
            Console.WriteLine($"Date: {OrderDate}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine("Items:");
            foreach (var item in Items)
            {
                Console.WriteLine($" - {item.ProductName}: {item.Quantity} x {item.Price} = {item.TotalPrice:C}");
            }
            Console.WriteLine($"Total Amount: {TotalAmount:C}");
        }
    }

    public class OrderItem
    {
        public int ItemId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Quantity * Price;

        public OrderItem(int itemId, string productName, int quantity, decimal price)
        {
            ItemId = itemId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }
    }
}
