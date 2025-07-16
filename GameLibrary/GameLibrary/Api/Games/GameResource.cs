namespace GameLibrary.Api.Games;

public record GameResource(Guid? Id, string Title, DateOnly ReleaseDate, decimal Price);