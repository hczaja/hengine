using game.content.world;
using game_engine.content;
using game_engine.events.input;
using game_engine.events.system;
using SFML.Graphics;

namespace game.content;

class MainContent : IContent
{
    private UserInterface UI { get; }
    private Composition Composition { get; }

    public MainContent()
    {
        UI = new UserInterface(this);
        Composition = new Composition();
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
