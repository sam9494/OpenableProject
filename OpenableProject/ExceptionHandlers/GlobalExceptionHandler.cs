using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace OpenableProject.ExceptionHandlers;
public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "An unexpected error occurred",
            Detail = exception.Message,
            Instance = httpContext.Request.Path,
            Type = $"https://httpstatuses.com/{StatusCodes.Status500InternalServerError}"
        };
        
        Console.WriteLine($"{problemDetails.Title}: {exception.StackTrace}");
        
        httpContext.Response.ContentType = "application/problem+json";
        var result = JsonSerializer.Serialize(problemDetails);
        await httpContext.Response.WriteAsync(result, cancellationToken: cancellationToken);
    
        return true;
    }
}