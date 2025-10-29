using ExtendingWithPlugins.DataService;
using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace ExtendingWithPlugins.Plugins
{
    internal class OrderPlugin
    {
        [KernelFunction]
        [Description("Get the orders between start date and end date. The orders are returned as a list for the requested period. If you need to compare months, you need to call this function multiple times with different value for month and year so that you get the sales for the given period. ")]
        public List<Order> GetOrdersForPeriod([Description("The start of the period we want the orders for")] DateTime startDate, [Description("The end of the period we want the orders for")] DateTime endDate)
        {
            OrderDataService orderDataService = new();
            var orders = orderDataService.GetOrdersForPeriod(startDate, endDate);
            return orders;
        }

        [KernelFunction]
        [Description("Get the details of an order based on the passed-in order ID. ")]
        public Order? GetOrderDetails([Description("The ID of the order")] int orderId)
        {
            OrderDataService orderDataService = new();
            var order = orderDataService.GetOrderById(orderId);
            return order;
        }


    }
}
