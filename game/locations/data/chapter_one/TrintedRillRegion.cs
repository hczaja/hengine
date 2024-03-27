using game.graphics.ui.locations;
using game_engine.events.input;
using SFML.Graphics;
using SFML.System;

namespace game.locations.data.chapter_one;

class TrintedRillRegion : ILocation
{
    public string Name => nameof(TrintedRillRegion);


    public IEnumerable<Route> ExternalRoutes { get; }

    public IEnumerable<LocationNode> Nodes { get; }

    public TrintedRillRegion()
    {
        Nodes = new List<LocationNode>()
        {
            new LocationNode("Lumberjack House", 204, 672),
        };
    }
}
