namespace GameLibrary.Domain.Games;

public class Game(string title, DateOnly releaseDate, decimal price) : DomainEntity(Guid.NewGuid())
{
    public string Title { get; } = title;

    public DateOnly ReleaseDate { get; } = releaseDate;

    public decimal Price { get; } = price;
}