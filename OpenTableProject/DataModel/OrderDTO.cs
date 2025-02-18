namespace OpenTableProject.DataModel;

public class OrderDTO
{
    /// <summary>
    /// 訂單Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// 餐廳Id
    /// </summary>
    public Guid RestaurantId { get; set; }
    public Guid DishId { get; set; }
    public int Amount { get; set; }
    public decimal TotalPrice { get; set; }
    public string CustomName { get; set; }
    public DateTime CreateTime { get; set; }
}