namespace FullBackend.Domain.Entities;

public class User(string username, string email, string password, string[] roles) : Entity
{
    public string Username { get; set; } = username;
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
    public string[] Roles { get; set; } = roles;
}