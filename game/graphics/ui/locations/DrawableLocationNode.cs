using game.assets;
using game.assets.fonts;
using game.graphics.ui.panels;
using game.locations;
using game_engine.events;
using game_engine.events.input;
using game_engine.graphics;
using game_engine.system;
using SFML.Graphics;
using SFML.System;

namespace game.graphics.ui.locations;

class DrawableLocationNode : IDrawable, IEventHandler<MouseEvent>
{
    private readonly LocationNode _node;

    private static float _circleRadius = 24f;

    CircleShape Circle { get; }
    Text Name { get; }

    public DrawableLocationNode(LocationNode node)
    {
        _node = node;

        var parentPosition = LocationPanel.GetInitialPosition();

        Circle = new CircleShape(_circleRadius);
        Circle.Position = parentPosition + new Vector2f(node.X, node.Y);
        Circle.FillColor = Palette.Instance.C02_DirtyRed;
        Circle.OutlineColor = Color.Black;
        Circle.OutlineThickness = 1;

        Name = new Text(
            node.Name, 
            RetroGamingFont.Instance.Font, 
            RetroGamingFont.Instance.GetLocationNameFontSize());
        
        var size = Name.GetLocalBounds();
        Name.Position = Circle.GetCenterPosition()
            - new Vector2f(size.Width / 2f, Circle.Radius + 2f * size.Height);
    }

    public void Draw(RenderTarget render)
    {
        render.Draw(Circle);
        render.Draw(Name);
    }

    public void Handle(MouseEvent @event)
    {
        if (@event.Type != MouseEventType.Pressed)
            return;

        var center = Circle.GetCenterPosition();
        if (!center.IsMouseEventRaisedInCircle(Circle.Radius, @event))
            return;
    }
}
