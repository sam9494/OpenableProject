using OpenableProject.Controllers;
using OpenableProject.Storage;

namespace OpenableProject.Repositories;

public class MenuRepository
{
    public List<Menu> GetAll()
    {
        return MenuStorage.GetAll();
    }

    public List<Menu> GetByRestaurantId(int restaurantId)
    {
        return MenuStorage.GetByRestaurantId(restaurantId);
    }
}