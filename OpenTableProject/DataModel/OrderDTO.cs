namespace OpenTableProject.DataModel;

public class OrderDTO
{
    public Guid Id { get; set; }
    public Guid RestaurantId { get; set; }
    public Guid DishId { get; set; }
    public int Amount { get; set; }
    public decimal TotalPrice { get; set; }
    public string CustomName { get; set; }
    public DateTime CreatedAt { get; set; }
}