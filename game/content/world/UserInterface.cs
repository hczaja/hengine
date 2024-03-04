using game.context;
using game.graphics.ui.panels;
using game_engine.events;
using game_engine.events.input;
using game_engine.graphics;
using game_engine.graphics.ui;
using SFML.Graphics;

namespace game.content.world;

internal class UserInterface :
    IDrawable,
    IEventHandler<MouseEvent>,
    IEventHandler<KeyboardEvent>
{
    Panel CharacterInfoPanel { get; }
    Panel CharacterActionsPanel { get; }

    public UserInterface()
    {
        CharacterInfoPanel = new CharacterInfoPanel();
        CharacterActionsPanel = new CharacterActionsPanel(new LocationContext());
    }

    public void Draw(RenderTarget render)
    {
        CharacterInfoPanel.Draw(render);
        CharacterActionsPanel.Draw(render);
    }

    public void Handle(MouseEvent @event)
    {
        CharacterActionsPanel.Handle(@event);
    }

    public void Handle(KeyboardEvent @event)
    {

    }

    public void Update()
    {

    }
}
