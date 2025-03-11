using System.Net;

namespace OpenableProject.Exceptions;

public class OrderNotFoundException(int orderId) : Exception($"Order with id {orderId} not found.")
{
    public static int StatusCode { get; private set; } = StatusCodes.Status404NotFound;
}