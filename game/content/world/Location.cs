using game_engine.events.input;
using game_engine.events;
using game_engine.graphics;
using SFML.Graphics;
using game_engine.context;
using game_engine.graphics.ui;
using game.graphics.ui.panels;

namespace game.content.world;

internal class Location :
    IDrawable,
    IEventHandler<MouseEvent>,
    IEventHandler<KeyboardEvent>
{
    Panel LocationPanel { get; }

    public Location()
    {
        LocationPanel = new LocationPanel();
    }

    public void Draw(RenderTarget render)
    {
        LocationPanel.Draw(render);
    }

    public void Handle(MouseEvent @event)
    {

    }

    public void Handle(KeyboardEvent @event)
    {

    }

    public void Update()
    {

    }

    public IContext GetContext()
    {
        throw new NotImplementedException();
    }
}
