using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace OpenableProject.ExceptionHandlers;

public class ExceptionHandler<TException> : IExceptionHandler where TException : Exception
{
    private readonly int _statusCode;
    private readonly string _title;
    
    //IProblemDetailsService 要用 postman 打，Response 才會是 ProblemDetails 格式
    private readonly IProblemDetailsService _problemDetailsService;

    protected ExceptionHandler(int statusCode, string title, IProblemDetailsService problemDetailsService)
    {
        _statusCode = statusCode;
        _title = title;
        _problemDetailsService = problemDetailsService;

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

        var problemContext = new ProblemDetailsContext { HttpContext = httpContext, ProblemDetails = problemDetails };
        await _problemDetailsService.WriteAsync(problemContext);
    
        return true;
    }
}