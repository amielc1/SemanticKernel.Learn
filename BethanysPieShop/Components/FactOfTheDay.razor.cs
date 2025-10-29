
using Microsoft.AspNetCore.Components;
using Microsoft.SemanticKernel;

namespace BethanysPieShop.Components
{
    public partial class FactOfTheDay
    {

        [Inject]
        public Kernel Kernel { get; set; }

        public string FactOfTheDayMessage { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var prompts = Kernel.CreatePluginFromPromptDirectory("Prompts");

            FactOfTheDayMessage = (await Kernel.InvokeAsync(prompts["FactOfTheDay"])).ToString();
        }
    }
}
