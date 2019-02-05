using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using YevhenUshakov.TestProject.Web.Api.Model;

namespace YevhenUshakov.TestProject.Web.Api.Utilities.Filters
{
    public class ValidateModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var response = new ApiResponse(context.ModelState);
                context.Result = new JsonResult(response);
            }
        }
    }
}
