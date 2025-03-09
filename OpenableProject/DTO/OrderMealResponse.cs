using OpenableProject.Models;

namespace OpenableProject.DTO;

public class OrderMealResponse
{
    public int OrderId { get; set; }
    public int MealId { get; set; }
    public string MealName { get; set; }
    public int Quantity { get; set; }
    public OrderStatusEnum Status { get; set; }
}