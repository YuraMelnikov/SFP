using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SFPrj.ActionFilters
{
    public class ModelValidationAttributeGetById : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            // Do something before the action executes.

            // next() calls the action method.
            var resultContext = await next();
            // resultContext.Result is set.
            // Do something after the action executes.
        }
    }
}
