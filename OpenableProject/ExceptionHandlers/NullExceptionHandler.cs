using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace OpenableProject.ExceptionHandlers;

public class NullExceptionHandler : IExceptionHandler
{
    // 使用 _problemDetailsService 自動設定 ContentType = "application/problem+json"
    // 需要注入 _problemDetailsService
    private readonly IProblemDetailsService _problemDetailsService;
    
    public NullExceptionHandler(IProblemDetailsService problemDetailsService)
    {
        _problemDetailsService = problemDetailsService;
    }
    
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
        
        // 使用 _problemDetailsService 自動設定 ContentType = "application/problem+json"
        // 需要使用 problemDetailsContext
        var problemDetailsContext = new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails = problemDetails
        };
        
        Console.WriteLine($"{problemDetails.Title}: {exception.StackTrace}");
        await _problemDetailsService.WriteAsync(problemDetailsContext);
        
        return true;
    }
}