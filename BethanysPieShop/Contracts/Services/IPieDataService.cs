using BethanysPieShop.Model;

namespace BethanysPieShop.Contracts.Services
{
    public interface IPieDataService
    {
        Task<IEnumerable<Pie>> GetAllPies();
        Task<Pie> GetPieDetails(int PieId);
        Task<Pie> AddPie(Pie Pie);
        Task UpdatePie(Pie Pie);
        Task DeletePie(int PieId);
    }
}
