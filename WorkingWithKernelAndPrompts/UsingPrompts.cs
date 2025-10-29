using Microsoft.SemanticKernel;

namespace WorkingWithKernelAndPrompts
{
    public class UsingPrompts
    {

        public async Task UsingBadPrompt(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"))
                .Build();

            // Basic prompt without much structure
            var prompt = "Give me a recipe.";

            Console.WriteLine("Bad prompt");
            Console.WriteLine("Prompt: " + prompt);
            Console.WriteLine("=====================================");

            var result = await kernel.InvokePromptAsync(prompt);

            Console.WriteLine(result.GetValue<string>());
            Console.WriteLine("=====================================");
            Console.WriteLine();
        }

        public async Task UsingBasicPrompt(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"))
                .Build();

            // Basic prompt without much structure
            var prompt = "Give me a recipe for apple pie.";

            Console.WriteLine("Basic prompt without much structure");
            Console.WriteLine("Prompt: " + prompt);
            Console.WriteLine("=====================================");

            var result = await kernel.InvokePromptAsync(prompt);

            Console.WriteLine(result.GetValue<string>());
            Console.WriteLine("=====================================");
            Console.WriteLine();
        }

        public async Task UsingStructuredPrompt(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"))
                .Build();

            // Structured prompt with explicit details
            var prompt = @"Provide a step-by-step recipe for apple pie. 
            Use metric units, list ingredients separately, and ensure all steps are clear and numbered.";

            Console.WriteLine("Structured prompt with explicit details");
            Console.WriteLine("Prompt: " + prompt);
            Console.WriteLine("=====================================");

            var result = await kernel.InvokePromptAsync(prompt);

            Console.WriteLine(result.GetValue<string>());
            Console.WriteLine("=====================================");
            Console.WriteLine();
        }

        public async Task UsingExpertPromptWithPersona(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"))
                .Build();

            // Role-based prompt for expert-level response
            var prompt = @"You are a professional pastry chef with years of experience. 
                  Provide a detailed, expert-level apple pie recipe, using metric units, listing ingredients separately, 
                  and explaining each step clearly, including tips for perfect texture and flavor.";

            Console.WriteLine("Role-based prompt for expert-level response");
            Console.WriteLine("Prompt: " + prompt);
            Console.WriteLine("=====================================");

            var result = await kernel.InvokePromptAsync(prompt);

            Console.WriteLine(result.GetValue<string>());
            Console.WriteLine("=====================================");
            Console.WriteLine();
        }

        public async Task UsingSingleShotPrompt(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"))
                .Build();

            // Single-shot learning: Provide one example to guide the model
            var prompt = """
                    Here is an example of a well-structured recipe:

                    Recipe: Classic Pancakes
                    Ingredients:
                    - 250g flour
                    - 2 eggs
                    - 500ml milk
                    - 1 tbsp sugar
                    - 1 tsp baking powder

                    Instructions:
                    1. Mix all ingredients until smooth.
                    2. Heat a pan over medium heat.
                    3. Pour batter into the pan and cook until golden.

                    Now, using the same structure, provide a detailed recipe for an apple pie.
                    """;


            Console.WriteLine("Single-shot learning: Provide one example to guide the model");
            Console.WriteLine("Prompt: " + prompt);
            Console.WriteLine("=====================================");

            var result = await kernel.InvokePromptAsync(prompt);

            Console.WriteLine(result.GetValue<string>());
            Console.WriteLine("=====================================");
            Console.WriteLine();
        }

        public async Task BuildKernelWithFewShotPrompt(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"))
                .Build();

            // Few-shot learning: Provide multiple examples to refine the output style
            var prompt = """
                Here are examples of well-structured recipes:

                Recipe: Classic Pancakes
                Ingredients:
                - 250g flour
                - 2 eggs
                - 500ml milk
                - 1 tbsp sugar
                - 1 tsp baking powder

                Instructions:
                1. Mix all ingredients until smooth.
                2. Heat a pan over medium heat.
                3. Pour batter into the pan and cook until golden.

                Recipe: Chocolate Cake
                Ingredients:
                - 200g flour
                - 150g sugar
                - 100g cocoa powder
                - 2 eggs
                - 250ml milk
                - 1 tsp baking soda

                Instructions:
                1. Preheat oven to 180°C.
                2. Mix dry ingredients, then add wet ingredients.
                3. Pour into a greased pan and bake for 35 minutes.

                Now, using the same structured format, provide a detailed apple pie recipe.
                """;

            Console.WriteLine("Few-shot learning: Provide multiple examples to refine the output style");
            Console.WriteLine("Prompt: " + prompt);
            Console.WriteLine("=====================================");

            var result = await kernel.InvokePromptAsync(prompt);

            Console.WriteLine(result.GetValue<string>());

            Console.WriteLine("=====================================");
            Console.WriteLine();
        }

    }
}
