using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace OpenableProject.ExceptionHandlers;

public class NullExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not NullReferenceException)
        {
            return false;
        }
        
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Title = exception.Message,
            Detail = exception.Message,
            Instance = httpContext.Request.Path,
            Type = $"https://httpstatuses.com/{StatusCodes.Status400BadRequest}"
        };
        
        Console.WriteLine($"{problemDetails.Title}: {exception.StackTrace}");

        httpContext.Response.ContentType = "application/problem+json";
        var result = JsonSerializer.Serialize(problemDetails);
        await httpContext.Response.WriteAsync(result, cancellationToken: cancellationToken);
        
        return true;
    }
}