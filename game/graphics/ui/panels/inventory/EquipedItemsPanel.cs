using game.assets;
using game.assets.textures;
using game.character.inventory;
using game.graphics.ui.custom;
using game_engine.events;
using game_engine.events.input;
using game_engine.graphics.ui;
using game_engine.settings;
using SFML.Graphics;
using SFML.System;

namespace game.graphics.ui.panels.inventory;

class EquipedItemsPanel : Panel
{
    private static readonly float _panelWidthRatio = 0.36f;
    private static readonly float _panelWidth = InventoryPanel.GetInitialSize().X * _panelWidthRatio;

    private static readonly float _panelHeightRatio = 0.66f;
    private static readonly float _panelHeight = InventoryPanel.GetInitialSize().Y * _panelHeightRatio;

    private readonly IEventHandler<ChangeActiveInventoryItemEvent> _parent;

    private ItemBlock ArmourBlock { get; }
    private ItemBlock WeaponBlock { get; }
    private ItemBlock BootsBlock { get; }

    ItemBlock ActiveItem { get; set; }

    public EquipedItemsPanel(IInventory inventory, IEventHandler<ChangeActiveInventoryItemEvent> handler)
        : base(GetInitialPosition(), GetInitialSize())
    {
        _parent = handler;

        FillColor = Palette.Instance.C07_PaleGreen;

        ArmourBlock = new ItemBlock(
            new Vector2f(BackpackPanel._itemBlockWidth, BackpackPanel._itemBlockHeight),
            Position,
            TextureStorage.Instance.NoItemTexture.Value);

        WeaponBlock = new ItemBlock(
            new Vector2f(BackpackPanel._itemBlockWidth, BackpackPanel._itemBlockHeight),
            Position + new Vector2f(0f, BackpackPanel._itemBlockHeight),
            TextureStorage.Instance.NoItemTexture.Value);

        BootsBlock = new ItemBlock(
            new Vector2f(BackpackPanel._itemBlockWidth, BackpackPanel._itemBlockHeight),
            Position + new Vector2f(0f, 2 * BackpackPanel._itemBlockHeight),
            TextureStorage.Instance.NoItemTexture.Value);

        ActiveItem = ArmourBlock;
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

    }

    public override void Draw(RenderTarget render)
    {
        render.Draw(this);
        ArmourBlock.Draw(render);
        WeaponBlock.Draw(render);
        BootsBlock.Draw(render);
    }

    internal ItemBlock GetActiveItem() => ActiveItem;
}
