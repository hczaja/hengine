using game_contracts.inventory;
using game_contracts.logger;
using game_engine.events;
using game_engine.events.input;
using game_engine.settings;
using game_graphics.events;
using game_graphics.graphics.ui.custom;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace game_graphics.graphics.ui.panels.inventory;


public class InventoryPanel : Panel, IEventHandler<ChangeActiveInventoryItemEvent>
{
    private static readonly float _panelWidthRatio = 0.74f;
    private static readonly float _panelWidth = HEngineSettings.Instance.WindowWidth * _panelWidthRatio;

    private static readonly float _panelHeightRatio = 0.96f;
    private static readonly float _panelHeight = HEngineSettings.Instance.WindowHeight * _panelHeightRatio;

    private readonly IInventory _inventory;

    Panel ActivePanel { get; set; }
    InventoryItemBlock ActiveItem { get; set; }

    private BackpackPanel Backpack { get; }
    private EquipedItemsPanel EquipedItems { get; }

    public InventoryPanel(ILogger logger, IInventory inventory)
        : base(GetInitialPosition(), GetInitialSize())
    {
        _inventory = inventory;

        Backpack = new BackpackPanel(inventory, this);
        EquipedItems = new EquipedItemsPanel(inventory, this);

        FillColor = Color.Black;

        ActivePanel = EquipedItems;
        ActivePanel.OutlineThickness = 4f;

        ActiveItem = EquipedItems.Pointer;
    }

    public override void Handle(MouseEvent @event) { }

    internal static Vector2f GetInitialPosition()
        => new Vector2f(
            HEngineSettings.Instance.SmallOffsetX,
            HEngineSettings.Instance.SmallOffsetY);

    internal static Vector2f GetInitialSize()
        => new Vector2f(_panelWidth, _panelHeight);

    public override void Handle(KeyboardEvent @event)
    {
        if (@event.Type == KeyboardEventType.Released)
            return;

        if (@event.Key == Keyboard.Key.Tab)
        {
            ActivePanel.OutlineThickness = 0f;
            ActiveItem?.TurnActive(false);

            if (Backpack == ActivePanel)
            {
                ActivePanel = EquipedItems;
                ActiveItem = EquipedItems.Pointer;

            }
            else
            {
                ActivePanel = Backpack;
                ActiveItem = Backpack.Pointer;
            }

            ActiveItem?.TurnActive(true);

            ActivePanel.OutlineThickness = 4f;
        }
        else if (@event.Key == Keyboard.Key.Enter)
        {
            
        }
        else
        {
            if (Backpack == ActivePanel)
            {
                Backpack.Handle(@event);
            }
            else
            {
                EquipedItems.Handle(@event);
            }
        }
    }

    public override void Draw(RenderTarget render)
    {
        render.Draw(this);

        EquipedItems.Draw(render);
        Backpack.Draw(render);

        if (ActivePanel is not null)
        {
            
        }

        if (ActiveItem is not null)
        {
            ActiveItem.Draw(render);
        }
    }

    public void Handle(ChangeActiveInventoryItemEvent @event)
    {
        if (Backpack == ActivePanel)
        {
            ActiveItem?.TurnActive(false);
            ActiveItem = Backpack.Pointer;
            ActiveItem?.TurnActive(true);
        }
        else
        {
            ActiveItem?.TurnActive(false);
            ActiveItem = EquipedItems.Pointer;
            ActiveItem?.TurnActive(true);
        }
    }
}
