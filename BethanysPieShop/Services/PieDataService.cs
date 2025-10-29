using BethanysPieShop.Contracts.Repositories;
using BethanysPieShop.Contracts.Services;
using BethanysPieShop.Model;

namespace BethanysPieShop.Services
{
    public class PieDataService : IPieDataService
    {
        private readonly IPieRepository _pieRepository;

        public PieDataService(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public async Task<Pie> AddPie(Pie Pie)
        {
            return await _pieRepository.AddPie(Pie);
        }

        public async Task DeletePie(int PieId)
        {
            await _pieRepository.DeletePie(PieId);
        }

        public async Task<IEnumerable<Pie>> GetAllPies()
        {
            return await _pieRepository.GetAllPies();
        }

        public async Task<Pie> GetPieDetails(int PieId)
        {
            return await _pieRepository.GetPieById(PieId);
        }

        public async Task UpdatePie(Pie Pie)
        {
            await _pieRepository.UpdatePie(Pie);
        }
    }
}
