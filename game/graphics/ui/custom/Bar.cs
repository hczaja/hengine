using game.assets.fonts;
using game.assets;
using game_engine.graphics.ui;
using SFML.Graphics;
using SFML.System;

namespace game.graphics.ui.custom;

internal class Bar : BaseBar
{
    public Bar(Vector2f position, float length, float height, Color color, float startValue, float maxValue) 
        : base(position, length, height, color, startValue, maxValue)
    {
        double percent = (startValue / maxValue) * 100;
        Text = new Text()
        {
            CharacterSize = RetroGamingFont.Instance.GetConsoleFontSize(),
            Font = RetroGamingFont.Instance.Font,
            FillColor = Palette.Instance.C01_DarkBrown,
            DisplayedString = $"{percent.ToString("00")}%",
            Position = Position + new Vector2f(length/2f, 0f),
            OutlineThickness = 1f,
            OutlineColor = Color.White,
        };
    }

    protected override Text Text { get; set; }
}
