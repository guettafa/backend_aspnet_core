using FullBackend.Application.DTOs;
using FullBackend.Application.Services.Auth;
using FullBackend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FullBackend.Web.Controllers;

[ApiController]
[Route("/api/v1/auth")]
public class AuthController(TokenService tokenService) : ControllerBase
{
    [HttpPost("signin")]
    public IActionResult SignIn() => 
        Ok("JWT...");

    [HttpPost("signup")]
    public IActionResult SignUp(UserInfo userInfo) => 
        Ok(tokenService.GenerateToken(new User(userInfo.Username, userInfo.Email, userInfo.Password, ["admin"])));
}