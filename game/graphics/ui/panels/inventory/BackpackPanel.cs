using game.assets;
using game.character;
using game.character.inventory;
using game.character.inventory.items;
using game.graphics.ui.custom;
using game_engine.graphics.ui;
using game_engine.settings;
using SFML.Graphics;
using SFML.System;

namespace game.graphics.ui.panels.inventory;

class BackpackPanel : Panel
{
    private static readonly float _panelWidthRatio = 0.54f;
    private static readonly float _panelWidth = InventoryPanel.GetInitialSize().X * _panelWidthRatio;

    private static readonly float _panelHeightRatio = 0.96f;
    private static readonly float _panelHeight = InventoryPanel.GetInitialSize().Y * _panelHeightRatio;

    private static readonly float _itemBlockWidth = (1f / 5f) * _panelWidth;
    private static readonly float _itemBlockHeight = (1f / 5f) * _panelHeight;

    private IEnumerable<ItemBlock> Blocks { get; }

    private int MaxColumns = 5;
    private int MaxRows = 5;

    public BackpackPanel(IInventory inventory)
        : base(GetInitialPosition(), GetInitialSize())
    {
        FillColor = Palette.Instance.C07_PaleGreen;

        Blocks = GetBlocks(inventory.Backpack);
    }

    private IEnumerable<ItemBlock> GetBlocks(IEnumerable<Item> backpack)
    {
        var result = new List<ItemBlock>();

        int column = 0, row = 0;
        foreach (var item in backpack) 
        {
            result.Add(new ItemBlock(
                new Vector2f(_itemBlockWidth, _itemBlockHeight),
                Position + new Vector2f(column * _itemBlockWidth, row * _itemBlockHeight),
                item.Texture));

            column++;
            if (column == MaxColumns)
            {
                column = 0;
                row++;
            }
        }

        return result;
    }

    internal static Vector2f GetInitialPosition()
    {
        var parentPosition = InventoryPanel.GetInitialPosition();
        var parentSize = InventoryPanel.GetInitialSize();
        
        return parentPosition 
            + new Vector2f(
                parentSize.X * 0.4f,
                0f)    
            + new Vector2f(
                HEngineSettings.Instance.SmallOffsetX,
                HEngineSettings.Instance.SmallOffsetY);
    }

    internal static Vector2f GetInitialSize()
        => new Vector2f(_panelWidth, _panelHeight);

    public override void Draw(RenderTarget render)
    {
        render.Draw(this);
        foreach (var itemBlock in Blocks)
            itemBlock.Draw(render);
    }
}
