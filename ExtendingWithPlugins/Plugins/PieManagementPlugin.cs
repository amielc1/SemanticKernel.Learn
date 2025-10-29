using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace ExtendingWithPlugins.Plugins
{
    public class PieManagementPlugin
    {

        [KernelFunction]
        [Description("Change the price of a pie in the database ")]
        public void ChangePiePrice([Description("The pie id to update")] int pieId, [Description("The new price")]int newPrice)
        {
            //update the price of the pie in the database
        }

    }
}
