namespace OpenableProject.ExceptionHandlers;

public class GlobalExceptionHandler(IProblemDetailsService problemDetailsService)
    : ExceptionHandler<Exception>(StatusCodes.Status500InternalServerError, "An unexpected error occurred",problemDetailsService);