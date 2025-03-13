using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OpenableProject.Exceptions;

namespace OpenableProject.ExceptionHandlers;
public class OrderNotFoundExceptionHandler : IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService;
    
    public OrderNotFoundExceptionHandler(IProblemDetailsService problemDetailsService)
    {
        _problemDetailsService = problemDetailsService;
    }
    
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
