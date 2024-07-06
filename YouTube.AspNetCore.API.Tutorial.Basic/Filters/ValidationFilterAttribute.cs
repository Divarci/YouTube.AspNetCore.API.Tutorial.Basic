using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Others;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Filters
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToList();

                if (errors.Any(x => x.Contains("request")))
                {
                    List<string> systemError = new();
                    foreach (var error in errors)
                    {
                        var tempError = "Json Format Error: " + error;
                        systemError.Add(tempError);
                    }
                    context.Result = new ObjectResult(CustomResponseDto<NoContentDto>.Fail(400, systemError));
                }
                else
                {
                    context.Result = new ObjectResult(CustomResponseDto<NoContentDto>.Fail(400, errors));

                }
            }
        }
    }
}