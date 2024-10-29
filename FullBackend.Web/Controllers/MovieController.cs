using FullBackend.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FullBackend.Web.Controllers;

[ApiController]
[Route("api/v1/movies")]
public class MovieController(MovieService movieService) : ControllerBase
{
    [HttpGet("/{id}")]
    public IActionResult GetById(long id)
    {
        try { return Ok(movieService.GetWithId(id)); }
        catch (Exception e) { return NotFound(e.Message); }
    }
}