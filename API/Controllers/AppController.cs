using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagerAPI.API.Controllers;
// API/Controllers/AuthController.cs

[ApiController]
[Route("api/[controller]")]
public class AppController : ControllerBase
{
    private Version version = Assembly.GetExecutingAssembly().GetName().Version;
    
    [HttpGet("get")]
    public IActionResult get()
    {
        return Ok(new { Version = version.ToString() });
    }
}
