using OpenTable.Application;

namespace OpenTableProject.Model;

public class Order
{
    public Order(Guid restaurantId, Guid dishId, int amount, decimal totalPrice, string customName, DateTime createTime)
    {
        RestaurantId = restaurantId;
        DishId = dishId;
        Amount = amount;
        TotalPrice = totalPrice;
        CustomName = customName;
        CreateTime = createTime;
    }

    public Guid RestaurantId { get; set; }
    public Guid DishId { get; set; }
    public int Amount { get; set; }
    public decimal TotalPrice { get; set; }
    public string CustomName { get; set; }
    public DateTime CreateTime { get; set; }
}