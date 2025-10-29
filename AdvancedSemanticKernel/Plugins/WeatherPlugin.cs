using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedSemanticKernel.Plugins
{
    public sealed class WeatherPlugin
    {
        [KernelFunction, Description("Provides current weather for a given city.")]
        public WeatherInfo GetCurrentWeather(
            [Description("The name of the city.")] string city)
        {
            // Mock data for simplicity
            return new WeatherInfo
            {
                City = city,
                Condition = "Sunny",
                TemperatureCelsius = 25
            };
        }

        [KernelFunction, Description("Provides weather forecast for a given city.")]
        public WeatherForecast GetWeatherForecast(
            [Description("The name of the city.")] string city,
            [Description("The date for the forecast.")] DateTime date)
        {
            // Mock data for simplicity
            return new WeatherForecast
            {
                City = city,
                Date = date,
                Condition = "Partly Cloudy",
                HighTemperatureCelsius = 22,
                LowTemperatureCelsius = 15
            };
        }

        public sealed class WeatherInfo
        {
            public string City { get; init; }
            public string Condition { get; init; }
            public int TemperatureCelsius { get; init; }
        }

        public sealed class WeatherForecast
        {
            public string City { get; init; }
            public DateTime Date { get; init; }
            public string Condition { get; init; }
            public int HighTemperatureCelsius { get; init; }
            public int LowTemperatureCelsius { get; init; }
        }
    }
}