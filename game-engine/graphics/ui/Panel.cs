using SFML.Graphics;
using SFML.System;

namespace game_engine.graphics.ui;

public abstract class Panel : RectangleShape, IDrawable
{
    public Panel(Vector2f position, Vector2f size) : base(size)
    {
        Position = position;
        FillColor = Color.White;
    }

    public virtual void Draw(RenderTarget render) => render.Draw(this);
}
