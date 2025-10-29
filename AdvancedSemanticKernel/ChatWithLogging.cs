using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace AdvancedSemanticKernel
{
    public  class ChatWithLogging
    {
        public async Task Execute(string modelName)
        {
            var resourceBuilder = ResourceBuilder
                .CreateDefault()
                .AddService("SKTelemetryExample");

            AppContext.SetSwitch("Microsoft.SemanticKernel.Experimental.GenAI.EnableOTelDiagnosticsSensitive", true);

            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetResourceBuilder(resourceBuilder)
                .AddSource("Microsoft.SemanticKernel*")
                .AddConsoleExporter()
                .Build();

            using var meterProvider = Sdk.CreateMeterProviderBuilder()
                .SetResourceBuilder(resourceBuilder)
                .AddMeter("Microsoft.SemanticKernel*")
                .AddConsoleExporter()
                .Build();

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.SetResourceBuilder(resourceBuilder);
                    options.AddConsoleExporter();
                    options.IncludeFormattedMessage = true;
                    options.IncludeScopes = true;
                });
                builder.SetMinimumLevel(LogLevel.Information);
            });

            IKernelBuilder kernelBuilder = Kernel.CreateBuilder();

            kernelBuilder.Services.AddSingleton(loggerFactory);

            kernelBuilder.AddOpenAIChatCompletion(
                modelId: modelName,
                apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
            );

            Kernel kernel = kernelBuilder.Build();

            var response = await kernel.InvokePromptAsync(
                "Explain why the sky is blue in one sentence."
            );

            Console.WriteLine(response);
        }
    }
}
