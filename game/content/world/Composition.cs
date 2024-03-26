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
using game.graphics.ui.panels.inventory;
using game.graphics.ui.panels.diary;
using game.locations;

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

    public Composition(ILogger logger, ICharacter mainCharacter, LocationManager locationManager)
    {
        _logger = logger;
        _character = mainCharacter;

        Panels = new Stack<Panel>();

        Panels.Push(new InventoryPanel(_logger, _character.Inventory));
        Panels.Push(new DiaryPanel(_logger, _character.Diary));
        Panels.Push(new LocationPanel(_logger, locationManager));
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
        Top.Handle(@event);
    }

    public void Handle(KeyboardEvent @event)
    {
        Top.Handle(@event);
    }

    public void Handle(ChangeContextEvent @event)
    {
        if (@event is null)
            return;

        var context = @event.Context;

        if (context is DiaryContext)
            MoveOnTop<DiaryPanel>();

        if (context is InventoryContext)
            MoveOnTop<InventoryPanel>();

        if (context is LocationContext)
            MoveOnTop<LocationPanel>();
    }

    private void MoveOnTop<T>() where T : Panel
    {
        var tempPanels = new Stack<Panel>();
        while (Top is not T)
        {
            tempPanels.Push(Panels.Pop());
        }

        var panel = Panels.Pop();
        while (tempPanels.Count > 0)
        {
            Panels.Push(tempPanels.Pop());
        }

        Panels.Push(panel);
    }
}
