using OpenableProject.Model;

namespace OpenableProject.Services;

public interface IMenuService
{
    IEnumerable<Menu> GetMenuByRestaurantId(int id);
}