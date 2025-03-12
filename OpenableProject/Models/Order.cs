using OpenableProject.Controllers;
using OpenableProject.DTO;

namespace OpenableProject.Models;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public List<OrderMeal> OrderMeals { get; set; }
    
    public OrderStatus Status { get; set; } = OrderStatus.Created; 
    
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    
    public DateTime? UpdatedTime { get; set; }
}

public class OrderResponse
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public List<OrderMeal> OrderMeals { get; set; }
    
    public OrderStatus Status { get; set; }
    public string StatusName => Status.ToString();
    
    public DateTime CreatedTime { get; set; }
    
    public DateTime? UpdatedTime { get; set; }
}