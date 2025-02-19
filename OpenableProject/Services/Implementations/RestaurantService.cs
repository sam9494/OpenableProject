using Microsoft.VisualBasic;
using OpenableProject.Model;

namespace OpenableProject.Services;

public class RestaurantService : IRestaurantService
{
    private static readonly List<Restaurant?> Restaurants = new List<Restaurant?>
    {
        new Restaurant 
        { 
            RestaurantId =0, 
            Name = "萬客什鍋",
            Address = "台北市松山區八德路四段217號",
            Phone = "02-2345-6789",
            Capacity = 50
        },
        new Restaurant 
        { 
            RestaurantId = 1, 
            Name = "給力盒子",
            Address = "台北市松山區南京東路五段250巷12之1號 ",
            Phone = "02-8765-4321",
            Capacity = 30
        }
    };

    public List<Restaurant?> GetAllRestaurants()
    {
        return Restaurants;
    }

    public Restaurant? GetRestaurantById(int id)
    {
        return Restaurants.FirstOrDefault(r => r != null && r.RestaurantId == id);
    }

}