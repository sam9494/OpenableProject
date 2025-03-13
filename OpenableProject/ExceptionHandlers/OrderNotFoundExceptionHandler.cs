using OpenableProject.Exceptions;

namespace OpenableProject.ExceptionHandlers;

public class OrderNotFoundExceptionHandler()
    : ExceptionHandler<OrderNotFoundException>(OrderNotFoundException.StatusCode, OrderNotFoundException.Title);
