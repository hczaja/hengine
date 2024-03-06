using game.context;
using game.graphics.ui.panels;
using game_engine.content;
using game_engine.events;
using game_engine.events.input;
using game_engine.events.system;
using game_engine.graphics;
using game_engine.graphics.ui;
using SFML.Graphics;

namespace game.content.world;

internal class UserInterface :
    IDrawable,
    IEventHandler<MouseEvent>,
    IEventHandler<KeyboardEvent>,
    IEventHandler<ChangeContextEvent>
{
    private readonly IContent _main;

    Panel CharacterInfoPanel { get; }
    Panel CharacterActionsPanel { get; }
    Panel ConsolePanel { get; }
    Panel GameActionsPanel { get; }

    public UserInterface(IContent main)
    {
        _main = main;

        CharacterInfoPanel = new CharacterInfoPanel();
        CharacterActionsPanel = new CharacterActionsPanel(main);
        ConsolePanel = new ConsolePanel();
        GameActionsPanel = new GameActionsPanel();
    }

    public void Draw(RenderTarget render)
    {
        CharacterInfoPanel.Draw(render);
        CharacterActionsPanel.Draw(render);
        ConsolePanel.Draw(render);
        GameActionsPanel.Draw(render);
    }

    public void Handle(MouseEvent @event)
    {
        CharacterActionsPanel.Handle(@event);
        GameActionsPanel.Handle(@event);
    }

    public void Handle(KeyboardEvent @event)
    {

    }

    public void Update()
    {

    }

    public void Handle(ChangeContextEvent @event)
    {
        CharacterActionsPanel.Handle(@event);
    }
}
