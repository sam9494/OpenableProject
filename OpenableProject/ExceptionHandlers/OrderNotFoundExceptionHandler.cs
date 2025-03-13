using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OpenableProject.Exceptions;

namespace OpenableProject.ExceptionHandlers;
public class OrderNotFoundExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not OrderNotFoundException)
        {
            return false;
        }
    
        httpContext.Response.StatusCode = OrderNotFoundException.StatusCode;
        
        var problemDetails = new ProblemDetails
        {
            Status = OrderNotFoundException.StatusCode,
            Title = OrderNotFoundException.Title,
            Detail = exception.Message,
            Instance = httpContext.Request.Path,
            Type = $"https://httpstatuses.com/{OrderNotFoundException.StatusCode}"
        };
    
        Console.WriteLine($"{problemDetails.Title}: {exception.StackTrace}");

        httpContext.Response.ContentType = "application/problem+json";
        var result = JsonSerializer.Serialize(problemDetails);
        await httpContext.Response.WriteAsync(result, cancellationToken: cancellationToken);
    
        return true;
    }
}
