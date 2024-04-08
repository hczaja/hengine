using game_engine.events.input;
using game_engine.events;
using game_engine.graphics;
using SFML.Graphics;
using game_engine.events.system;
using game_contracts.character;
using game_contracts.locations;
using game_contracts.logger;
using game_graphics.context;
using game_graphics.graphics.ui.panels.diary;
using game_graphics.graphics.ui.panels;
using game_graphics.graphics.ui;
using game_graphics.graphics.ui.panels.inventory;

namespace game_graphics.content.world;

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

    public Composition(ILogger logger, ICharacter mainCharacter, ILocationManager locationManager)
    {
        _logger = logger;
        _character = mainCharacter;

        Panels = new Stack<Panel>();

        Panels.Push(new InventoryPanel(_logger, _character.Inventory));
        Panels.Push(new DiaryPanel(_logger, _character.Diary));
        Panels.Push(new LocationPanel(_logger, locationManager));
    }

    public void DrawBy(RenderTarget render)
    {
        Top.DrawBy(render);
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
        {
            MoveOnTop<DiaryPanel>();
            return;
        }

        if (context is InventoryContext)
        {
            MoveOnTop<InventoryPanel>();
            return;
        }

        if (context is LocationContext)
        {
            MoveOnTop<LocationPanel>();
            return;
        }
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
