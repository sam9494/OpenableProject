using OpenableProject.Controllers;
using OpenableProject.DTO;
using OpenableProject.Models.Enum;

namespace OpenableProject.Models;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public List<OrderMeal> OrderMeals { get; set; }
    public OrderStatus Status { get; set; }
}

public class OrderResponse
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public List<OrderMeal> OrderMeals { get; set; }
    public OrderStatus Status { get; set; }
}