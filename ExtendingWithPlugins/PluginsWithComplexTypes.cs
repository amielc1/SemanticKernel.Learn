using ExtendingWithPlugins.Plugins;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace ExtendingWithPlugins
{
    public class PluginsWithComplexTypes
    {
        public async Task ChatWithMultiplePluginsAndComplexTypes(string modelName)
        {
            string response = string.Empty;

            Kernel kernel = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")).Build();

            kernel.ImportPluginFromType<WeatherPluginComplexTypes>();
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
    }
}
