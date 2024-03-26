using game.assets;
using game.graphics.ui.panels;
using game_engine.events;
using game_engine.events.input;
using game_engine.graphics;
using SFML.Graphics;
using SFML.System;

namespace game.locations;

class LocationNode : IDrawable, IEventHandler<MouseEvent>
{
    public string Name { get; }
    public float X { get; }
    public float Y { get; }

    CircleShape CircleShape { get; }
    RectangleShape RectangleShape { get; }

    public LocationNode(string name, float x, float y)
    {
        Name = name;
        X = x;
        Y = y;

        CircleShape = new CircleShape(24f);

        var parentPosition = LocationPanel.GetInitialPosition();
        CircleShape.Position = parentPosition + new Vector2f(x, y);
        CircleShape.FillColor = Palette.Instance.C02_DirtyRed;
        CircleShape.OutlineColor = Color.Black;
        CircleShape.OutlineThickness = 1;
    }

    public void Draw(RenderTarget render)
    {
        render.Draw(CircleShape);
    }

    public void Handle(MouseEvent @event)
    {
        if (@event.Type != MouseEventType.Pressed)
            return;


    }
}