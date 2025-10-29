using BethanysPieShop.Model;

namespace BethanysPieShop.Contracts.Repositories
{
    public interface IPieRecipeRepository
    {
        Task<IEnumerable<PieRecipe>> GetAllPieRecipes();
    }
}
