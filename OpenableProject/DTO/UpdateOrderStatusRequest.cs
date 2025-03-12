namespace OpenableProject.DTO;


public class UpdateOrderStatusRequest
{
    public int OrderId { get; set; }
    public OrderStatus NewStatus { get; set; }
}