using GameLibrary.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Api.Games;

public static class GameControllerRegistration
{
    public static void MapGameActions(this WebApplication app)
    {
        app.MapGet(new ApiRoutePattern("games").ToString(), async ([FromServices] IRepository<GameLibrary.Domain.Games.Game> repository) => await repository.GetAllAsync());
    }
}