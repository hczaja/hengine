using game_engine.events;
using game_engine.events.input;
using game_engine.graphics;
using rts_game.events;
using SFML.Graphics;
using SFML.System;

namespace rts_game;

public class Selector : IDrawable, IEventHandler<MouseEvent>
{
    private readonly RectangleShape _rect;
    private readonly GameStorage _manager;

    private readonly ISelectionHandler _selectionHandler;

    private bool _drawSelectionRectangle;
    private bool _checkSelectionRectangle;

    public Selector(ISelectionHandler selectionHandler, GameStorage manager)
    {
        _selectionHandler = selectionHandler;
        _manager = manager; 

        _rect = new RectangleShape();

        _rect.FillColor = Color.Transparent;
        _rect.OutlineColor = Color.White;
        _rect.OutlineThickness = 1;
    }

    public void DrawBy(RenderTarget render)
    {
        if (_drawSelectionRectangle)
        {
            render.Draw(_rect);
        }
    }

    public void Reposition(Vector2f position)
    {
        _rect.Position = position;
    }

    public void Resize(Vector2f size)
    {
        _rect.Size = size;
    }

    public void Handle(MouseEvent @event)
    {
        switch (@event.Type)
        {
            case MouseEventType.Pressed:
                _rect.Position = new Vector2f(@event.X, @event.Y);
                _drawSelectionRectangle = true;
                break;
            case MouseEventType.Released:
                _drawSelectionRectangle = false;
                _checkSelectionRectangle = true;
                break;
        }
    }

    public void Update(Vector2f mousePosition)
    {
        if (_drawSelectionRectangle)
        {
            float width = _rect.Position.X - mousePosition.X;
            float height = _rect.Position.Y - mousePosition.Y;

            _rect.Size = new Vector2f(-width, -height);
        }

        if (_checkSelectionRectangle)
        {
            var selectedObjects = 
                _manager.GetGameObjects()
                        .Where(e => 
                            e.GetPositionRect()
                             .Intersects(_rect.GetGlobalBounds()));

            _selectionHandler.Handle(
                new SelectedUnitsEvent(selectedObjects));            

            _checkSelectionRectangle = false;
        }
    }
}