using BethanysPieShop.Data;
using BethanysPieShop.Plugins;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.Security.Claims;

namespace BethanysPieShop.Components
{
    public partial class StoreLocation
    {

        [Inject]
        public Kernel Kernel { get; set; }

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        public UserManager<ApplicationUser> UserManager { get; set; }

        ClaimsPrincipal ClaimsPrincipalUser;

        public string WeatherDescription { get; set; }
        public string ClosestStoreLocation { get; set; }

        private IChatCompletionService chatCompletionService;
        private OpenAIPromptExecutionSettings settings;

        async override protected Task OnInitializedAsync()
        {
            chatCompletionService = Kernel.GetRequiredService<IChatCompletionService>();

            Kernel.ImportPluginFromType<StoreLocationPlugin>();
            Kernel.ImportPluginFromType<WeatherPlugin>();

            settings = new() { ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions };

            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            ClaimsPrincipalUser = authState.User;

            if (ClaimsPrincipalUser.Identity != null)
            {
                var useridentity = ClaimsPrincipalUser.Identity.Name;
                if(useridentity == null)
                {
                    return;
                }
                var user = await UserManager.FindByNameAsync(useridentity);
                
                var locationPrompt = $"Based on the location of the user, {user.City}, return the location of the nearest Bethany's Pie Shop. Return just one single word as the location";
                ClosestStoreLocation = (await chatCompletionService.GetChatMessageContentAsync(locationPrompt, settings, Kernel)).Content;

                var weatherPrompt = $"What is the weather like today at {ClosestStoreLocation}? Return just the temperature and the weather forecast in 2-3 words.";
                WeatherDescription = (await chatCompletionService.GetChatMessageContentAsync(weatherPrompt, settings, Kernel)).Content;


            }
        }
    }
}
