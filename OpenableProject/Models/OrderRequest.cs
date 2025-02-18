namespace OpenableProject.Controllers;

public record OrderRequest
{
    public List<int> Items { get; set; }
}