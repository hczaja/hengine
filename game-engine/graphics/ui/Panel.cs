using SFML.Graphics;

namespace game_engine.graphics.ui;

public abstract class Panel : RectangleShape, IDrawable
{
    public virtual void Draw(RenderTarget render) => render.Draw(this);
}
