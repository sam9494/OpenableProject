namespace OpenableProject.Model;

public class OrderItem
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int MenuId { get; set; }
    public string MenuName { get; set; }
    public int Quantity { get; set; }
    public int UnitPrice { get; set; }
}