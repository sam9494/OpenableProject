using OpenableProject.DTO;
using OpenableProject.Enum;

namespace OpenableProject.Models;

public class OrderResponse
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public List<OrderMeal> OrderMeals { get; set; }
    public OrderStatus Status { get; set; }
}