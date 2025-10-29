using BethanysPieShop.Contracts.Services;
using BethanysPieShop.Model;
using BethanysPieShop.Util;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.TextToImage;

namespace BethanysPieShop.Components.Admin.Pages
{
    public partial class PieAdd
    {
        [SupplyParameterFromForm]
        public Pie Pie { get; set; }

        [Inject]
        public IPieDataService? PieDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public Kernel Kernel { get; set; }

        [Inject]
        public KernelService KernelService { get; set; }

        private string Message = string.Empty;
        private bool Generating = false;
        private bool IsSaved = false;
        private string GeneratedImage = string.Empty;

        private IChatCompletionService chatCompletionService;
        private ITextToImageService textToImageService;
        private Kernel kernel;

        protected override void OnInitialized()
        {
            Pie ??= new();

            chatCompletionService = Kernel.GetRequiredService<IChatCompletionService>();
            textToImageService = Kernel.GetRequiredService<ITextToImageService>();


        }

        //protected async override Task OnInitializedAsync()
        //{
        //    Pie ??= new();
        //    kernel = await KernelService.InitializeKernelAsync();
        //}

        private async Task OnSubmit()
        {
            await PieDataService.AddPie(Pie);
            IsSaved = true;
            Message = "Pie added successfully";
        }

        private async Task GenerateShortDescription()
        {
            Pie.ShortDescription = string.Empty;//reset the short description

            string prompt = "Create a 20 word description for a " + Pie.Name + ". This is used on a website for Bethany's Pie Shop, a store that specializes in creating great pies.";

            ChatHistory chatHistory = new(prompt);

            await foreach (StreamingChatMessageContent chatUpdate in chatCompletionService.GetStreamingChatMessageContentsAsync(chatHistory))
            {
                Pie.ShortDescription += chatUpdate.Content;
                StateHasChanged();
            }

            //var response = await KernelService.StreamChatCompletionAsync(kernel, chatHistory);
            //Pie.ShortDescription += response;
            //StateHasChanged();

        }

        private async Task GenerateLongDescription()
        {
            Pie.LongDescription = string.Empty;//reset the long description

            string prompt = "Create a 100 word description for a " + Pie.Name + ". This is used on a website for Bethany's Pie Shop, an store that specializes in creating great pies.";

            ChatHistory chatHistory = new(prompt);

            await foreach (StreamingChatMessageContent chatUpdate in chatCompletionService.GetStreamingChatMessageContentsAsync(chatHistory))
            {
                Pie.LongDescription += chatUpdate.Content;
                StateHasChanged();
            }
        }

        private async Task GenerateImage()
        {
            Generating = true;

            Pie.ImageUrl = string.Empty;//reset the image url
            GeneratedImage = string.Empty;//reset the image in the UI
            StateHasChanged();


            string prompt = $"Create a highly detailed, photo-realistic and visually appealing image of a {Pie.Name} for a website that specializes in sellings pies. The pie should be the central focus, presented on a rustic wooden table with a soft, blurred background to emphasize the pie. Ensure the crust looks golden and flaky, with a slight sheen to convey freshness. For pies with fruit, like a cherry or apple pie, make sure the fruit filling appears juicy and glossy, with some filling visibly bubbling out. For pies like cheesecake, capture the smooth, creamy texture with a light dusting of powdered sugar or a drizzle of fruit syrup. The lighting should be warm and inviting, highlighting the textures and colors of the pie. Include subtle details like a small fork or a decorative napkin beside the pie for added realism. The overall composition should evoke a sense of homemade comfort and deliciousness, perfect for a website's food section. Also, take into account the generated long description that was already generated: {Pie.LongDescription}";

            var imageUrl = await textToImageService.GenerateImageAsync(prompt, 1792, 1024);

            string fileName = $"{Guid.NewGuid()}.png";
            await DownloadImageToFolder(imageUrl, fileName);

            GeneratedImage = $"<img src='{NavigationManager.BaseUri}/images/{fileName}' width=500/>";
            Pie.ImageUrl = $"{NavigationManager.BaseUri}/images/{fileName}";

            Generating = false;
            StateHasChanged();
        }

        private async Task DownloadImageToFolder(string imageUrl, string fileName)
        {

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(imageUrl);
                response.EnsureSuccessStatusCode();

                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = new FileStream($"{Directory.GetCurrentDirectory()}/wwwroot/images/{fileName}", FileMode.Create))
                {
                    await stream.CopyToAsync(fileStream);
                }

            }
        }
    }
}
