using BethanysPieShop.Contracts.Services;
using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace BethanysPieShop.Plugins
{
    public class SalesInformationPlugin
    {
        private IOrderDataService _orderDataService;

        public SalesInformationPlugin(IOrderDataService orderDataService)
        {
            _orderDataService = orderDataService;
        }

        [KernelFunction]
        [Description("Get the sales of pies in absolute number of items sold at Bethany's Pie Shop for a given month (as an number between 1 and 12) and year as a number for all pies taken together. If you need to compare months, you need to call this function multiple times with different value for month and year so that you get the sales for the given period. If -1 is returned, tell the user that we couldn't find sales for the given period.")]
        public async Task<int> GetNumberOfPiesSoldInGivenMonthAndYear(string month, string year)
        {
            var orders = (await _orderDataService.GetAllOrdersForMonthAndYear(int.Parse(month), int.Parse(year))).ToList();

            if (orders.Count == 0)
            {
                return -1;
            }

            int sum = 0;
            foreach (var orderLine in orders.SelectMany(order => order.OrderLines))
            {
                sum += orderLine.Amount;
            }

            return sum;
        }
    }
}
