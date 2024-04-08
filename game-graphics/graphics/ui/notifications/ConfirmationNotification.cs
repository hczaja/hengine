using game_engine.events.input;
using game_graphics.graphics.ui.panels;
using SFML.Graphics;
using SFML.System;

namespace game_graphics.graphics.ui.notifications;

class ConfirmationNotification : RectangleShape, INotification
{
    private static readonly Vector2f _panelSize = LocationPanel.GetInitialSize();
    private static readonly Vector2f _panelPosition = LocationPanel.GetInitialPosition();

    private static readonly Vector2f _notificationSize = new Vector2f(0.30f * _panelSize.X, 0.20f * _panelSize.Y);

    public ConfirmationNotification()
        : base(_notificationSize)
    {
        Position = _panelPosition + (_panelSize / 2) - (_notificationSize / 2);

        FillColor = Color.White;
    }

    public void DrawBy(RenderTarget render)
    {
        render.Draw(this);
    }

    public void Handle(MouseEvent @event)
    {

    }
}
