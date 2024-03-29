using game_engine.events.input;
using game_engine.events;
using SFML.Graphics;
using SFML.System;
using game_engine.graphics;

namespace game_graphics.graphics.ui;

public abstract class Notification : RectangleShape, IDrawable, IEventHandler<MouseEvent>
{
    public Notification(Vector2f position, Vector2f size) : base(size)
    {
        Position = position;
        FillColor = Color.Yellow;
    }

    public virtual void Draw(RenderTarget render) => throw new NotImplementedException();
    public virtual void Handle(MouseEvent @event) => throw new NotImplementedException();
}
