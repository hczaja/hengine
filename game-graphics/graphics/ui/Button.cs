using game_engine.events;
using game_engine.events.input;
using game_engine.system;
using SFML.Graphics;
using SFML.System;

namespace game_graphics.graphics.ui;

public class Button :
    RectangleShape,
    IEventHandler<MouseEvent>
{
    private Action Callback { get; }
    private FloatRect Boundaries { get; }

    public Button(Vector2f size, Vector2f position, Texture texture, Action callback)
    {
        Size = size;
        Position = position;
        Texture = texture;
        Callback = callback;
        Boundaries = GetGlobalBounds();
    }

    public void Handle(MouseEvent @event)
    {
        if (Boundaries.IsMouseEventRaisedInRectangle(@event) && @event.Type == MouseEventType.Pressed)
        {
            Callback();
        }
    }
}
