namespace OpenableProject.ExceptionHandlers;

public class NullExceptionHandler() 
    : ExceptionHandler<NullReferenceException>(StatusCodes.Status400BadRequest, nameof(NullReferenceException));