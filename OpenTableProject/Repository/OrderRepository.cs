using Dapper;
using OpenTableProject.DataModel;
using OpenTableProject.Interface;
using OpenTableProject.Model;

namespace OpenTableProject.Repository;

public class OrderRepository:IOrderRepository
{
    private readonly IDBConnectionFactory _dbConnectionFactory;

    public OrderRepository(IDBConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }


    public async Task<IEnumerable<OrderDTO>> GetAll()
    {
        await using (var conn = _dbConnectionFactory.CreateDBConnection())
        {
            var result = await conn.QueryAsync<OrderDTO>("SELECT * FROM Order");
            return result;
        }
    }
    
    public async Task<bool> CreateOrder(OrderRequest order)
    {
        var sql =
            @"
        INSERT INTO [Order] (
[DishId]
,[Amount]
,[CustomName])
VALUES (
@DishId,
@Amount,
@CustomName
)
    ";

        var parameters = new DynamicParameters();
        parameters.Add("DishId", order.DishId);
        parameters.Add("Amount", order.Amount);
        parameters.Add("CustomName", order.CustomName);

        await using (var conn = _dbConnectionFactory.CreateDBConnection())
        {
            var affectedRows = await conn.ExecuteAsync(sql, parameters);
            return affectedRows > 0;
        }
    }
    
    
    public async Task<bool> ClearAll()
    {
        await using (var conn = _dbConnectionFactory.CreateDBConnection())
        {
            var affectedRows = await conn.ExecuteAsync("DELETE FROM Order");
            return affectedRows > 0;
        }
    }
}