using OpenableProject.Controllers;
using OpenableProject.DTO;

namespace OpenableProject.Models;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public List<OrderMeal> OrderMeals { get; set; }
}

public class OrderResponse
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public List<OrderMeal> OrderMeals { get; set; }
}