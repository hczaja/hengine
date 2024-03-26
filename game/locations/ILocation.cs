using game_engine.events;
using game_engine.events.input;
using game_engine.graphics;

namespace game.locations;

interface ILocation : IDrawable, IEventHandler<MouseEvent>
{
    string Id { get; }
    IEnumerable<Route> ExternalRoutes { get; }
    IEnumerable<LocationNode> Nodes { get; }
}