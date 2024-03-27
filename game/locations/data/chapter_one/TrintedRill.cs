using game.graphics.ui.locations;
using game_engine.events.input;
using SFML.Graphics;

namespace game.locations.data.chapter_one;

class TrintedRill : ILocation
{
    public string Id => nameof(TrintedRill);

    public IEnumerable<Route> ExternalRoutes => throw new NotImplementedException();

    public IEnumerable<DrawableLocationNode> Nodes { get; }

    public TrintedRill()
    {
        Nodes = new List<DrawableLocationNode>()
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
