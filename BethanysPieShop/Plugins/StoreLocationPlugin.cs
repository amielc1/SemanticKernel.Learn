using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace BethanysPieShop.Plugins
{
    public class StoreLocationPlugin
    {
        [KernelFunction]
        [Description("Returns the closest Bethany's Pie Shop to the user, based on the passed in location.")]
        public string GetClosestStoreLocation(string location)
        {
            if (location == "Brussels")
                return "Brussels";
            else
                return "Antwerp";
        }
    }
}
