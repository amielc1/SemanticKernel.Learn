using BethanysPieShop.Contracts.Services;
using BethanysPieShop.Util;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace BethanysPieShop.Components.Admin.Pages
{
    public partial class PieCreator
    {
        [Inject]
        public Kernel Kernel { get; set; }

        [Inject]
        private IPieRecipeDataService PieRecipeDataService{ get; set; }

        protected string Message = string.Empty;
        protected string Ingredients = string.Empty;
        protected bool IsSaved = false;

        private IChatCompletionService chatCompletionService;

        override protected void OnInitialized()
        {
            chatCompletionService = Kernel.GetRequiredService<IChatCompletionService>();
        }

        private async Task OnEnterIngredients()
        {
            Message = string.Empty;
            var json = await PieRecipeDataService.GetAllPieRecipesAsJson();

            var prompt = $$"""
                    You are an assistant to help the chefs at Bethany's Pie Shop, a store that sells the most delicious pies.
                    You will be given a list of recipes from Bethany, together with a list of ingredients for each recipe.

                    Your task is, based on the list of available ingredients, to check which pies can be made with the ingredients provided. All ingredients in the recipe need to be available, if one or more is missing, it's not an option to bake the pie. The amounts also need to be sufficient.
                    You can ONLY use the recipes that are available in the list. You can't make up other recipes. If you find one or more pies that can be made, list them. If you can't make any pies, say "I can't find anything we can bake with these ingredients". 

                    Here is the list of recipes and ingredients:

                    Recipes: {{json}}

                    The list of avaialble ingredients is: {{Ingredients}}
                    """;

            await foreach (StreamingChatMessageContent chatUpdate in chatCompletionService.GetStreamingChatMessageContentsAsync(prompt))
            {
                Message += chatUpdate.Content;
                StateHasChanged();
            }
        }
    }
}