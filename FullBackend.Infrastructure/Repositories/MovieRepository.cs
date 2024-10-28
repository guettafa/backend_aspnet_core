using FullBackend.Domain.Entities;
using FullBackend.Domain.Interfaces;

namespace FullBackend.Infrastructure.Repositories;

public class MovieRepository(ApplicationDbContext context) : IMovieRepository
{
    public Movie GetById(long id) => 
        context.Movies.Find(id) ?? throw new Exception("Movie can't be found");

    public void Remove(long id) =>
        context.Remove(GetById(id)).Context.SaveChanges();
    
    public void Create(Movie movie) => 
        context.Add(movie).Context.SaveChanges();

    public void Update(Movie movie) =>
        context.Update(movie).Context.SaveChanges();
}