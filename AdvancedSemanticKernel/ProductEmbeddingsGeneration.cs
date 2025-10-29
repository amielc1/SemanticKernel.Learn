using Microsoft.SemanticKernel.Connectors.InMemory;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Embeddings;
using System.Text.Json;

namespace AdvancedSemanticKernel
{
    public class ProductEmbeddingsGeneration
    {
        public async Task GenerateProductEmbeddingsAsync(string modelName)
        {
            var embeddingService = new OpenAITextEmbeddingGenerationService(
                modelId: modelName,
                apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
            );

            var vectorStore = new InMemoryVectorStore();
            var collection = vectorStore.GetCollection<ulong, Product>("productCatalog");
            await collection.CreateCollectionIfNotExistsAsync();

            var productCatalog = GetProductCatalog();

            foreach (var product in productCatalog)
            {
                product.DescriptionEmbedding = await embeddingService.GenerateEmbeddingAsync(product.Description);
                await collection.UpsertAsync(product);
            }

            var upsertedKeys = productCatalog.Select(product => product.ProductId);
            Console.WriteLine($"Upserted Product IDs: {string.Join(", ", upsertedKeys)}");

            var firstProductId = upsertedKeys.First();
            var retrievedProduct = await collection.GetAsync(firstProductId, new() { IncludeVectors = true });
            Console.WriteLine($"Retrieved Product: {JsonSerializer.Serialize(retrievedProduct)}");
        }

        public async Task SearchProductsAsync(string modelName)
        {
            var textEmbeddingGenerationService = new OpenAITextEmbeddingGenerationService(
                modelId: modelName,
                apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
            );

            var vectorStore = new InMemoryVectorStore();

            var collection = vectorStore.GetCollection<ulong, Product>("productCatalog");
            await collection.CreateCollectionIfNotExistsAsync();

            var productCatalog = GetProductCatalog().ToList();
            var embeddingTasks = productCatalog.Select(product => Task.Run(async () =>
            {
                product.DescriptionEmbedding = await textEmbeddingGenerationService.GenerateEmbeddingAsync(product.Description);
            }));
            await Task.WhenAll(embeddingTasks);

            var upsertedKeysTasks = productCatalog.Select(product => collection.UpsertAsync(product));
            var upsertedKeys = await Task.WhenAll(upsertedKeysTasks);

            Console.WriteLine($"Upserted Product IDs: {string.Join(", ", upsertedKeys)}");

            var searchQuery = "Foldable electric scooter";
            var searchVector = await textEmbeddingGenerationService.GenerateEmbeddingAsync(searchQuery);
            var searchResult = await collection.VectorizedSearchAsync(searchVector, new() { Top = 1 });
            var resultRecords = await searchResult.Results.ToListAsync();

            if (resultRecords.Any())
            {
                Console.WriteLine($"Search Query: {searchQuery}");
                Console.WriteLine($"Matched Product: {resultRecords.First().Record.Name}");
                Console.WriteLine($"Description: {resultRecords.First().Record.Description}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"No results found for query: {searchQuery}");
            }

            searchQuery = "Best noise-canceling headphones";
            searchVector = await textEmbeddingGenerationService.GenerateEmbeddingAsync(searchQuery);
            searchResult = await collection.VectorizedSearchAsync(searchVector, new() { Top = 1 });
            resultRecords = await searchResult.Results.ToListAsync();

            if (resultRecords.Any())
            {
                Console.WriteLine($"Search Query: {searchQuery}");
                Console.WriteLine($"Matched Product: {resultRecords.First().Record.Name}");
                Console.WriteLine($"Description: {resultRecords.First().Record.Description}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"No results found for query: {searchQuery}");
            }
        }

        private IEnumerable<Product> GetProductCatalog() => new List<Product>
        {
            new Product
            {
                ProductId = 101,
                Name = "Wireless Headphones",
                Description = "High-quality wireless headphones with noise-cancellation and long battery life.",
                Category = "Electronics"
            },
            new Product
            {
                ProductId = 102,
                Name = "Smartwatch",
                Description = "A stylish smartwatch with fitness tracking, heart rate monitoring, and app integration.",
                Category = "Wearables"
            },
            new Product
            {
                ProductId = 103,
                Name = "Electric Scooter",
                Description = "Eco-friendly electric scooter with a powerful motor and foldable design for easy storage.",
                Category = "Transportation"
            }
        };
    }
}
