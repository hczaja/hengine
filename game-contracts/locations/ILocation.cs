namespace game_contracts.locations;

public interface ILocation
{
    string Name { get; }
    //IEnumerable<Route> ExternalRoutes { get; }
    IEnumerable<LocationNode> Nodes { get; }
}