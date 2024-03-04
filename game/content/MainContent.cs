using game.content.world;
using game_engine.content;
using game_engine.events.input;
using game_engine.events.system;
using SFML.Graphics;

namespace game.content;

class MainContent : IContent
{
    private UserInterface UI { get; }
    private Location Location { get; }

    public MainContent()
    {
        UI = new UserInterface();
        Location = new Location();
    }

    public void Draw(RenderTarget render)
    {
        Location.Draw(render);
        UI.Draw(render);
    }

    public void Handle(MouseEvent @event)
    {
        UI.Handle(@event);
        Location.Handle(@event);
    }

    public void Handle(KeyboardEvent @event)
    {
        UI.Handle(@event);
        Location.Handle(@event);
    }

    public void Update()
    {
        Location.Update();
        UI.Update();
    }

    public void Handle(ChangeContextEvent @event)
    {

    }
}
