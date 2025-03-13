using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace OpenableProject.ExceptionHandlers;

public class NullExceptionHandler : IExceptionHandler
{
    // 使用 _problemDetailsService 自動設定 ContentType = "application/problem+json"
    // 需要注入 _problemDetailsService
    // private readonly IProblemDetailsService _problemDetailsService;
    //
    // public NullExceptionHandler(IProblemDetailsService problemDetailsService)
    // {
    //     _problemDetailsService = problemDetailsService;
    // }
    
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not NullReferenceException)
        {
            return false;
        }
        
        // _problemDetailsService 也不會幫忙，要自己設定
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "An unexpected error occurred",
            Detail = exception.Message,
            Instance = httpContext.Request.Path
        };
    
        Console.WriteLine($"{problemDetails.Title}: {exception.StackTrace}");
        
        // 使用 _problemDetailsService 自動設定 ContentType = "application/problem+json"
        // 需要使用 problemDetailsContext
        // var problemDetailsContext = new ProblemDetailsContext
        // {
        //     HttpContext = httpContext,
        //     ProblemDetails = problemDetails
        // };
        // await _problemDetailsService.WriteAsync(problemDetailsContext);
        
        // 不用注入 _problemDetailsService
        // 手動指定 ContentType
        httpContext.Response.ContentType = "application/problem+json";
        var result = JsonSerializer.Serialize(problemDetails);
        await httpContext.Response.WriteAsync(result, cancellationToken: cancellationToken);
        
        // 這會強迫 ContentType 變成 application/json，若想實踐 application/problem+json，不能用此寫法
        // await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        
        return true;
    }
}