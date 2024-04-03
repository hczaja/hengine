using game_contracts.locations;
using game_engine.events;
using game_engine.events.input;
using game_engine.graphics;
using game_graphics.graphics.ui.panels;
using SFML.Graphics;
using SFML.System;

namespace game_graphics.graphics.ui.locations;

class DrawableLocation : IDrawable, IEventHandler<MouseEvent>
{
    private readonly RectangleShape _background;
    
    private readonly IEnumerable<DrawableLocationNode> _nodes;

    public DrawableLocation(IPopupService popupService, ILocation location)
    {
        _background = new RectangleShape(new Vector2f(1421, 1152));
        _background.Position = LocationPanel.GetInitialPosition();
        _background.Texture = new Texture($"assets/locations/{location.Name}.png");

        _nodes = new List<DrawableLocationNode>(
            location.Nodes.Select(node => new DrawableLocationNode(popupService, node)));
    }

    public void Draw(RenderTarget render)
    {
        render.Draw(_background);

        foreach (var node in _nodes)
        {
            node.Draw(render);
        }
    }

    public void Handle(MouseEvent @event)
    {
        foreach (var node in _nodes)
        {
            node.Handle(@event);
        }
    }
}
