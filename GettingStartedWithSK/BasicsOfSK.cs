using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace GettingStartedWithSK
{
    public class BasicsOfSK
    {
        public async Task SimplestPromptLoop(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")).Build();

            string input = string.Empty;

            while (input != "quit")
            {
                Console.WriteLine("Enter your message:");
                input = Console.ReadLine();
                Console.WriteLine(await kernel.InvokePromptAsync(input));
            }
            Console.WriteLine();

        }

        public async Task SimplePromptStreaming(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")).Build();

            string input = string.Empty;


            while (input != "quit")
            {
                Console.WriteLine("Enter your message:");
                input = Console.ReadLine();

                await foreach (var chunk in kernel.InvokePromptStreamingAsync(input))
                {
                    Console.Write(chunk);
                }
            }
            Console.WriteLine();

        }

        public async Task ChangeOpenAISettings(string modelName)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Kernel kernel = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")).Build();

            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

            KernelArguments arguments = new(new OpenAIPromptExecutionSettings { MaxTokens = 500, Temperature = 0 });
            Console.WriteLine("Temperature 0:");
            Console.WriteLine(await kernel.InvokePromptAsync("Tell me a story about Bethany's Pie Shop, a pie store located in Brussels which is known for its delicious pies", arguments));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;

            arguments = new(new OpenAIPromptExecutionSettings { MaxTokens = 500, Temperature = 1 });
            Console.WriteLine("Temperature 1:");
            Console.WriteLine(await kernel.InvokePromptAsync("Tell me a story about Bethany's Pie Shop, a pie store located in Brussels which is known for its delicious pies", arguments));
            Console.WriteLine();

        }
    }
}
