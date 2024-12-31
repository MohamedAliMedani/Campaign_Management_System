using Campaign_Management_System.Src.Service;
using Microsoft.AspNetCore.Mvc;

namespace Campaign_Management_System.Src.Controller
{
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;

    public AuthController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        // Mock user validation (Replace with database check)
        if (loginDto.Username == "admin" && loginDto.Password == "password")
        {
            var token = _jwtService.GenerateToken(loginDto.Username, "Admin");
            return Ok(new { Token = token });
        }

        return Unauthorized("Invalid credentials");
    }
}

public class LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}

}