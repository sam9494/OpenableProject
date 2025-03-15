using Microsoft.AspNetCore.Diagnostics;
using OpenableProject.Services;

namespace OpenableProject.ExceptionHandler;

public class NotExistExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.RequestServices.GetRequiredService<ILogger<NotExistExceptionHandler>>().LogError(exception, "Not Exist");

        if (exception is not NotExistException)
        {
            return false;           
        }
        
        httpContext.Response.StatusCode = 404;
        // 可以自行設定要回傳的物件內容
        await httpContext.Response.WriteAsJsonAsync(
            new
            {
                exception.Message
            },cancellationToken);

        return true;
    }
}


public class NotExistException(string message) : Exception(message);