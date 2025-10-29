using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace WorkingWithKernelAndPrompts
{
    public class UsingChatHistory
    {
        public async Task AddingMessagesToHistoryManually(string modelName)
        {
            string response = string.Empty;

            OpenAIChatCompletionService chatService = new(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            ChatHistory chatHistory = new();

            chatHistory.AddSystemMessage("You are an assistant that can help with creating complete recipes for cakes and pies.");
            chatHistory.AddUserMessage("I would like to get a suggestion on a very non-traditional pie that I can use to surprise our customers.");

            var assistantMessage = await chatService.GetChatMessageContentAsync(chatHistory);

            Console.WriteLine(assistantMessage);
            chatHistory.Add(assistantMessage);
        }

        public async Task ContinuousChatLoop(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")).Build();

            string response = string.Empty;

            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
            ChatHistory chatHistory = new();

            while (response != "quit")
            {
                Console.WriteLine("Enter your message:");
                response = Console.ReadLine();
                chatHistory.AddUserMessage(response);

                var assistantMessage = await chatCompletionService.GetChatMessageContentAsync(chatHistory);
                Console.WriteLine(assistantMessage);
                chatHistory.Add(assistantMessage);
            }
        }

        public async Task ChatHistoryStreaming(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")).Build();

            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

            ChatHistory chatHistory = new("You are a pie creator and come up with magnificient and delicious recipes for pies.");

            chatHistory.AddAssistantMessage("Welcome to the pie creator chat. How can I help you today?");
            var message = chatHistory.Last();
            Console.WriteLine($"{message.Role}: {message.Content}");

            chatHistory.AddUserMessage("I want to create a pumpkin pie.");
            message = chatHistory.Last();
            Console.WriteLine($"{message.Role}: {message.Content}");

            await foreach (StreamingChatMessageContent chatUpdate in chatCompletionService.GetStreamingChatMessageContentsAsync(chatHistory))
            {
                Console.Write(chatUpdate.Content);
            }

        }

        public async Task ViewChatHistory(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")).Build();

            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

            ChatHistory chatHistory = [
                new() {
                    Role = AuthorRole.User,
                    Content = "Give me the recipe for a pumpkin pie."
                }
            ];

            ChatMessageContent results = await chatCompletionService.GetChatMessageContentAsync(
                chatHistory,
                kernel: kernel
            );

            chatHistory.Add(results);

            Console.WriteLine("Message history: ");

            for (int i = 0; i < chatHistory.Count; i++)
            {
                Console.WriteLine(chatHistory[i]);
            }
        }

        public async Task TruncatePieShopChatHistoryAsync(string modelName)
        {
            var kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(
                    modelId: modelName,
                    apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"))
                .Build();

            var chatService = kernel.GetRequiredService<IChatCompletionService>();

            //var reducer = new ChatHistoryTruncationReducer(targetCount: 2);
            var reducer = new ChatHistorySummarizationReducer(chatService, 2);


            var chatHistory = new ChatHistory("You are an expert pie chef, helping customers with unique pie recipes.");

            var customerQuestions = new[]
            {
                "What is a unique pie recipe I can use for autumn?",
                "Can you suggest a creative twist on an apple pie?",
                "What is an unexpected ingredient to use in a berry pie?",
                "How can I make a savory pie that will surprise my customers?",
                "Now do one just containing cheese"
            };

            foreach (var question in customerQuestions)
            {
                chatHistory.AddUserMessage(question);
                Console.WriteLine($"\n>>> Customer asked:\n{question}");

                var reducedHistory = await reducer.ReduceAsync(chatHistory);

                if (reducedHistory != null)
                {
                    chatHistory = new ChatHistory(reducedHistory);
                }

                var assistantReply = await chatService.GetChatMessageContentAsync(chatHistory);
                chatHistory.AddAssistantMessage(assistantReply.Content ?? string.Empty);

                Console.WriteLine($"\n>>> Pie Chef replied:\n{assistantReply.Content}");
            }
        }
    }
}