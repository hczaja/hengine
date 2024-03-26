using game_engine.events.input;
using SFML.Graphics;

namespace game.locations.data.chapter_one;

class TrintedRill : ILocation
{
    public string Id => nameof(TrintedRill);

    public IEnumerable<Route> ExternalRoutes => throw new NotImplementedException();

    public IEnumerable<LocationNode> Nodes { get; }

    public TrintedRill()
    {
        Nodes = new List<LocationNode>()
        {
        };
    }

    public void Draw(RenderTarget render)
    {
        throw new NotImplementedException();
    }

    public void Handle(MouseEvent @event)
    {
        throw new NotImplementedException();
    }
}
