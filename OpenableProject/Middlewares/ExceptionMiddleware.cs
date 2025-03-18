using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace OpenableProject.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);// 未來再用 logger
            Console.WriteLine(ex.StackTrace);// 這邊才會有完整堆疊
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var (statusCode, title) =
            (StatusCodes.Status500InternalServerError, "An unexpected error occurred");
        
        context.Response.StatusCode = statusCode;

        var problemDetail = new ProblemDetails()
        {
            Status = statusCode,
            Title = title,
            Detail = ex.Message,
            Instance = context.Request.Path,
            Type = $"https://httpstatuses.com/{statusCode}"
        };
        
        context.Response.ContentType = "application/problem+json"; 
        await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetail));
    }
}