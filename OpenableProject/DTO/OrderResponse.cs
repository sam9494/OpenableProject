namespace OpenableProject.DTO;

public class OrderResponse
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public List<OrderMeal> OrderMeals { get; set; }
}