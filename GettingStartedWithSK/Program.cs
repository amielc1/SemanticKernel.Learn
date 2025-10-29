using GettingStartedWithSK;
using Microsoft.Extensions.Configuration;


var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration config = builder.Build();

var modelName = config["modelName"];
var imageModel = config["imageModelName"];

//Demo 1
//await new BasicsOfSK().SimplestPromptLoop(modelName);
//await new BasicsOfSK().SimplePromptStreaming(modelName);
await new BasicsOfSK().ChangeOpenAISettings(modelName);

//Demo 2
//await new ImageGeneration().GenerateBasicImage(imageModel);
//await new FirstPlugin().GetDaysUntilChristmas(modelName);


//Console.WriteLine(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));


Console.ReadLine();