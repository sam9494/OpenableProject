namespace OpenableProject.Models;

public class OrderRequest
{
    public string CustomerName { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}