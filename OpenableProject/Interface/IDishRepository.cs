using OpenTableProject.DataModel;

namespace OpenTableProject.Interface;

public interface IDishRepository
{
    Task<IEnumerable<DishDTO>> GetAll();
    Task<IEnumerable<DishDTO>> GetByRestaurantId(Guid repositoryId);
}