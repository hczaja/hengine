using game_engine.events.input;
using game_engine.events;
using SFML.Graphics;
using SFML.System;

namespace game_engine.graphics.ui;

public abstract class Panel : RectangleShape, IDrawable, IEventHandler<MouseEvent>
{
    public Panel(Vector2f position, Vector2f size) : base(size)
    {
        Position = position;
        FillColor = Color.White;
    }

    public virtual void Draw(RenderTarget render) => throw new NotImplementedException();
    public virtual void Handle(MouseEvent @event) => throw new NotImplementedException();
}
