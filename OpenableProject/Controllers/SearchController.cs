
using Microsoft.AspNetCore.Mvc;

namespace OpenableProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    // GET
    [HttpGet]
    public string Search()
    {
       return "";

    }
}