using OpenTable.Application;

namespace OpenTableProject.Model;

public class Order
{
    public Order(string restaurantName, string dishName,int amount, decimal totalPrice, string customName, DateTime createTime)
    {
        RestaurantName = restaurantName;
        DishName = dishName;
        Amount = amount;
        TotalPrice = totalPrice;
        CustomName = customName;
        CreateTime = createTime;
    }

    public string RestaurantName { get; set; }
    public string DishName { get; set; }
    public int Amount { get; set; }
    public decimal TotalPrice { get; set; }
    public string CustomName { get; set; }
    public DateTime CreateTime { get; set; }
}