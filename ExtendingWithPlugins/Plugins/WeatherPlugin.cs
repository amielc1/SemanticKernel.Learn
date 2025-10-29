using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace ExtendingWithPlugins.Plugins
{
    public class WeatherPlugin
    {
        private static readonly string[] Conditions = { "sunny", "cloudy", "rainy", "stormy", "snowy" };
        private static readonly Random Random = new Random();

        [KernelFunction]
        [Description("Get the current weather in a given location for the current day.")]
        public string GetWeatherForecastForLocation([Description("The location for which the weather is requested")] string location)
        {
            var condition = Conditions[Random.Next(Conditions.Length)];
            var highTemp = Random.Next(0, 30);
            var lowTemp = Random.Next(-10, 10);

            return $"The weather forecast for {location} is {condition} with a high of {highTemp}°F and a low of {lowTemp}°F.";
        }

        [KernelFunction]
        [Description("Get the weather in a given location for a specific day.")]
        public string GetWeatherForecastForLocationAndDate([Description("The location for which the weather is requested")]string location, [Description("The date for which the forecast is requested")]DateTime date)
        {
            var condition = Conditions[Random.Next(Conditions.Length)];
            var highTemp = Random.Next(0, 30);
            var lowTemp = Random.Next(-10, 10);

            return $"The weather forecast for {date.ToShortDateString() } for {location} is {condition} with a high of {highTemp}°F and a low of {lowTemp}°F.";
        }
    }
}
