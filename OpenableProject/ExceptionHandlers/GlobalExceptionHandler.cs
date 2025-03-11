namespace OpenableProject.ExceptionHandlers;

public class GlobalExceptionHandler() : 
    ExceptionHandler<Exception>(StatusCodes.Status500InternalServerError, "An unexpected error occurred");