using OpenTableProject.Interface;
using OpenTableProject.Repository;

namespace OpenTableProject;

public static class RegisterExtensions
{
    public static IServiceCollection AddConnection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration.GetConnectionString("OpenTableDb"));
        services.AddScoped<IDBConnectionFactory, DBConnectionFactory>();
        return services;
    }
    
    public static IServiceCollection RegisterRepository(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        services.AddScoped<IDishRepository, DishRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
           
        return services;
    }
}