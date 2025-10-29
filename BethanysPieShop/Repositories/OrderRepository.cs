using BethanysPieShop.Contracts.Repositories;
using BethanysPieShop.Data;
using BethanysPieShop.Model;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrderRepository(IDbContextFactory<ApplicationDbContext> DbFactory)
        {
            _applicationDbContext = DbFactory.CreateDbContext();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersForMonthAndYear(int month, int year)
        {
            return await _applicationDbContext.Orders.Where(o => o.OrderPlaced.Month == month && o.OrderPlaced.Year == year).Include(o => o.OrderLines).ThenInclude(o => o.Pie).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersForPieForMonthAndYear(int month, int year, int pieId)
        {
            return await _applicationDbContext.Orders.Where(o => o.OrderPlaced.Month == month && o.OrderPlaced.Year == year && o.OrderLines.Any(p => p.PieId == pieId)).Include(o => o.OrderLines).ThenInclude(o => o.Pie).ToListAsync();

        }
    }
}
