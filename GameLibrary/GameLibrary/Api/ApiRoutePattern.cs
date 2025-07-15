namespace GameLibrary.Api;

public readonly struct ApiRoutePattern(string actionName)
{
    private string ActionName { get; } = actionName;
    
    

    public override string ToString() => $"api/{ActionName}";
}