using OpenableProject.Model;

namespace OpenableProject.Services;

public interface IRestaurantService
{
    List<Restaurant?> GetAllRestaurants();
    Restaurant? GetRestaurantById(int id);
}