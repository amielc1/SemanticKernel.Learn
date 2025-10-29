using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace ExtendingWithPlugins.Plugins
{
    public class WeatherPluginComplexTypes
    {
        private static readonly string[] Conditions = { "sunny", "cloudy", "rainy", "stormy", "snowy" };
        private static readonly Random Random = new Random();

        [KernelFunction]
        [Description("Get the current weather in a given location.")]
        public string GetWeatherForecastForLocation([Description("The location for which the weather is requested")] string location)
        {
            var condition = Conditions[Random.Next(Conditions.Length)];
            var highTemp = Random.Next(0, 30);
            var lowTemp = Random.Next(-10, 10);

            return $"The weather forecast for {location} is {condition} with a high of {highTemp}°F and a low of {lowTemp}°F.";
        }

        [KernelFunction]
        [Description("Get the weather in a given location for a specific day.")]
        public string GetWeatherForecastForLocationAndDate([Description("Information about the weather request")] WeatherRequest weatherRequest)
        {
            var condition = Conditions[Random.Next(Conditions.Length)];
            var highTemp = Random.Next(0, 30);
            var lowTemp = Random.Next(-10, 10);

            return $"The weather forecast for {weatherRequest.Date.ToShortDateString()} for {weatherRequest.Location} is {condition} with a high of {highTemp}°F and a low of {lowTemp}°F.";
        }

       
    }
    public class WeatherRequest
    {
        [Description("The location for which the weather is requested")]
        public string Location { get; set; }

        [Description("The date for which the forecast is requested")]
        public DateTime Date { get; set; }
    }
}
