using game_engine.events.input;
using SFML.Graphics;

namespace game_graphics.graphics.ui.notifications;

class NotificationService : INotificationService
{
    private Stack<INotification> _notifications;

    public NotificationService()
    {
        _notifications = new Stack<INotification>();
    }

    public void Add(INotification notification)
    {
        _notifications.Push(notification);
    }

    public void DrawBy(RenderTarget render)
    {
        var latest = GetLatest();
        if (latest is not null)
        {
            latest.DrawBy(render);
        }
    }

    public void Handle(MouseEvent @event)
    {
        var latest = GetLatest();
        if (latest is null)
            return;

        latest.Handle(@event);
    }

    private INotification GetLatest()
    {
        if (_notifications.TryPeek(out var notification))
            return notification;

        return null;
    }
}
