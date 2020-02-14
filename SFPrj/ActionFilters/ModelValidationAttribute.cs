using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SFPrj.ActionFilters
{
    public class ModelValidationAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result == null)
            {
                context.Result = new NotFoundResult();
                return;
            }
            if (!context.ModelState.IsValid)
            {
                context.Result = new NotFoundResult();
                return;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
