using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Plugins.OpenApi;

namespace ExtendingWithPlugins
{
    public class UsingOpenAPI
    {
        public async Task ImportPluginFromOpenAPI(string modelName)
        {
            string response = string.Empty;


            Kernel kernel = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")).Build();

            await kernel.ImportPluginFromOpenApiAsync(
               pluginName: "pies",
               uri: new Uri("https://localhost:7264/swagger/v1/swagger.json"),
               executionParameters: new OpenApiFunctionExecutionParameters()
               {
                   EnablePayloadNamespacing = true
               }
            );

            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
            ChatHistory chatHistory = new();
            OpenAIPromptExecutionSettings settings = new()
            {
                ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
            };


            while (response != "quit")
            {
                Console.WriteLine("Enter your pie related question:");
                response = Console.ReadLine();
                chatHistory.AddUserMessage(response);

                var assistantMessage = await chatCompletionService.GetChatMessageContentAsync(chatHistory, settings, kernel);
                Console.WriteLine(assistantMessage);
                chatHistory.Add(assistantMessage);
            }
        }
    }
}
