using Microsoft.AspNetCore.Mvc;
using Contracts;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SFPrj.ActionFilters
{
    public class ModelNullAttribute : ActionFilterAttribute
    {
        private ILoggerManager _logger;

        public ModelNullAttribute(ILoggerManager logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var myResult = (OkObjectResult)context.Result;
            if (myResult.Value == null)
            {
                _logger.LogError($"{context.ActionDescriptor.DisplayName} object is null.");
                context.Result = new BadRequestObjectResult("Image object is null");
            }
            else
            {
                _logger.LogInfo($"{context.ActionDescriptor.DisplayName} object is not null.");
            }
        }
    }
}
