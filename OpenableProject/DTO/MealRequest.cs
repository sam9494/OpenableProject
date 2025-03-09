namespace OpenableProject.DTO;

public class MealRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RestaurantId { get; set; }
    public int MenuId { get; set; }
}