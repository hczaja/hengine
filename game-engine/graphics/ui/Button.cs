using game_engine.events;
using game_engine.events.input;
using game_engine.system;
using SFML.Graphics;
using SFML.System;

namespace game_engine.graphics.ui;

public class Button :
    RectangleShape,
    IEventHandler<MouseEvent>
{
    private Action OnClick { get; }
    private FloatRect Boundaries { get; }

    public Button(Vector2f size, Vector2f position, Texture texture, Action onClick)
    {
        Size = size;
        Position = position;
        Texture = texture;
        OnClick = onClick;
        Boundaries = GetGlobalBounds();
    }

    public void Handle(MouseEvent @event)
    {
        if (Boundaries.IsMouseEventRaisedIn(@event) && @event.Type == MouseEventType.Pressed)
        {
            OnClick();
        }
    }
}
