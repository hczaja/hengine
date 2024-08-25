using game_engine.content;
using game_engine.events.input;
using game_engine.events.system;
using rts_game.events;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Reflection;

namespace rts_game;

public class MainRTSContent : IContent, ISelectionHandler
{
    private readonly GameStorage _storage;
    private readonly GameInterface _interface;
    private readonly Selector _selector;

    private Vector2f MousePosition = new Vector2f(0, 0);

    private IEnumerable<IGameObject> selection = Enumerable.Empty<IGameObject>();

    public MainRTSContent(GameStorage gameStorage)
    {
        _storage = gameStorage;

        _interface = new GameInterface(_storage);
        _selector = new Selector(this, _storage);
    }

    public void DrawBy(RenderTarget render)
    {
        foreach (var gameObject in _storage.GetGameObjects())
        {
            gameObject.DrawBy(render);
        }

        _selector.DrawBy(render);
        _interface.DrawBy(render);
    }

    public void Handle(MouseEvent @event)
    {
        MousePosition.X = @event.X;
        MousePosition.Y = @event.Y;

        if (@event.Button == Mouse.Button.Left)
        {
            _selector.Handle(@event);
        }

        _interface.Handle(@event);
    }

    public void Handle(KeyboardEvent @event)
    {
        _interface.Handle(@event);
    }

    public void Handle(ChangeContextEvent @event)
    {
    }

    public void Handle(SelectedUnitsEvent @event)
    {
        //foreach (var obj in selection)
        //{
        //    obj.Unselect();
        //}

        selection = @event.Objects;
        //foreach (var obj in selection)
        //{
        //    obj.Select();
        //}

        _interface.Handle(@event);
    }

    public void Update()
    {
        foreach (var gameObject in _storage.GetGameObjects())
        {
            gameObject.Update();
        }

        _selector.Update(MousePosition);
    }
}
