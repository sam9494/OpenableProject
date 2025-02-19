namespace OpenableProject.Model;

public class Order
{
    public int OrderId { get; set; }
    public int RestaurantId { get; set; }
    public string RestaurantName { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderItem> Items { get; set; } 
    public decimal TotalAmount { get; set; }
    
    public enum OrderStatus
    {
        Created = 0,
        Completed = 1,
        Cancelled = 2
    }
}