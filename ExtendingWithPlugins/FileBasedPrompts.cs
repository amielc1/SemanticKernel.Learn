using ExtendingWithPlugins.Plugins;
using Microsoft.SemanticKernel;

namespace ExtendingWithPlugins
{
    public class FileBasedPrompts
    {
        public async Task CreateRecipe(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")).Build();

            var prompts = kernel.CreatePluginFromPromptDirectory("Prompts");

            var result = await kernel.InvokeAsync(
                prompts["PieRecipes"]
            );

            Console.WriteLine(result);
        }


        public async Task CreateRecipeBasedOnWeather(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")).Build();

            var prompts = kernel.CreatePluginFromPromptDirectory("Prompts");

            var result = await kernel.InvokeAsync(
                prompts["TimeBasedRecipes"],
                new() {
                    { "today", DateTime.Now.ToShortDateString() },
                }
            );

            Console.WriteLine(result);
        }


    }
}
