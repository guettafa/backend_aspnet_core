namespace FullBackend.Domain.Entities;

public sealed class Movie(string title, string description, int age) : Entity
{
    public string Title { get; set; } = title;
    public string? Description { get; set; } = description;
    public int Age { get; set; } = age;
}
