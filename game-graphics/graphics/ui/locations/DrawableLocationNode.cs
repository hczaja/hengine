using game_contracts.assets;
using game_contracts.assets.fonts;
using game_contracts.locations;
using game_engine.events;
using game_engine.events.input;
using game_engine.graphics;
using game_engine.system;
using game_graphics.graphics.ui.notifications;
using game_graphics.graphics.ui.panels;
using game_graphics.graphics.ui.popups;
using SFML.Graphics;
using SFML.System;

namespace game_graphics.graphics.ui.locations;

class DrawableLocationNode : IDrawable, IEventHandler<MouseEvent>
{
    private readonly IPopupService _popupService;
    private readonly INotificationService _notificationService;

    private static float _circleRadius = 24f;

    CircleShape Circle { get; }
    Text Name { get; }

    public DrawableLocationNode(IPopupService popupService, INotificationService notificationService, LocationNode node)
    {
        _popupService = popupService;
        _notificationService = notificationService;

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

        Name.Position = Circle.GetCenterPosition()
            - GetCircleCenterOffsetX()
            - GetCircleCenterOffsetY();
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
        {
            _popupService.RemoveLatest();
            return;
        }

        _popupService.Add(
            new Popup(
                Name.DisplayedString,
                Circle.GetCenterPosition()
                    + GetCircleCenterOffsetY()
            ));

        //_notificationService.Add(
        //    new ConfirmationNotification());
    }

    private Vector2f GetCircleCenterOffsetX()
    {
        var size = Name.GetLocalBounds();
        return new Vector2f(size.Width / 2f, 0f);
    }

    private Vector2f GetCircleCenterOffsetY()
    {
        var size = Name.GetLocalBounds();
        return new Vector2f(0f, Circle.Radius + 2f * size.Height);
    }
}
