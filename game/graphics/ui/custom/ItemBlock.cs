using game_engine.graphics;
using SFML.Graphics;
using SFML.System;

namespace game.graphics.ui.custom;

class ItemBlock : IDrawable
{
    public Vector2f Postion { get; }
    public Vector2f Size { get; }
    private RectangleShape Icon { get; set; }

    public ItemBlock(Vector2f size, Vector2f position, Texture icon)
    {
        Size = size;
        Postion = position;

        Icon = new RectangleShape(new Vector2f(size.X, size.Y))
        {
            Position = position,
            Texture = icon,
        };
    }

    public void Draw(RenderTarget render)
    {
        render.Draw(Icon);
    }
}
