using game_contracts.locations;
using game_engine.events;
using game_engine.events.input;
using game_engine.graphics;
using game_graphics.graphics.ui.panels;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace game_graphics.graphics.ui.locations;

class DrawableLocation : IDrawable, IEventHandler<MouseEvent>
{
    private readonly RectangleShape _background;
    
    private readonly IEnumerable<DrawableLocationNode> _nodes;

    public DrawableLocation(IPopupService popupService, INotificationService notificationService, ILocation location)
    {
        _background = new RectangleShape(LocationPanel.GetInitialSize());
        _background.Position = LocationPanel.GetInitialPosition();
        _background.Texture = new Texture($"assets/locations/{location.Name}.png");

        _nodes = new List<DrawableLocationNode>(
            location.Nodes.Select(node => new DrawableLocationNode(popupService, notificationService, node)));
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
        if (@event.Button == Mouse.Button.Right 
            && @event.Type == MouseEventType.Pressed)
        {
            SaveCursorPosition(@event.X, @event.Y);
            return;
        }

        if (@event.Button == Mouse.Button.Right
            && @event.Type == MouseEventType.Released)
        {
            SwipeMap(@event.X, @event.Y);
            return;
        }

        foreach (var node in _nodes)
        {
            node.Handle(@event);
        }
    }

    private Vector2f CursorPosition { get; set; }
    private void SaveCursorPosition(float x, float y)
        => CursorPosition = new Vector2f(x, y);

    private void SwipeMap(float x, float y)
    {
        var newCursorPosition = new Vector2f(x, y);
        var vector = newCursorPosition - CursorPosition;

        _background.Position += -vector;
        foreach (var node in _nodes)
        {
            node.SwipeNode(-vector);
        }
    }
}
