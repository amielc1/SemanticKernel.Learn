namespace ExtendingWithPlugins.DataService
{
    public class OrderDataService
    {
        public List<Order> Orders { get; private set; } = new List<Order>();
        private static Random _random = new Random();

        public OrderDataService()
        {
            GenerateSampleOrders();
        }

        private void GenerateSampleOrders()
        {
            Orders.Add(new Order(1, "Emily Carter", GetRandomOrderDate())
            {
                Items =
            {
                new OrderItem(1, "Apple Pie", 2, 12.99m),
                new OrderItem(2, "Cherry Pie", 1, 14.49m)
            },
                Status = OrderStatus.Shipped
            });

            Orders.Add(new Order(2, "Michael Thompson", GetRandomOrderDate())
            {
                Items =
            {
                new OrderItem(3, "Pumpkin Pie", 1, 11.99m),
                new OrderItem(4, "Pecan Pie", 1, 15.99m),
                new OrderItem(5, "Blueberry Pie", 2, 13.49m)
            }
            });

            Orders.Add(new Order(3, "Sophia Lewis", GetRandomOrderDate())
            {
                Items =
            {
                new OrderItem(6, "Strawberry Pie", 3, 13.99m),
                new OrderItem(7, "Chocolate Cream Pie", 1, 16.49m)
            }
            });

            // Expand with more orders up to 100
            for (int i = 4; i <= 100; i++)
            {
                Orders.Add(new Order(i, $"Customer {i}", GetRandomOrderDate())
                {
                    Items =
                {
                    new OrderItem(i * 2, "Banana Cream Pie", _random.Next(1, 4), 14.99m),
                    new OrderItem(i * 2 + 1, "Lemon Meringue Pie", _random.Next(1, 3), 15.49m)
                }
                });
            }
        }

        private DateTime GetRandomOrderDate()
        {
            DateTime start = new DateTime(2024, 1, 1);
            DateTime end = new DateTime(2025, 12, 31);
            int range = (end - start).Days;
            return start.AddDays(_random.Next(range));
        }

        public List<Order> GetAllOrders() => Orders;

        public Order? GetOrderById(int orderId) => Orders.FirstOrDefault(o => o.OrderId == orderId);

        public List<Order> GetOrdersForPeriod(DateTime startDate, DateTime endDate) =>
            Orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate).ToList();

    }

}
