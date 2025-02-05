
using Microsoft.AspNetCore.Mvc;

namespace OpenableProject;
[ApiController]
[Microsoft.AspNetCore.Components.Route("api/[controller]")]
public class RestaurantSearchController : ControllerBase
{
    // GET
    [HttpGet("Get")]
    public RestaurantSearchResponse Get([FromQuery]RestaurantSearchRequest request)
    {
        return new RestaurantSearchResponse()
        {
            Restaurants = new List<Restaurant>()
            {
                new Restaurant
                {
                    Id = 1,
                    Name = "麥當勞",
                    CommentsNumber = 400,
                    CommentPoints = 4.1
                },
                new Restaurant
                {
                    Id = 2,
                    Name = "KFC",
                    CommentsNumber = 403,
                    CommentPoints = 2.1
                }
            }
        };

    }
}

public class RestaurantSearchResponse
{
    public List<Restaurant> Restaurants { get; set; }
}

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CommentsNumber { get; set; }
    public double CommentPoints { get; set; }
}

public class RestaurantSearchRequest
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int PartySize { get; set; }
    public CountryCode CountyCode { get; set; }
    public DistrictCode DistrictCode { get; set; } 
    public decimal UpperPrice { get; set; }
    public decimal LowerPrice { get; set; } 
    
    //用餐選項 
    public DiningType DiningType { get; set; }
    
    //料理種類
    public MealType MealType { get; set; }
    
    // public string SelectedSorting { get;set; } //TODO: 之後處理 
    // public string Keyword { get; set; } TODO: 之後處理
    // public int PageNumber { get; set; } TODO: 之後處理
}

public enum DiningType
{
}

public enum MealType
{
}

public enum DistrictCode
{
}

public enum CountryCode
{
}