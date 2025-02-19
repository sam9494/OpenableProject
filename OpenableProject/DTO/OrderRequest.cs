using OpenableProject.Controllers;

namespace OpenableProject.DTO;

public class OrderRequest
{
    public string CustomerName { get; set; }
    public List<MealDetail> Meals { get; set; }
}