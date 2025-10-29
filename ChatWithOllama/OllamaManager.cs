using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace ChatWithOllama;

public class OllamaManager
{

    public async Task TruncatePieShopChatHistoryAsync()
    {
        var kernel = Kernel.CreateBuilder()
      .AddOllamaChatCompletion(
          modelId: "llama3.2:3b",
          endpoint: new Uri("http://localhost:11434"))
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

            Console.WriteLine("Continue to next step");
            Console.ReadLine();
        }
    }
    public async Task<string> AskOllama(string question)
    {
        var kernel = Kernel.CreateBuilder()
            .AddOllamaChatCompletion(
                modelId: "llama3.2:3b",
                endpoint: new Uri("http://localhost:11434"))
            .Build();

        var chatHistory = new ChatHistory();
        chatHistory.AddUserMessage(question);
        chatHistory.AddSystemMessage("You are an architect c# expert");
        var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
        var result = await chatCompletionService.GetChatMessageContentAsync(chatHistory);

        return result.Content ?? "No content";
    }
}
