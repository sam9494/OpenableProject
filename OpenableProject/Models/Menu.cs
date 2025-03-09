namespace OpenableProject.Models;

public class Menu
{
    public int Id { get; set; }
    public List<Meal> Meals { get; set; }
    public int RestaurantId { get; set; }
}