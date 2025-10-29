using BethanysPieShop.Util;
using Microsoft.Extensions.Options;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace BethanysPieShop
{
    public class KernelService
    {
        protected readonly ModelSettings modelSettings;

        public KernelService(IOptions<ModelSettings> options)
        {
            modelSettings = options.Value;
        }

        public async Task<Kernel> InitializeKernelAsync(string? modelName = null)
        {
            var builder = Kernel.CreateBuilder();

            builder
                .AddOpenAIChatCompletion(modelSettings.TextModelName, modelSettings.OPENAI_API_KEY)
                .AddOpenAITextToImage(modelSettings.ImageModelName, modelSettings.OPENAI_API_KEY);

            //other models can be added here

            return builder.Build();
        }

        public async Task<string> StreamChatCompletionAsync(Kernel kernel, ChatHistory chatHistory)
        {
            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
            var completeMessage = string.Empty;

            await foreach (var completionResult in chatCompletionService.GetStreamingChatMessageContentsAsync(chatHistory))
            {
                completeMessage += completionResult.Content;
            }

            return completeMessage;
        }
    }
}