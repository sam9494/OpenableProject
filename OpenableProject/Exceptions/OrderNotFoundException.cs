namespace OpenableProject.Exceptions;

public class OrderNotFoundException : KeyNotFoundException
{
    public int OrderId { get; }
    public OrderNotFoundException(int orderId) 
        : base($"Order with id {orderId} not found.")
    {
        OrderId = orderId;
    }
}