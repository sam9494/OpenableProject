namespace OpenableProject.Model;

public class Dish
{
    public Dish(Guid id, string imgUrl, string name, decimal price)
    {
        Id = id;
        ImgUrl = imgUrl;
        Name = name;
        Price = price;
    }

    public Guid Id { get; set; }
    public string ImgUrl { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}