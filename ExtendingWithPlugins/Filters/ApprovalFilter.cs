using Microsoft.SemanticKernel;

namespace ExtendingWithPlugins.Filters
{
    public class ApprovalFilter() : IFunctionInvocationFilter
    {
        public async Task OnFunctionInvocationAsync(FunctionInvocationContext context, Func<FunctionInvocationContext, Task> next)
        {
            if (context.Function.PluginName == "PieManagementPlugin" && context.Function.Name == "ChangePiePrice")
            {
                Console.WriteLine("The system wants to update the price of a pie, do you want to proceed? (Y/N)");
                string shouldProceed = Console.ReadLine()!;

                if (shouldProceed != "Y")
                {
                    context.Result = new FunctionResult(context.Result, "The price change was not approved by the user");
                    return;
                }
            }

            await next(context);
        }
    }
}
