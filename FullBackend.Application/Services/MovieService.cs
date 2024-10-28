using FullBackend.Domain.Entities;
using FullBackend.Domain.Interfaces;
using FullBackend.Infrastructure.Repositories;

namespace FullBackend.Application.Services;

public class MovieService
{
    private readonly IMovieRepository _repository;

    public MovieService(IMovieRepository movieRepository)
    {
        _repository = movieRepository;
    }
    public Movie GetWithId(long id) => _repository.GetById(id);
    public void Create(Movie m) => _repository.Create(m);
    public void Remove(long id) => _repository.Remove(id);
    public void Update(Movie m) => _repository.Update(m);
}