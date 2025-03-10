namespace OpenableProject.DTO;

public class OrderMealRequest
{
    public int MealId { get; set; }
    public string MealName { get; set; }
    public int Quantity { get; set; }
    public int RestaurantId { get; set; }
}