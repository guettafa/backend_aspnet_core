using FullBackend.Application.DTOs;
using FullBackend.Application.Services;
using FullBackend.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FullBackend.Web.Controllers;

[ApiController]
[Route("api/v1/movies")]
public class MovieController(MovieService movieService) : ControllerBase
{
    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetById(long id)
    {
        try { return Ok(movieService.GetWithId(id)); }
        catch (Exception e) { return NotFound(e.Message); }
    }

    [HttpPost("")]
    public IActionResult AddMovie(MovieInfo m)
    {
        movieService.Create(new Movie(m.Title, m.Description, 20));
        return Ok("Movie has been added with success");
    }
}