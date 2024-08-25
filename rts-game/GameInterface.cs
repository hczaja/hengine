using game_engine.events.input;
using game_engine.graphics;
using rts_game.events;
using SFML.Graphics;

namespace rts_game;

public class GameInterface : IDrawable, ISelectionHandler, IUserInputHandler
{
    private readonly GameStorage _storage;

    public GameInterface(GameStorage gameStorage)
    {
        _storage = gameStorage;
    }

    public void DrawBy(RenderTarget render)
    {

    }

    public void Handle(SelectedUnitsEvent @event)
    {

    }

    public void Handle(MouseEvent @event)
    {

    }

    public void Handle(KeyboardEvent @event)
    {

    }
}
