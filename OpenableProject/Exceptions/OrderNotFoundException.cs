namespace OpenableProject.Exceptions;

public class OrderNotFoundException : Exception
{
    public const string Title = "Order not found";
    public const int StatusCode = StatusCodes.Status404NotFound;
    public OrderNotFoundException(int orderId) : base($"Order with id {orderId} not found.") { }
}