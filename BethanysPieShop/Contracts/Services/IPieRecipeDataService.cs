using BethanysPieShop.Model;

namespace BethanysPieShop.Contracts.Services
{
    public interface IPieRecipeDataService
    {
        Task<IEnumerable<PieRecipe>> GetAllPieRecipes();
        Task<string> GetAllPieRecipesAsJson();
    }
}
