namespace GameLibrary.Domain.Games;

public class Game(Guid id, string title, DateOnly releaseDate, decimal price) : DomainEntity(id)
{
    public string Title { get; } = title;

    public DateOnly ReleaseDate { get; } = releaseDate;

    public decimal Price { get; } = price;
}