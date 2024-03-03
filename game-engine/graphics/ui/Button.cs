using SFML.Graphics;

namespace game_engine.graphics.ui;

public class Button : IDrawable
{
    public RectangleShape Shape { get; }

    public Button(RectangleShape shape) => Shape = shape;

    public void Draw(RenderTarget render)
    {
        render.Draw(Shape);
    }
}
