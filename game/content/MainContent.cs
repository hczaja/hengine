using game.character;
using game.content.world;
using game.locations;
using game_engine.content;
using game_engine.events.input;
using game_engine.events.system;
using game_engine.logger;
using SFML.Graphics;

namespace game.content;

class MainContent : IContent
{
    private readonly ILogger _logger;

    private UserInterface UI { get; }
    private Composition Composition { get; }

    public MainContent(ILogger logger)
    {
        var mainCharacter = new MainCharacter();
        var locationManager = new LocationManager();

        UI = new UserInterface(this, logger, mainCharacter);
        Composition = new Composition(logger, mainCharacter, locationManager);
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
