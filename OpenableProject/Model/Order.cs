namespace OpenableProject.Model;

public class Order
{
    public Guid DishId { get; set; }
    public int Amount { get; set; }
    public decimal TotalPrice { get; set; }
    public string CustomName { get; set; }
    
    //DataModel 
    // public Guid Id { get; set; }
    // public Guid RestaurantId { get; set; }
    // public Guid DishId { get; set; }
    // public int Amount { get; set; }
    // public decimal TotalPrice { get; set; }
    // public string CustomName { get; set; }
    // public DateTime CreatedAt { get; set; }
    // public OrderStatusEnum Status { get; set; }
}