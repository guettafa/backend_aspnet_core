using FullBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FullBackend.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; init; }
}
