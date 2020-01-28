using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Contracts;

namespace SFPrj.ActionFilters
{
    public class ModelValidationAttribute : ActionFilterAttribute
    {
        private ILoggerManager _logger;

        public ModelValidationAttribute(ILoggerManager logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                _logger.LogError($"Invalid model {context.ActionDescriptor.DisplayName}.");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
            else
            {
                _logger.LogInfo($"Valid model {context.ActionDescriptor.DisplayName}.");
            }
        }
    }
}
