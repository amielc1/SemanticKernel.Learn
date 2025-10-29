using ExtendingWithPlugins.Plugins;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace ExtendingWithPlugins
{
    public class SimplePlugins
    {
        public async Task ChatWithWeatherKnowledge(string modelName)
        {
            string response = string.Empty;

            Kernel kernel = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")).Build();

            kernel.ImportPluginFromType<WeatherPlugin>();

            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
            ChatHistory chatHistory = new();
            OpenAIPromptExecutionSettings settings = new()
            {
                ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
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

        public async Task ChatWithMultiplePlugins(string modelName)
        {
            string response = string.Empty;

            Kernel kernel = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")).Build();

            kernel.ImportPluginFromType<WeatherPlugin>();
            kernel.ImportPluginFromType<AgendaPlugin>();
            kernel.ImportPluginFromType<TimePlugin>();

            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
            ChatHistory chatHistory = new();
            OpenAIPromptExecutionSettings settings = new()
            {
                ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
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


        //Different ways to add plugins
        public async Task UsingAddFromType(string modelName)
        {
            string response = string.Empty;

            var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            builder.Plugins.AddFromType<WeatherPlugin>();

            //alternative
            WeatherPlugin plugin = new();
            builder.Plugins.AddFromObject(plugin);

            Kernel kernel = builder.Build();

            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
            ChatHistory chatHistory = new();
            OpenAIPromptExecutionSettings settings = new() { ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions,
            FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()};


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
