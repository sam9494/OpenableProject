namespace OpenTableProject.DataModel;

public class DishDTO
{
    public Guid Id { get; set; }
    public Guid RestaurantId { get; set; }
    public string ImgUrl { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}