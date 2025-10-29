using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace BethanysPieShop.Plugins
{
    public class WeatherPlugin
    {
        [KernelFunction]
        [Description("Returns the weather at a given location.")]
        public string GetWeatherForecastForLocation(string location)
        {
            if(location == "Brussels")
            {
                return "Rainy - 10°C";
            }
            else if (location == "Antwerp")
            {
                return "Cloudy - 12°";
            }
            else if (location == "Ghent")
            {
                return "Sunny - 15°C";
            }
            else if (location == "Bruges")
            {
               return "Stormy - 5°C";
            }
            else if (location == "Leuven")
            {
               return "Snowy - 0°C";
            }
            else
                return $"Unknown";
        }
    }
}
