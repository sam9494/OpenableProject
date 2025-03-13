using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace OpenableProject.ExceptionHandlers;

public class ExceptionHandler<TException> : IExceptionHandler where TException : Exception
{
    private readonly int _statusCode;
    private readonly string _title;
    protected ExceptionHandler(int statusCode, string title)
    {
        _statusCode = statusCode;
        _title = title;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not TException)
        {
            return false;
        }
        httpContext.Response.StatusCode = _statusCode;
        
        var problemDetails = new ProblemDetails
        {
            Status = _statusCode,
            Title = _title,
            Detail = exception.Message,
            Instance = httpContext.Request.Path,
            Type = $"https://httpstatuses.com/{_statusCode}"
        };
        
        Console.WriteLine($"{_title}: {exception.StackTrace}");
        
        httpContext.Response.ContentType = "application/problem+json";
        var result = JsonSerializer.Serialize(problemDetails);
        await httpContext.Response.WriteAsync(result, cancellationToken: cancellationToken);
    
        return true;
    }
}