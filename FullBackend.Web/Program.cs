using FullBackend.Application.Services;
using FullBackend.Domain.Interfaces;
using FullBackend.Infrastructure;
using FullBackend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("MovieDb"));
    
    // builder.Services.AddScoped<IMovieRepository, MovieRepository>();
    // builder.Services.AddScoped<MovieService>();
    
    builder.Services.AddControllers();
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();

app.Run();