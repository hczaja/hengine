using game_engine.events;
using game_engine.events.input;
using game_engine.graphics;

namespace game.locations;

interface ILocation
{
    string Name { get; }
    IEnumerable<Route> ExternalRoutes { get; }
    IEnumerable<LocationNode> Nodes { get; }
}