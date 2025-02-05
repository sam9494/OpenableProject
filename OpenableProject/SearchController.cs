
using Microsoft.AspNetCore.Mvc;

namespace OpenableProject;
[ApiController]
[Microsoft.AspNetCore.Components.Route("api/[controller]")]
public class SearchController : ControllerBase
{
    // GET
    [HttpGet("Index")]
    public string Index()
    {
       return "Hello World";

    }
}