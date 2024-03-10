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

    public BackpackPanel()
        : base(GetInitialPosition(), GetInitialSize())
    {
        FillColor = Color.White;
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
    }
}
