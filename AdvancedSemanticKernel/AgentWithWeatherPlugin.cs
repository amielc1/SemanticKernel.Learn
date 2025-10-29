using AdvancedSemanticKernel.Plugins;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.Agents.OpenAI;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace AdvancedSemanticKernel
{
    public class AgentWithWeatherPlugin
    {
        public async Task CreateAndUseWeatherAgent(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"))
                .Build();

            ChatCompletionAgent agent = new()
            {
                Instructions = "Answer weather-related questions.",
                Name = "WeatherBot",
                Kernel = kernel,
                Arguments = new KernelArguments(new OpenAIPromptExecutionSettings() { FunctionChoiceBehavior = FunctionChoiceBehavior.Auto() }),
            };

            agent.Kernel.Plugins.Add(KernelPluginFactory.CreateFromType<WeatherPlugin>());

            ChatHistory chat = [];

            await InvokeAgentAsync(agent, chat, "Hi there!");
            await InvokeAgentAsync(agent, chat, "What's the weather like in New York today?");
            await InvokeAgentAsync(agent, chat, "Will it rain in Los Angeles tomorrow?");
            await InvokeAgentAsync(agent, chat, "Thanks for the update!");
        }

        private async Task InvokeAgentAsync(ChatCompletionAgent agent, ChatHistory chat, string input)
        {
            ChatMessageContent message = new(AuthorRole.User, input);
            chat.Add(message);

            WriteAgentChatMessage(message);

            await foreach (ChatMessageContent response in agent.InvokeAsync(chat))
            {
                chat.Add(response);
                WriteAgentChatMessage(response);
            }
        }

        protected void WriteAgentChatMessage(ChatMessageContent message)
        {
            string authorExpression = message.Role == AuthorRole.User ? string.Empty : $" - {message.AuthorName ?? "*"}";
            string contentExpression = string.IsNullOrWhiteSpace(message.Content) ? string.Empty : message.Content;
            bool isCode = message.Metadata?.ContainsKey(OpenAIAssistantAgent.CodeInterpreterMetadataKey) ?? false;
            string codeMarker = isCode ? "\n  [CODE]\n" : " ";
            Console.WriteLine($"\n# {message.Role}{authorExpression}:{codeMarker}{contentExpression}");
        }
    }
}
