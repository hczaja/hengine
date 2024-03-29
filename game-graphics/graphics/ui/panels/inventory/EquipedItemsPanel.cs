using game_contracts.assets;
using game_contracts.assets.textures;
using game_contracts.inventory;
using game_engine.events;
using game_engine.events.input;
using game_engine.settings;
using game_graphics.events;
using game_graphics.graphics.ui.custom;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace game_graphics.graphics.ui.panels.inventory;

class EquipedItemsPanel : Panel
{
    private static readonly float _panelWidthRatio = 0.36f;
    private static readonly float _panelWidth = InventoryPanel.GetInitialSize().X * _panelWidthRatio;

    private static readonly float _panelHeightRatio = 0.66f;
    private static readonly float _panelHeight = InventoryPanel.GetInitialSize().Y * _panelHeightRatio;

    private readonly IInventory _inventory;
    private readonly IEventHandler<ChangeActiveInventoryItemEvent> _parent;

    private IEnumerable<InventoryItemBlock> Equiped { get; }
    public InventoryItemBlock Pointer { get; private set; }

    public EquipedItemsPanel(IInventory inventory, IEventHandler<ChangeActiveInventoryItemEvent> handler)
        : base(GetInitialPosition(), GetInitialSize())
    {
        _inventory = inventory;
        _parent = handler;

        FillColor = Palette.Instance.C07_PaleGreen;
        OutlineColor = Color.White;

        Equiped = GetBlocks(inventory);
        Pointer = null;
    }

    private IEnumerable<InventoryItemBlock> GetBlocks(IInventory inventory)
    {
        var result = new List<InventoryItemBlock>();

        if (inventory.Armour is not null)
        {
            var armourBlock = new InventoryItemBlock(
                new Vector2f(BackpackPanel._itemBlockWidth, BackpackPanel._itemBlockHeight),
                Position,
                TextureStorage.Instance.NoItemTexture.Value);

            result.Add(armourBlock);
        }

        if (inventory.Weapon is not null)
        {
            var weaponBlock = new InventoryItemBlock(
                new Vector2f(BackpackPanel._itemBlockWidth, BackpackPanel._itemBlockHeight),
                Position + new Vector2f(0f, BackpackPanel._itemBlockHeight),
                TextureStorage.Instance.NoItemTexture.Value);

            result.Add(weaponBlock);
        }

        if (inventory.Boots is not null)
        {
            var bootsBlock = new InventoryItemBlock(
                new Vector2f(BackpackPanel._itemBlockWidth, BackpackPanel._itemBlockHeight),
                Position + new Vector2f(0f, 2 * BackpackPanel._itemBlockHeight),
                TextureStorage.Instance.NoItemTexture.Value);

            result.Add(bootsBlock);
        }

        return result;
    }

    internal static Vector2f GetInitialPosition()
    {
        var parent = InventoryPanel.GetInitialPosition();

        return parent + new Vector2f(
            HEngineSettings.Instance.SmallOffsetX,
            HEngineSettings.Instance.SmallOffsetY);
    }

    internal static Vector2f GetInitialSize()
        => new Vector2f(_panelWidth, _panelHeight);

    public override void Handle(KeyboardEvent @event)
    {
        if (Equiped.Count() == 0)
        {
            Pointer = null;
            return;
        }

        if (@event.Key == Keyboard.Key.Up)
        {
            if (Pointer is null)
            {
                Pointer = Equiped.First();
            }
            else
            {
                int index = GetIndexOfPointer();
                var prev = Equiped.ElementAtOrDefault(index - 1);

                if (prev is not null)
                    Pointer = prev;
            }
        }
        else if (@event.Key == Keyboard.Key.Down)
        {
            if (Pointer is null)
            {
                Pointer = Equiped.First();
            }
            else
            {
                int index = GetIndexOfPointer();
                var nextItem = Equiped.ElementAtOrDefault(index + 1);

                if (nextItem is not null)
                    Pointer = nextItem;
            }
        }

        _parent.Handle(new ChangeActiveInventoryItemEvent(Pointer));
    }

    private int GetIndexOfPointer()
    {
        int index = 0;
        foreach (var item in Equiped)
        {
            if (item == Pointer)
            {
                break;
            }

            index++;
        }

        return index;
    }

    public override void Draw(RenderTarget render)
    {
        render.Draw(this);
        foreach (var item in Equiped)
            item.Draw(render);
    }
}
