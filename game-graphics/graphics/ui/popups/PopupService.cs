﻿using game_engine.events.input;
using SFML.Graphics;

namespace game_graphics.graphics.ui.popups;

class PopupService : IPopupService
{
    private Stack<IPopup> _popups;

    public PopupService()
    {
        _popups = new Stack<IPopup>();
    }

    public void Add(IPopup popup)
    {
        if (!_popups.Any(p => p.ParentId == popup.ParentId))
        {
            RemoveLatest();
            _popups.Push(popup);
        }
    }

    public void RemoveLatest()
    {
        _popups.TryPop(out var _);
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

    private IPopup GetLatest()
    {
        if (_popups.TryPeek(out var popup))
            return popup;

        return null;
    }
}
