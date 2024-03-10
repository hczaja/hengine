using game_engine.events.input;
using game_engine.events;
using game_engine.graphics;
using SFML.Graphics;
using game_engine.graphics.ui;
using game.graphics.ui.panels;
using game_engine.events.system;
using game.context;
using game_engine.logger;
using game.character;

namespace game.content.world;

internal class Composition :
    IDrawable,
    IEventHandler<MouseEvent>,
    IEventHandler<KeyboardEvent>,
    IEventHandler<ChangeContextEvent>
{
    Stack<Panel> Panels { get; }
    Panel Top => Panels.Peek();

    private readonly ILogger _logger;
    private readonly ICharacter _character;

    public Composition(ILogger logger, ICharacter mainCharacter)
    {
        _logger = logger;
        _character = mainCharacter;

        Panels = new Stack<Panel>(); 
        Panels.Push(new LocationPanel());
    }

    public void Draw(RenderTarget render)
    {
        Top.Draw(render);
    }

    public void Update()
    {

    }

    public void Handle(MouseEvent @event)
    {

    }

    public void Handle(KeyboardEvent @event)
    {

    }

    public void Handle(ChangeContextEvent @event)
    {
        if (@event is null)
            return;

        var context = @event.Context;
        Panels.TryPop(out Panel current);

        if (context is DiaryContext && current is not DiaryPanel)
        {
            Panels.Push(new DiaryPanel());
            return;
        }

        if (context is InventoryContext && current is not InventoryPanel)
        {
            Panels.Push(new InventoryPanel(_character.Inventory));
            return;
        }

        if (context is LocationContext && current is not LocationPanel)
        {
            Panels.Push(new LocationPanel());
            return;
        }

        Panels.Push(current);
    }
}
