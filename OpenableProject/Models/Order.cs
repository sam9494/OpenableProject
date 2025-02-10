namespace OpenableProject.Models;

public class Order
{
    public List<OrderItem> OrderItems { get; set; }
    public int Id { get; set; }

    public void Init(List<OrderItem> orderItems)
    {
        OrderItems = orderItems;
    }
}