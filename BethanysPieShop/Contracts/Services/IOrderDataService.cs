using BethanysPieShop.Model;

namespace BethanysPieShop.Contracts.Services
{
    public interface IOrderDataService
    {
        Task<IEnumerable<Order>> GetAllOrdersForMonthAndYear(int month, int year);
        Task<IEnumerable<Order>> GetAllOrdersForPieForMonthAndYear(int month, int year, int pieId);
    }
}
