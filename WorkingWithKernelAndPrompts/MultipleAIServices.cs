using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Services;
using System.Diagnostics.CodeAnalysis;

namespace WorkingWithKernelAndPrompts
{
    public class MultipleAIServices
    {
        public async Task BuildKernelWithMistralChatCompletion(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder()
                .AddMistralChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("MISTRAL_API_KEY"))
                .Build();

            var prompt = "Give me a recipe for an cheese cake. Use metric system and list out the ingredients.";

            var result = await kernel.InvokePromptAsync(
                prompt,
                new(new OpenAIPromptExecutionSettings()
                {
                    MaxTokens = 100,
                    Temperature = 0.7
                }));

            Console.WriteLine(result.GetValue<string>());
        }

        public async Task BuildKernelWithMulitpleAIServices(string openAIModelName, string mistralModelName)
        {

            var builder = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(modelId: openAIModelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"))
                .AddMistralChatCompletion(modelId: mistralModelName, apiKey: Environment.GetEnvironmentVariable("MISTRAL_API_KEY"))
                ;
            builder.Services.AddSingleton<IAIServiceSelector>(new RandomAIServiceSelector()); 

            Kernel kernel = builder.Build();

            var prompt = "Give me a recipe for an cheese cake. Use metric system and list out the ingredients.";
            var result = await kernel.InvokePromptAsync(prompt);
            Console.WriteLine(result.GetValue<string>());
        }

        private sealed class RandomAIServiceSelector : IAIServiceSelector
        {
            private static readonly Random _random = new();

            public bool TrySelectAIService<T>(
                Kernel kernel,
                KernelFunction targetFunction,
                KernelArguments inputArguments,
                [NotNullWhen(true)] out T? selectedService,
                out PromptExecutionSettings? executionSettings) where T : class, IAIService
            {
                var availableServices = kernel.GetAllServices<T>()
                    .ToList();

                if (availableServices.Count > 0)
                {
                    selectedService = availableServices[_random.Next(availableServices.Count)];
                    var modelId = selectedService.GetModelId();
                    var endpoint = selectedService.GetEndpoint();

                    Console.WriteLine($"Randomly selected service: Model ID = {modelId}, Endpoint = {endpoint}");

                    executionSettings = new OpenAIPromptExecutionSettings
                    {
                        MaxTokens = 500,
                        Temperature = 0.5
                    };
                    return true;
                }

                selectedService = null;
                executionSettings = null;
                return false;
            }
        }
    }
}