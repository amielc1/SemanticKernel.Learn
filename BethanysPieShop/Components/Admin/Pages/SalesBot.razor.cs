using BethanysPieShop.Plugins;
using Microsoft.AspNetCore.Components;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace BethanysPieShop.Components.Admin.Pages
{
    public partial class SalesBot
    {
        [Inject]
        public Kernel Kernel { get; set; }

        protected string Message = string.Empty;
        protected string Question = string.Empty;
        protected bool IsSaved = false;
        private IChatCompletionService chatCompletionService;
        private OpenAIPromptExecutionSettings settings;

        override protected void OnInitialized()
        {
            chatCompletionService = Kernel.GetRequiredService<IChatCompletionService>();

            Kernel.ImportPluginFromType<SalesInformationPlugin>();
            settings = new() { ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions };
        }

        private async Task OnEnterQuestion()
        {
            ChatHistory chatHistory = new();

            chatHistory.AddSystemMessage("You are a sales bot, helping the people at Bethany's Pie Shop understand their sales and you are able to provide insights about sales of pies over time.");
            chatHistory.AddUserMessage(Question);

            var assistantMessage = await chatCompletionService.GetChatMessageContentAsync(chatHistory, settings, Kernel);
            Message = assistantMessage.Content;
            StateHasChanged();
        }
    }
}
