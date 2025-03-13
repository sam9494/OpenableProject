using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using OpenableProject.Exceptions;

namespace OpenableProject.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    //private readonly ILogger<ExceptionMiddleware> _logger; 之後再處理

    public ExceptionMiddleware(RequestDelegate next)//, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        //_logger = logger;
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
        var (statusCode, title) = ex switch
        {
            OrderNotFoundException => (OrderNotFoundException.StatusCode, "Order not found."),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred")
        };
        
        context.Response.StatusCode = statusCode;

        var problemDetail = new ProblemDetails()
        {
            Status = statusCode,
            Title = title,
            Detail = ex.Message,
            Instance = context.Request.Path,
            Type = $"https://httpstatuses.com/{statusCode}"
        };
        
        context.Response.ContentType = "application/problem+json"; //RFC 7807
        await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetail)); //這邊才會維持 ContentType = "application/problem+json"
        // await context.Response.WriteAsJsonAsync(problemDetail); //這邊會強迫設定 ContentType = "application/json
    }
}