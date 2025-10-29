using Microsoft.SemanticKernel;

namespace WorkingWithKernelAndPrompts
{
    public class PromptTemplates
    {
        public async Task UsingSemanticKernelPromptTemplates(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(
                    modelId: modelName,
                    apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"))
                .Build();

            string template = """
                    You are a virtual assistant at Bethany's Pie Shop. 
                    Your job is to recommend the best pie based on the customer's preference.

                    Customer Name: {{$customerName}}
                    Customer Preference: {{$customerPreference}}

                    Provide a structured response in the following format:
                    - **Recommended Pie:** [Pie Name]
                    - **Description:** [Short Description]
                    - **Price:** [Price] EUR
                    """;

            var arguments = new KernelArguments()
            {
                { "customerName", "Alice" },
                { "customerPreference", "fruity and sweet" }
            };

            var function = kernel.CreateFunctionFromPrompt(template);
            var result = await kernel.InvokeAsync(function, arguments);
            Console.WriteLine(result);


        }

        public async Task UsingSemanticKernelPromptTemplatesWithTemplateFactory(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(
                    modelId: modelName,
                    apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"))
                .Build();

            string template = """
            You are a virtual assistant at Bethany's Pie Shop. 
            Your job is to recommend the best pie based on the customer's preference.

            Customer Name: {{$customerName}}
            Customer Preference: {{$customerPreference}}

            Provide a structured response in the following format:
            - **Recommended Pie:** [Pie Name]
            - **Description:** [Short Description]
            - **Price:** [Price] EUR
            """;

            var arguments = new KernelArguments()
            {
                { "customerName", "Alice" },
                { "customerPreference", "fruity and sweet" }
            };

            var templateFactory = new KernelPromptTemplateFactory();
            var promptTemplateConfig = new PromptTemplateConfig()
            {
                Template = template,
                TemplateFormat = "semantic-kernel",
                Name = "PieRecommendationPrompt",
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
