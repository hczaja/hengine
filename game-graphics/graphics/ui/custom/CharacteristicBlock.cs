using game_contracts.assets;
using game_contracts.assets.fonts;
using game_engine.graphics;
using SFML.Graphics;
using SFML.System;

namespace game_graphics.graphics.ui.custom;

class CharacteristicBlock : IDrawable
{
    public Vector2f Postion { get; }
    public Vector2f Size { get; }
    private RectangleShape Icon { get; set; }
    private Text Text { get; set; }
    public int Value { get; private set; }

    public CharacteristicBlock(Vector2f size, Vector2f position, Texture icon, int startValue)
    {
        Size = size;
        Postion = position;

        Icon = new RectangleShape(new Vector2f(size.X / 2f, size.Y))
        {
            Position = position,
            Texture = icon
        };

        Value = startValue;

        Text = new Text()
        {
            CharacterSize = RetroGamingFont.Instance.GetConsoleFontSize(),
            Font = RetroGamingFont.Instance.Font,
            FillColor = Palette.Instance.C01_DarkBrown,
            DisplayedString = startValue.ToString("00"),
            Position = Icon.Position + new Vector2f(Icon.Size.X, 0f),
            OutlineThickness = 1f,
            OutlineColor = Color.White,
        };
    }

    public void Draw(RenderTarget render)
    {
        render.Draw(Icon);
        render.Draw(Text);
    }
}
