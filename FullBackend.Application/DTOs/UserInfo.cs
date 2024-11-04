using FullBackend.Domain.Entities;

namespace FullBackend.Application.DTOs;

public record UserInfo(string Username, string Email, string Password)
{
    public static UserInfo FromUser(User u)
        => new UserInfo(u.Username, u.Email, u.Password);
}
