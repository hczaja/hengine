using game_engine.graphics;
using SFML.Graphics;
using SFML.System;

namespace game.graphics.ui.custom;

class InventoryItemBlock : IDrawable
{
    public Vector2f Postion { get; }
    public Vector2f Size { get; }
    private RectangleShape Icon { get; set; }

    public InventoryItemBlock(Vector2f size, Vector2f position, Texture icon)
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

    public void TurnActive(bool turn)
    {
        if (turn)
        {
            Icon.OutlineThickness = 4;
            Icon.OutlineColor = Color.White;
        }
        else
        {
            Icon.OutlineThickness = 0;
        }
    }
}
