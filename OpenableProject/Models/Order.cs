namespace OpenableProject.Controllers;

public record Order
{
    public int Id { get; set; }
    public List<int> Items { get; set; }
    public decimal Total { get; set; }
}