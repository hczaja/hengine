using game_contracts.assets;
using game_engine.events;
using game_engine.events.input;
using game_engine.system;
using game_graphics.graphics.ui.panels;
using SFML.Graphics;
using SFML.System;

namespace game_graphics.graphics.ui.popups;

class Popup : RectangleShape, IPopup
{
    private static readonly float _panelWidth = LocationPanel.GetInitialSize().X;
    private static readonly float _panelHeight = LocationPanel.GetInitialSize().Y;

    private static readonly Vector2f _popupItemSize = new Vector2f(0.05f * _panelWidth, 0.05f * _panelHeight);

    public string ParentId { get; }

    public Popup(string parentId, Vector2f position) : base(GetInitialSize())
    {
        ParentId = parentId;

        Position = position - new Vector2f(Size.X / 2f, Size.Y / 2f);
        
        FillColor = Palette.Instance.C09_PaleYellow;

        OutlineColor = Color.Black;
        OutlineThickness = 2f;
    }


    internal static Vector2f GetInitialSize()
        => new Vector2f(_popupItemSize.X * 2f, _popupItemSize.Y * 1.5f);

    public void DrawBy(RenderTarget render)
    {
        render.Draw(this);
    }

    public void Handle(MouseEvent @event)
    {
        
    }
}

class PopupItem : RectangleShape, IEventHandler<MouseEvent>
{
    private Action Callback { get; }
    private FloatRect Boundaries { get; }


    public PopupItem(Vector2f size, Vector2f position, Texture texture, Action callback)
    {
        Size = size;
        Position = position;
        Texture = texture;
        Callback = callback;
        Boundaries = GetGlobalBounds();
    }

    public void Handle(MouseEvent @event)
    {
        if (Boundaries.IsMouseEventRaisedInRectangle(@event) && @event.Type == MouseEventType.Pressed)
        {
            Callback();
        }
    }
}
