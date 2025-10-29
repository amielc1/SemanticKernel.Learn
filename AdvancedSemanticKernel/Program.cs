using AdvancedSemanticKernel;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration config = builder.Build();

var openAIModel = config["openAiModelName"];
var embeddingsModel = config["embeddingsModelName"];

//1. Create embeddings
//await new ProductEmbeddingsGeneration().GenerateProductEmbeddingsAsync(embeddingsModel);
//await new ProductEmbeddingsGeneration().SearchProductsAsync(embeddingsModel);

//2. Using memory
//await new UsingMemory().SaveTextAndAskQuestion(openAIModel, embeddingsModel);
//await new UsingMemory().SaveTextAndUseMemoryPlugin(openAIModel, embeddingsModel);

//3. Using Agents
//await new AgentWithWeatherPlugin().CreateAndUseWeatherAgent(openAIModel);
//await new AgentWorkflow().RunAgentConversation(openAIModel); 

//4. Logging
await new ChatWithLogging().Execute(openAIModel);