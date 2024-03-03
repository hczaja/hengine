using game.content.world;
using game_engine.content;
using game_engine.events.input;
using SFML.Graphics;

namespace game.content;

class MainContent : IContent
{
    private WorldUserInterface UI { get; }
    private World World { get; }

    public MainContent()
    {
        UI = new WorldUserInterface();
        World = new World();
    }

    public void Draw(RenderTarget render)
    {
        World.Draw(render);
        UI.Draw(render);
    }

    public void Handle(MouseEvent @event)
    {
        UI.Handle(@event);
        World.Handle(@event);
    }

    public void Handle(KeyboardEvent @event)
    {
        UI.Handle(@event);
        World.Handle(@event);
    }

    public void Update()
    {
        World.Update();
        UI.Update();
    }
}
