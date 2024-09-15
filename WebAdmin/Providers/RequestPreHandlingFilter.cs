using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace WebAdmin.Providers
{
    public class RequestPreHandlingFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Do something before the action executes.
            await next();
            // Do something after the action executes.
        }
    }
}
