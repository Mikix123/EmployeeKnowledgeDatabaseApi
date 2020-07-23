using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text.Json;

namespace EmployeeKnowledgeDatabase.Infrastructure
{
    public class ValidatorActionFilter : IActionFilter
    {
        private readonly ILogger logger;

        public ValidatorActionFilter(ILogger<ValidatorActionFilter> logger)
        {
            this.logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ModelState.IsValid)
                return;

            var result = new ContentResult();

            var errors = filterContext.ModelState
                .ToDictionary(valuePair => valuePair.Key, valuePair => valuePair.Value.Errors
                    .Select(x => x.ErrorMessage)
                    .ToArray());

            var content = JsonSerializer.Serialize(new { errors });
            result.Content = content;
            result.ContentType = "application/json";

            filterContext.HttpContext.Response.StatusCode = 422; //unprocessable entity;
            filterContext.Result = result;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}