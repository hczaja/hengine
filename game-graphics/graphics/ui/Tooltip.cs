using game_engine.graphics;
using SFML.Graphics;
using SFML.System;

namespace game_graphics.graphics.ui;

public abstract class Tooltip : RectangleShape, IDrawable
{
    public Tooltip(Vector2f position, Vector2f size) : base(size)
    {
        Position = position;
        FillColor = Color.Green;
    }

    public virtual void Draw(RenderTarget render) => throw new NotImplementedException();
}
