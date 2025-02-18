namespace OpenTableProject.Model;

public class OrderRequest
{
    public Guid DishId { get; set; }
    public int Amount { get; set; }
    public string CustomName { get; set; }
}