namespace OpenableProject.Model;

public class Restaurant
{
    public Restaurant(Guid id, string name, List<Dish> dishes)
    {
        Id = id;
        Name = name;
        Dishes = dishes;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Dish> Dishes { get; set; }
}