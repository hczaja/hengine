using game_engine.graphics;

namespace game.locations;

interface ILocation : IDrawable
{
    string Id { get; }
    IEnumerable<Route> ExternalRoutes { get; }
    IEnumerable<LocationNode> Nodes { get; }
}