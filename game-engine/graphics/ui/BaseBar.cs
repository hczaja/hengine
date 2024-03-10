using SFML.Graphics;
using SFML.System;

namespace game_engine.graphics.ui;

public abstract class BaseBar : RectangleShape, IDrawable
{
    private float MaxValue { get; set; }
    private float CurrentValue { get; set; }
    private float MaxLength { get; set; }
    protected abstract Text Text { get; set; }

    public BaseBar(Vector2f position, float length, float height, Color color, float startValue, float maxValue) 
        : base(new Vector2f(length * (startValue / maxValue), height))
    {
        Position = position;
        FillColor = color;

        MaxLength = length;
        MaxValue = maxValue;
        CurrentValue = startValue;
    }

    public void Draw(RenderTarget render)
    {
        render.Draw(this);
        render.Draw(Text);
    }
}
