using BethanysPieShop.Contracts.Repositories;
using BethanysPieShop.Contracts.Services;
using BethanysPieShop.Model;

namespace BethanysPieShop.Services
{
    public class OrderDataService : IOrderDataService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderDataService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersForMonthAndYear(int month, int year)
        {
            return await _orderRepository.GetAllOrdersForMonthAndYear(month, year);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersForPieForMonthAndYear(int month, int year, int pieId)
        {
            return await _orderRepository.GetAllOrdersForPieForMonthAndYear(month, year, pieId);
        }
    }
}
