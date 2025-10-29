using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Plugins.Core;

namespace ExtendingWithPlugins
{
    public class BuiltInPlugins
    {
        private string chatTranscript =
            "Alex: Hey everyone, what’s your favorite way to spend a free weekend?\r\nSam: I love going on long hikes. There’s something so refreshing about being in nature.\r\nJordan: That sounds nice. I usually spend my weekends working on DIY projects. Last week, I built a bookshelf!\r\nCasey: That’s awesome! I usually like to cook new recipes. Last weekend, I tried making homemade pasta.\r\nAlex: Cooking is fun! I tried baking bread once, but it didn’t turn out great.\r\nSam: Haha, baking can be tricky. What happened?\r\nAlex: It was too dense. I think I messed up the yeast part.\r\nJordan: That happens! The key is letting the dough rise long enough.\r\nCasey: And warm water—not too hot, not too cold.\r\nSam: I should try making bread sometime. Do you guys prefer sweet or savory baking?\r\nAlex: I love making anything with chocolate. So, sweet for me!\r\nJordan: Same here. But I also enjoy making cheesy scones.\r\nCasey: Savory all the way! Garlic bread, stuffed pastries… so good.\r\nSam: Speaking of weekends, does anyone have fun plans for this one?\r\nAlex: I might go for a bike ride if the weather’s nice.\r\nJordan: I’m planning to organize my garage. It’s a mess.\r\nCasey: Haha, good luck! I’m meeting some friends for board games.\r\nSam: That sounds fun! What kind of games?\r\nCasey: Strategy games mostly. They can get pretty intense.\r\nJordan: I love those! It’s always fun to see different playing styles.\r\nAlex: I haven’t played board games in a while. What’s a good one to start with?\r\nSam: Something easy to learn but with some depth. Maybe something with teamwork?\r\nCasey: I can bring a few options next time we hang out!\r\nAlex: That’d be great! I’m always up for trying new things.\r\nJordan: Same here! We should set a game night soon.\r\nSam: Yes! I’ll bring snacks.\r\nCasey: Sounds like a plan!\r\n\r\n(Later in the conversation...)\r\n\r\nAlex: Random question—if you could instantly master any skill, what would it be?\r\nSam: Woodworking! I’d love to build my own furniture.\r\nJordan: That’s a good one. I think I’d pick playing the piano.\r\nCasey: Probably learning new languages. It’d be amazing to speak fluently in different ones.\r\nAlex: That’s a great choice. I’d pick photography. Capturing perfect shots would be so cool.\r\nSam: Photography is fun! Do you already take pictures, or just interested?\r\nAlex: I try sometimes, but I want to get better at it.\r\nJordan: Maybe we should all try a new skill together one weekend.\r\nCasey: That’d be fun! A little skill-swap day.\r\nSam: I love that idea!\r\n\r\n(Wrapping up...)\r\n\r\nAlex: Alright, I gotta head out. This was fun!\r\nJordan: Yeah, great chat! Let’s plan that game night soon.\r\nCasey: Definitely. See you all later!\r\nSam: Bye everyone!"
            ;

        public async Task SummarizeChat(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")).Build();

            KernelPlugin conversationSummaryPlugin = kernel.ImportPluginFromType<ConversationSummaryPlugin>();

            FunctionResult summary = await kernel.InvokeAsync(
            conversationSummaryPlugin["SummarizeConversation"], new() { ["input"] = chatTranscript });

            Console.WriteLine("Generated Summary:");
            Console.WriteLine(summary.GetValue<string>());
        }

        public async Task UseTimePlugin(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")).Build();


            KernelPlugin timePlugin = kernel.ImportPluginFromType<TimePlugin>();

            FunctionResult currentTime = await kernel.InvokeAsync(timePlugin["Now"]);

            Console.WriteLine(currentTime.GetValue<string>());
        }


    }
}