using Microsoft.Extensions.Configuration;
using WorkingWithKernelAndPrompts;


var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration config = builder.Build();

var openAIModel = config["openAiModelName"];
var imageModel = config["imageModelName"];
var mistralModel = config["mistralModelName"];

//1. Set up the kernel
//await new KernelSetup().BuildKernelWithOpenAIChatCompletion(openAIModel);
//await new KernelSetup().UsingServiceCollection(openAIModel);
//await new KernelSetup().UseDependencyInjection(openAIModel);

//2. Using a different AI service
//await new MultipleAIServices().BuildKernelWithMistralChatCompletion(mistralModel);
//await new MultipleAIServices().BuildKernelWithMulitpleAIServices(openAIModel, mistralModel);

//3. Using chat history
//await new UsingChatHistory().AddingMessagesToHistoryManually(openAIModel);
//await new UsingChatHistory().ContinuousChatLoop(openAIModel);
//await new UsingChatHistory().ChatHistoryStreaming(openAIModel);
//await new UsingChatHistory().ViewChatHistory(openAIModel);

//4. Reducing the chat history
//await new UsingChatHistory().TruncatePieShopChatHistoryAsync(openAIModel);


//5. Using prompts
//await new UsingPrompts().UsingBadPrompt(openAIModel);
//await new UsingPrompts().UsingBasicPrompt(openAIModel);
//await new UsingPrompts().UsingStructuredPrompt(openAIModel);
//await new UsingPrompts().UsingExpertPromptWithPersona(openAIModel);
//await new UsingPrompts().UsingSingleShotPrompt(openAIModel);
//await new UsingPrompts().BuildKernelWithFewShotPrompt(openAIModel);

//6.Using prompt templates
//await new PromptTemplates().UsingSemanticKernelPromptTemplates(openAIModel);
//await new PromptTemplates().UsingSemanticKernelPromptTemplatesWithTemplateFactory(openAIModel);

//7. Handlebars
await new HandleBarsTemplates().UsingHandleBarsSyntax(openAIModel);

Console.ReadLine();