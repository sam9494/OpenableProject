using OpenableProject.Controllers;
using OpenableProject.Enum;

namespace OpenableProject.DTO;

public class OrderRequest
{
    public string CustomerName { get; set; }
    public List<OrderMeal> OrderMeals { get; set; }
}