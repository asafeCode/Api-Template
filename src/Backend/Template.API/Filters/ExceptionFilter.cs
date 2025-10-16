using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExceptionsBase;
using System.Net;

namespace MyRecipeBook.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is TemplateException templateException)
            HandleProjectException(templateException, context);
        else
            ThrowUnknowException(context);  
    }

    private static void HandleProjectException(TemplateException templateException, ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)templateException.GetStatusCode();
        context.Result = new ObjectResult(new ResponseErrorJson(templateException.GetErrorMessage()));
    }
    private static void ThrowUnknowException(ExceptionContext context)
    { 
         context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
         context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagesException.UNKNOWN_ERROR));
    }


}
