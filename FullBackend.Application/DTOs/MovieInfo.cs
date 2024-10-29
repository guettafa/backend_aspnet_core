using FullBackend.Domain.Entities;

namespace FullBackend.Application.DTOs;

public record MovieInfo(string Title, string Description)
{
    public static MovieInfo FromMovie(Movie m) => 
        new(m.Title, m.Description = "No description"); 
}
