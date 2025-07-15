using GameLibrary.Api.Games;

namespace GameLibrary.Api;

public static class ActionRegistrations
{
    public static void MapControllerActions(this WebApplication app)
    {
        app.MapGameActions();
    }
}