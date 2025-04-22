using Microsoft.AspNetCore.Mvc;

namespace TaskManagerAPI.API.Controllers;
// API/Controllers/AuthController.cs

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private const string AdminPassword = "admin123"; // SonarQube: S2068 - Credentials should not be hard-coded
    
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (request.Password == AdminPassword) // Vulnerabilidad de seguridad
        {
            return Ok(new { Token = "fake-token" });
        }
        return Unauthorized();
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}