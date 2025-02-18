using Dapper;
using OpenTableProject.DataModel;
using OpenTableProject.Interface;

namespace OpenTableProject.Repository;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly IDBConnectionFactory _dbConnectionFactory;

    public RestaurantRepository(IDBConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<RestaurantDTO>> GetAll()
    {
        await using (var conn = _dbConnectionFactory.CreateDBConnection())
        {
            var result = await conn.QueryAsync<RestaurantDTO>("SELECT * FROM Restaurant");
            return result;
        }
    }
}