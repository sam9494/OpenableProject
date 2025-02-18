using Dapper;
using OpenTableProject.DataModel;
using OpenTableProject.Interface;

namespace OpenTableProject.Repository;

public class DishRepository : IDishRepository
{
    private readonly IDBConnectionFactory _dbConnectionFactory;

    public DishRepository(IDBConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }


    public async Task<IEnumerable<DishDTO>> GetAll()
    {
        await using (var conn = _dbConnectionFactory.CreateDBConnection())
        {
            var result = await conn.QueryAsync<DishDTO>("SELECT * FROM Dish");
            return result;
        }
    }
    
    public async Task<IEnumerable<DishDTO>> GetByRestaurantId(Guid repositoryId)
    {
        var sql =
            @"
        SELECT * FROM Dish 
        WHERE RestaurantId = @RestaurantId
    ";

        var parameters = new DynamicParameters();
        parameters.Add("RestaurantId", repositoryId);

        await using (var conn = _dbConnectionFactory.CreateDBConnection())
        {
            var result = await conn.QueryAsync<DishDTO>(sql, parameters);
            return result;
        }
    }
}