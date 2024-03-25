using SFML.Graphics;
using SFML.System;

namespace game.locations.data.chapter_one;

class TrintedRillRegion : ILocation
{
    public string Id => nameof(TrintedRillRegion);

    private readonly RectangleShape _background;

    public IEnumerable<Route> ExternalRoutes { get; }

    public IEnumerable<LocationNode> Nodes { get; }

    public TrintedRillRegion(Vector2f position)
    {
        _background = new RectangleShape(new Vector2f(1421, 1152));
        _background.Position = position;
        _background.Texture = new Texture("assets/locations/TrintedRillRegion.png");

        Nodes = new List<LocationNode>()
        {
            new LocationNode("Lumberjack House", 204, 672),
        };
    }

    public void Draw(RenderTarget render)
    {
        render.Draw(_background);

        foreach (var node in Nodes)
        {
            node.Draw(render);
        }
    }
}
