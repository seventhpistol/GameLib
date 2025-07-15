using GameLibrary.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Api.Games;

public static class GameControllerRegistration
{
    public static void MapGameActions(this WebApplication app)
    {
        string basePattern = new ApiRoutePattern("games").ToString();
        
        app.MapGet(basePattern, async ([FromServices] IRepository<GameLibrary.Domain.Games.Game> repository) => await repository.GetAllAsync());

        app.MapPost(basePattern, async Task ([FromBody] GameResource gameResource, [FromServices] IRepository<GameLibrary.Domain.Games.Game> repository) => 
            await repository.CreateAsync(new Domain.Games.Game(gameResource.Title, gameResource.ReleaseDate, gameResource.Price)));

        app.MapDelete($"{basePattern}" + "/{id:guid}",
            async (Guid id, [FromServices] IRepository<GameLibrary.Domain.Games.Game> repository) =>
            await repository.DeleteByIdAsync(id));
    }
}