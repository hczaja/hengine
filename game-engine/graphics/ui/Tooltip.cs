using game_engine.events.input;
using game_engine.events;
using SFML.Graphics;
using SFML.System;

namespace game_engine.graphics.ui;

public abstract class Tooltip : RectangleShape, IDrawable
{
    public Tooltip(Vector2f position, Vector2f size) : base(size)
    {
        Position = position;
        FillColor = Color.Green;
    }

    public virtual void Draw(RenderTarget render) => throw new NotImplementedException();
}
