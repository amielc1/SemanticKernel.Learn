using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.PromptTemplates.Handlebars;

namespace WorkingWithKernelAndPrompts
{
    public class HandleBarsTemplates
    {

        public async Task UsingHandleBarsSyntax(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(
                    modelId: modelName,
                    apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"))
                .Build();

            string template = """
            <message role="system">
                You are an AI assistant at Bethany's Pie Shop. 
                Your job is to recommend the best pie based on the customer's preferences.

                # Customer Details
                - **First Name:** {{customer.firstName}}
                - **Last Name:** {{customer.lastName}}
                - **Preference:** {{preference}}

                # Recommended Pie
                Please provide a structured response that includes:
                - A pie recommendation that matches the preference.
                - A short description of why this pie is a great choice.
                - The price in EUR.

                Format the response using markdown and add appropriate emojis for a friendly touch.
            </message>
        
            {{#each history}}
            <message role="{{role}}">
                {{content}}
            </message>
            {{/each}}
            """;

            var arguments = new KernelArguments()
            {
                { "customer", new
                    {
                        firstName = "Alice",
                        lastName = "Johnson"
                    }
                },
                { "preference", "rich and creamy" },
                { "history", new[]
                    {
                        new { role = "user", content = "What pie would you recommend for someone who likes rich and creamy desserts?" },
                    }
                },
            };

            var templateFactory = new HandlebarsPromptTemplateFactory();
            var promptTemplateConfig = new PromptTemplateConfig()
            {
                Template = template,
                TemplateFormat = "handlebars",
                Name = "PieRecommendationHandlebars",
            };

            var promptTemplate = templateFactory.Create(promptTemplateConfig);
            var renderedPrompt = await promptTemplate.RenderAsync(kernel, arguments);
            Console.WriteLine($"Rendered Prompt:\n{renderedPrompt}\n");

            var function = kernel.CreateFunctionFromPrompt(promptTemplateConfig, templateFactory);
            var response = await kernel.InvokeAsync(function, arguments);
            Console.WriteLine(response);
        }
    }
}
