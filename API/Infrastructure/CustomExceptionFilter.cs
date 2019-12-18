using System;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace API.Infrastructure
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public CustomExceptionFilter() { }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is AuthenticationException)
                context.Result = new UnauthorizedResult();
            else if (context.Exception is BusinessException)
                context.Result = new BadRequestObjectResult(((BusinessException)context.Exception).Error);
        }
    }
}