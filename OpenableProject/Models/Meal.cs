namespace OpenableProject.Models;

public class Meal
{
    public Meal(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
}