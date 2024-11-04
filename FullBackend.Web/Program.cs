using System.Text;
using FullBackend.Application.Services;
using FullBackend.Application.Services.Auth;
using FullBackend.Application.Services.Helpers;
using FullBackend.Domain.Interfaces;
using FullBackend.Infrastructure;
using FullBackend.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("MovieDb"));
    builder.Services.AddScoped<IMovieRepository, MovieRepository>();
    builder.Services.AddScoped<TokenService>();
    builder.Services.AddScoped<MovieService>();

    builder.Services.AddAuthentication(x =>
    {
        // So the JWT need to be passed as a String in HTTP header Authorization
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        
    }).AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false; // HTTPS not required
        x.SaveToken = true; // Received token must be saved
        x.TokenValidationParameters = new TokenValidationParameters
        {
            // Define the signature that tokens should have been signed with
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthSettings.PrivateKey)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
    builder.Services.AddAuthorization();
    
    builder.Services.AddControllers();
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.Run();