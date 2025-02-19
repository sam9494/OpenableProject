namespace OpenableProject.Model;

public class CreateOrderRequest
{
    public int RestaurantId { get; set; }
    public List<OrderItemRequest> Items { get; set; } = new List<OrderItemRequest>();
}