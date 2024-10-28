using FullBackend.Domain.Entities;

namespace FullBackend.Domain.Interfaces;

public interface IMovieRepository
{
    Movie GetById(long id);
    void Remove(long id);
    void Create(Movie movie);
    void Update(Movie movie);
}