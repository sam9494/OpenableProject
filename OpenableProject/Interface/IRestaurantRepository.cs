using OpenTableProject.DataModel;

namespace OpenTableProject.Interface;

public interface IRestaurantRepository
{
    Task<IEnumerable<RestaurantDTO>> GetAll();
}