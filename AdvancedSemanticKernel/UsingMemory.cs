using AdvancedSemanticKernel.Services;

namespace AdvancedSemanticKernel
{
    internal class UsingMemory
    {
        public async Task SaveTextAndAskQuestion(string modelName, string embeddingModelName)
        {

            MemoryService memoryService = new(modelName, embeddingModelName);

            await memoryService.SaveTextAsync("Employees are only allowed to work from home on Monday and Friday, other days aren't allowed ever.");
            await memoryService.SaveTextAsync("Employees needs to be available between 10AM and 4PM.");

            Console.WriteLine("Enter your question: ");
            var message = Console.ReadLine(); //Can I work from home on Tuesday?
            var response = await memoryService.QueryMemoryAsync(message);
            Console.WriteLine(response.Answer);
        }

        public async Task SaveTextAndUseMemoryPlugin(string modelName, string embeddingModelName)
        {

            MemoryService memoryService = new(modelName, embeddingModelName);

            await memoryService.SaveTextAsync("Employees are only allowed to work from home on Monday and Friday, other days aren't allowed ever.");
            await memoryService.SaveTextAsync("Employees needs to be available between 10AM and 4PM.");

            Console.WriteLine("Enter your question: ");
            var message = Console.ReadLine(); //Can I work from home on Tuesday?

            await memoryService.UseMemoryAsync(modelName, message);

        }
    }
}
