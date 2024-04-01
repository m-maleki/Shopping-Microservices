using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Shopping.WebApi.Extensions;

public class ApiResultFilterAttribute : ActionFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        switch (context.Result)
        {
            case OkObjectResult okObjectResult:
            {
                var value = okObjectResult.Value;
                context.Result = new JsonResult(value)
                {
                    StatusCode = okObjectResult.StatusCode
                };
                break;
            }
        }

        base.OnResultExecuting(context);
    }
}