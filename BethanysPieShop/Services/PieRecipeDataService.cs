using BethanysPieShop.Contracts.Repositories;
using BethanysPieShop.Contracts.Services;
using BethanysPieShop.Model;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BethanysPieShop.Services
{
    public class PieRecipeDataService : IPieRecipeDataService
    {
        private readonly IPieRecipeRepository _pieRecipeRepository;

        public PieRecipeDataService(IPieRecipeRepository pieRecipeRepository)
        {
            _pieRecipeRepository = pieRecipeRepository;
        }

        public async Task<IEnumerable<PieRecipe>> GetAllPieRecipes()
        {
            return await _pieRecipeRepository.GetAllPieRecipes();
        }


        public async Task<string> GetAllPieRecipesAsJson()
        {
            List<PieRecipe> pieRecipes = (await _pieRecipeRepository.GetAllPieRecipes()).ToList ();
            return JsonSerializer.Serialize(pieRecipes, Context.Default.ListPieRecipe);
        }
    }

    [JsonSerializable(typeof(List<PieRecipe>))]
    internal partial class Context : JsonSerializerContext
    {
    }
}
