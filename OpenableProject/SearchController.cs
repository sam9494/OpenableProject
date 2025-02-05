
using Microsoft.AspNetCore.Mvc;

namespace OpenableProject;
[ApiController]
[Microsoft.AspNetCore.Components.Route("api/[controller]")]
public class SearchController : ControllerBase
{
    // GET
    [HttpGet("Get")]
    public string Get(SearchRequest searchRequest)
    {
       return "Hello World";

    }
}

public class SearchRequest
{
    public DateTime DateTime { get; set; }
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