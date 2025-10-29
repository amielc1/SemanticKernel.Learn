using BethanysPieShop.Model;

namespace BethanysPieShop.Contracts.Repositories
{
    public interface IPieRepository
    {
        Task<IEnumerable<Pie>> GetAllPies();
        Task<Pie> GetPieById(int PieId);
        Task<Pie> AddPie(Pie Pie);
        Task<Pie> UpdatePie(Pie Pie);
        Task DeletePie(int PieId);
    }
}
