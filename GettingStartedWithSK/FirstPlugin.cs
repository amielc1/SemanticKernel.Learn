using GettingStartedWithSK.Plugins;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace GettingStartedWithSK
{
    public class FirstPlugin
    {
        public async Task GetDaysUntilChristmas(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")).Build();

            kernel.ImportPluginFromType<TimePlugin>();

            OpenAIPromptExecutionSettings settings = new() { ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions };

            Console.WriteLine(await kernel.InvokePromptAsync("How many days are there until Christmas this year? ", new(settings)));
        }
    }
}
