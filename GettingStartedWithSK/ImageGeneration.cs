using Microsoft.SemanticKernel.TextToImage;
using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedWithSK
{
    public class ImageGeneration
    {
        public async Task GenerateBasicImage(string modelName)
        {
            Kernel kernel = Kernel.CreateBuilder().AddOpenAITextToImage(modelId: modelName, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")).Build();

            ITextToImageService imageService = kernel.GetRequiredService<ITextToImageService>();

            string prompt =
               """
                   Create a photorealistic image of Bethany's Pie Shop, a cozy and inviting bakery specializing in homemade pies. The shop has a charming, rustic exterior with a red-brick façade, large glass windows, and a classic wooden sign hanging above the entrance that reads 'Bethany's Pie Shop' in elegant, hand-painted lettering. The entrance features a vintage-style wooden door with a small bell above it, and a chalkboard sign outside displaying today's specials, including 'Apple Crumble Pie,' 'Cherry Lattice Pie,' and 'Pumpkin Spice Pie.'

               Inside, the bakery has warm, ambient lighting with wooden shelves displaying fresh pies, croissants, and other baked goods. The counter showcases a variety of golden-brown pies behind a glass display case, with labels indicating flavors like 'Blueberry Bliss,' 'Chocolate Pecan,' and 'Classic Apple.' A friendly barista, wearing a red apron, serves customers from behind the counter, preparing coffee and tea to accompany the pies.

               The seating area features wooden tables with checkered tablecloths, vintage chairs, and small flower vases. A large chalkboard menu on the wall lists the shop's offerings in stylish, handwritten fonts. The walls are adorned with rustic wooden panels, framed pie recipes, and pictures of happy customers enjoying their treats.

               Through the large front window, warm sunlight streams in, casting a golden glow over the cozy atmosphere. Outside, a few customers sit at a sidewalk café area with wrought-iron tables, sipping coffee and enjoying slices of pie.

               The overall atmosphere is warm, welcoming, and full of delicious aromas, making it the perfect spot for pie lovers and community gatherings.
               """;

            var image = await imageService.GenerateImageAsync(prompt, 1792, 1024);

            Console.WriteLine("Image URL: " + image);

        }
    }
}
