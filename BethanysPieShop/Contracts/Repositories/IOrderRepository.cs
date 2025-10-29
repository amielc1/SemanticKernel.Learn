using BethanysPieShop.Model;

namespace BethanysPieShop.Contracts.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersForMonthAndYear(int month, int year);
        Task<IEnumerable<Order>> GetAllOrdersForPieForMonthAndYear(int month, int year, int pieId);
    }
}
