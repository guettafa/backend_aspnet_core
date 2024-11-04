using FullBackend.Application.DTOs;
using FullBackend.Domain.Entities;
using FullBackend.Domain.Interfaces;

namespace FullBackend.Application.Services;

public class MovieService(IMovieRepository repository)
{
    public MovieInfo GetWithId(long id) => 
        MovieInfo.FromMovie(repository.GetById(id));
    
    public void Create(Movie m) => repository.Create(m);
    public void Remove(long id) => repository.Remove(id);
    public void Update(Movie m) => repository.Update(m);
}