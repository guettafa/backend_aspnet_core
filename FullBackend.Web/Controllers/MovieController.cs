using FullBackend.Application.Services;
using FullBackend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FullBackend.Web.Controllers;

[ApiController]
[Route("api/v1/movies")]
public class MovieController(MovieService movieService) : ControllerBase
{
    [HttpGet("{id}")]
    public ActionResult<Movie> GetById(long id) => movieService.GetWithId(id);
}