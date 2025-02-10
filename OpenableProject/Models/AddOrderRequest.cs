namespace OpenableProject.Models;

public class AddOrderRequest
{
    public string CustomerName { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}