using OpenTable.Application;

namespace OpenTableProject.Model;

public class Order
{
    public Guid DishId { get; set; }
    public int Amount { get; set; }
    public decimal TotalPrice { get; set; }
    public string CustomName { get; set; }
}