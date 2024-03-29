using game_contracts.character;
using game_contracts.locations;
using game_contracts.logger;
using game_engine.content;
using game_engine.events.input;
using game_engine.events.system;
using game_graphics.content.world;
using SFML.Graphics;

namespace game_graphics.content;

public class MainContent : IContent
{
    private readonly ILogger _logger;

    private UserInterface UI { get; }
    private Composition Composition { get; }

    public MainContent(ILogger logger, ICharacter character, ILocationManager locationManager)
    {
        UI = new UserInterface(this, logger, character);
        Composition = new Composition(logger, character, locationManager);
    }

    public void Draw(RenderTarget render)
    {
        Composition.Draw(render);
        UI.Draw(render);
    }

    public void Handle(MouseEvent @event)
    {
        UI.Handle(@event);
        Composition.Handle(@event);
    }

    public void Handle(KeyboardEvent @event)
    {
        UI.Handle(@event);
        Composition.Handle(@event);
    }

    public void Update()
    {
        Composition.Update();
        UI.Update();
    }

    public void Handle(ChangeContextEvent @event)
    {
        UI.Handle(@event);
        Composition.Handle(@event);
    }
}
