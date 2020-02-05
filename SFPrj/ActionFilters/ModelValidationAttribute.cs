using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SFPrj.ActionFilters
{
    public class ModelValidationAttribute : IAsyncActionFilter
    {
        public async Task OnActionExecuting(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.Result == null)
            {
                context.Result = new NotFoundResult();
            }
            if (!context.ModelState.IsValid)
            {
                context.Result = new NotFoundResult();
            }
            await next();
        }

        public async Task OnActionExecuted(ActionExecutedContext context, ActionExecutionDelegate next)
        {
            if (context.Result == null)
            {
                context.Result = new NotFoundResult();
            }
            if (!context.ModelState.IsValid)
            {
                context.Result = new NotFoundResult();
            }
            await next();
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await next();
        }
    }
}
