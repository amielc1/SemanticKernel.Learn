using ExtendingWithPlugins.Plugins;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace ExtendingWithPlugins
{
    public class UsingFunctionChoiceBehavior
    {
        public async Task AddingAllFunctions(string modelName)
        {
            string response = string.Empty;

            var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            builder.Plugins.AddFromType<WeatherPlugin>();

            Kernel kernel = builder.Build();

            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
            ChatHistory chatHistory = new();
            OpenAIPromptExecutionSettings settings = new()
            {
                ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions,
                FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
            };


            while (response != "quit")
            {
                Console.WriteLine("Enter your message:");
                response = Console.ReadLine();
                chatHistory.AddUserMessage(response);

                var assistantMessage = await chatCompletionService.GetChatMessageContentAsync(chatHistory, settings, kernel);
                Console.WriteLine(assistantMessage);
                chatHistory.Add(assistantMessage);
            }
        }

        public async Task SelectingFunctions(string modelName)
        {
            string response = string.Empty;

            var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            builder.Plugins.AddFromType<WeatherPlugin>();

            Kernel kernel = builder.Build();

            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
            ChatHistory chatHistory = new();

            KernelFunction getWeatherForecastForLocation = kernel.Plugins.GetFunction("WeatherPlugin", "GetWeatherForecastForLocation");

            OpenAIPromptExecutionSettings settings = new()
            {
                FunctionChoiceBehavior = FunctionChoiceBehavior.Auto(functions: [getWeatherForecastForLocation])
            };

            while (response != "quit")
            {
                Console.WriteLine("Enter your message:");
                response = Console.ReadLine();
                chatHistory.AddUserMessage(response);

                var assistantMessage = await chatCompletionService.GetChatMessageContentAsync(chatHistory, settings, kernel);
                Console.WriteLine(assistantMessage);
                chatHistory.Add(assistantMessage);
            }
        }


        public async Task RequiredFunctions(string modelName)
        {
            string response = string.Empty;

            var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            builder.Plugins.AddFromType<WeatherPlugin>();

            Kernel kernel = builder.Build();

            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
            ChatHistory chatHistory = new();

            KernelFunction getWeatherForecastForLocation = kernel.Plugins.GetFunction("WeatherPlugin", "GetWeatherForecastForLocation");

            OpenAIPromptExecutionSettings settings = new()
            {
                FunctionChoiceBehavior = FunctionChoiceBehavior.Required(functions: [getWeatherForecastForLocation])
            };

            while (response != "quit")
            {
                Console.WriteLine("Enter your message:");
                response = Console.ReadLine();
                chatHistory.AddUserMessage(response);

                var assistantMessage = await chatCompletionService.GetChatMessageContentAsync(chatHistory, settings, kernel);
                Console.WriteLine(assistantMessage);
                chatHistory.Add(assistantMessage);
            }
        }
    }
}
