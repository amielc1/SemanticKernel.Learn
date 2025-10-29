using ExtendingWithPlugins;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration config = builder.Build();

var openAIModel = config["openAiModelName"];
var imageModel = config["imageModelName"];

//1. Simple plugins
//await new SimplePlugins().ChatWithWeatherKnowledge(openAIModel);
//await new SimplePlugins().ChatWithMultiplePlugins(openAIModel);

//2. Working with complex types
//await new PluginsWithComplexTypes().ChatWithMultiplePluginsAndComplexTypes(openAIModel);

//3. Selecting functions
//await new UsingFunctionChoiceBehavior().SelectingFunctions(openAIModel);
//await new UsingFunctionChoiceBehavior().RequiredFunctions(openAIModel);

//4. Built-in plugins
//await new BuiltInPlugins().SummarizeChat(openAIModel);
//await new BuiltInPlugins().UseTimePlugin(openAIModel);

//5. File-based prompts
//await new FileBasedPrompts().CreateRecipe(openAIModel);
//await new FileBasedPrompts().CreateRecipeBasedOnWeather(openAIModel);

//6. Using RAG
//await new UsingRAG().ChatAboutSales(openAIModel);
//await new UsingRAG().ChangePrice(openAIModel);

//7. Using OpenAPI
await new UsingOpenAPI().ImportPluginFromOpenAPI(openAIModel);