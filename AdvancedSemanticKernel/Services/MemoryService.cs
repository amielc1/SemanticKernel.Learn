using AdvancedSemanticKernel.Models;
using Microsoft.KernelMemory;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace AdvancedSemanticKernel.Services
{
    public class MemoryService
    {
        private readonly IKernelMemory _kernelMemory;
        private readonly string? _apiKey;

        public MemoryService(string modelName, string embeddingModelName)
        {
            _apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

            var memoryBuilder = new KernelMemoryBuilder()
            .WithOpenAITextGeneration(new OpenAIConfig
            {
                APIKey = _apiKey,
                TextModel = modelName
            })
            .WithOpenAITextEmbeddingGeneration(new OpenAIConfig
            {
                APIKey = _apiKey,
                EmbeddingModel = embeddingModelName
            })
            .WithSimpleVectorDb();

            _kernelMemory = memoryBuilder.Build<MemoryServerless>();
        }

        public async Task<bool> SaveTextAsync(string text)
        {
            try
            {
                await _kernelMemory.ImportTextAsync(text);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to store text: {ex.Message}");
                return false;
            }
        }

        public async Task<KernelResponse> QueryMemoryAsync(string question)
        {
            try
            {
                var result = await _kernelMemory.AskAsync(question);
                return new KernelResponse
                {
                    Answer = result.Result,
                    Citations = result.RelevantSources
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to query memory: {ex.Message}");
                return new KernelResponse
                {
                    Answer = "An error occurred while processing your question."
                };
            }
        }

        public async Task UseMemoryAsync(string chatModelName, string message)
        {
            var kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(chatModelName, _apiKey)
                .Build();

            var chatHistory = new ChatHistory();
            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

            var memoryPlugin = new MemoryPlugin(_kernelMemory, waitForIngestionToComplete: true);
            kernel.ImportPluginFromObject(memoryPlugin, "memory");

            var settings = new OpenAIPromptExecutionSettings
            {
                ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
            };

            var prompt = $@"
                Question to Kernel Memory: {message}
                Kernel Memory Answer: {{memory.ask}}
                If the answer is empty, say 'I don't know'. Otherwise, reply with the answer.
            ";

            chatHistory.AddMessage(AuthorRole.User, prompt);

            var response = await chatCompletionService.GetChatMessageContentAsync(chatHistory, settings, kernel);
            Console.WriteLine(response.Content);
            chatHistory.AddMessage(AuthorRole.Assistant, response.Content);
        }
    }
}
