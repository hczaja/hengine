using game.graphics.ui.panels;
using game_contracts.character;
using game_contracts.logger;
using game_engine.content;
using game_engine.events;
using game_engine.events.input;
using game_engine.events.system;
using game_engine.graphics;
using game_graphics.graphics.ui;
using game_graphics.graphics.ui.panels;
using SFML.Graphics;

namespace game_graphics.content.world;

internal class UserInterface :
    IDrawable,
    IEventHandler<MouseEvent>,
    IEventHandler<KeyboardEvent>,
    IEventHandler<ChangeContextEvent>
{
    private readonly IContent _main;
    private readonly ILogger _logger;

    private readonly ICharacter _character;

    Panel CharacterInfoPanel { get; }
    Panel CharacterActionsPanel { get; }
    Panel ConsolePanel { get; }
    Panel GameActionsPanel { get; }

    public UserInterface(IContent main, ILogger logger, ICharacter character)
    {
        _main = main;
        _logger = logger;

        _character = character;

        CharacterInfoPanel = new CharacterInfoPanel(character);
        CharacterActionsPanel = new CharacterActionsPanel(main, logger);
        ConsolePanel = new ConsolePanel(logger);
        GameActionsPanel = new GameActionsPanel();
    }

    public void DrawBy(RenderTarget render)
    {
        CharacterInfoPanel.DrawBy(render);
        //CharacterActionsPanel.Draw(render);
        //ConsolePanel.Draw(render);
        //GameActionsPanel.Draw(render);
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
