using BethanysPieShop.Contracts.Repositories;
using BethanysPieShop.Data;
using BethanysPieShop.Model;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Repositories
{
    public class PieRecipeRepository : IPieRecipeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PieRecipeRepository(IDbContextFactory<ApplicationDbContext> DbFactory)
        {
            _applicationDbContext = DbFactory.CreateDbContext();
        }

        public async Task<IEnumerable<PieRecipe>> GetAllPieRecipes()
        {
            return await _applicationDbContext.PieRecipes.ToListAsync();
        }
    }
}
