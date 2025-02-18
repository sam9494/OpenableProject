using OpenTableProject.DataModel;
using OpenTableProject.Model;

namespace OpenTableProject.Interface;

public interface IOrderRepository
{
    Task<IEnumerable<OrderDTO>> GetAll();
    Task<bool> CreateOrder(OrderRequest order);
    Task<bool> ClearAll();
}