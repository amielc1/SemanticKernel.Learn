using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace WorkingWithKernelAndPrompts
{
    public class KernelSetup
    {
        public async Task BuildKernelWithOpenAIChatCompletion(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"))
                .Build();

            var prompt = "Give me a recipe for an apple pie. Use metric system and list out the ingredients.";

            var result = await kernel.InvokePromptAsync(
                prompt,
                new(new OpenAIPromptExecutionSettings()
                {
                    MaxTokens = 100,
                    Temperature = 0.7
                }));

            Console.WriteLine(result.GetValue<string>());
        }
        
        public async Task AddingMoreServices(string modelName)
        {
            IKernelBuilder builder = Kernel.CreateBuilder();

            builder.Services
                .AddLogging(loggingConfig =>
            loggingConfig.AddConsole().SetMinimumLevel(LogLevel.Information))
                .AddHttpClient() // Register HttpClient for external requests
                .AddOpenAIChatCompletion(
                    modelId: modelName,
                    apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            Kernel kernel = builder.Build();

            var prompt = "Give me a recipe for an apple pie. Use metric system and list out the ingredients.";

            var result = await kernel.InvokePromptAsync(prompt);

            Console.WriteLine(result.GetValue<string>());
        }

        public async Task UseDependencyInjection(string modelName)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddHttpClient();

            var collection = serviceCollection.AddTransient<Kernel>((sp) =>
            {
                var factory = sp.GetRequiredService<IHttpClientFactory>();

                return Kernel.CreateBuilder()
                    .AddOpenAIChatCompletion(
                        modelId: modelName,
                        apiKey: Environment.GetEnvironmentVariable  ("OPENAI_API_KEY"),
                        httpClient: factory.CreateClient())
                    .Build();
            });

            var prompt = "Give me a recipe for an apple pie. Use metric system and list out the ingredients.";

            await using ServiceProvider serviceProvider = collection.BuildServiceProvider();

            Kernel kernel = serviceProvider.GetRequiredService<Kernel>();

            var result = await kernel.InvokePromptAsync(prompt);

            Console.WriteLine(result.GetValue<string>());
        }
    }
}
