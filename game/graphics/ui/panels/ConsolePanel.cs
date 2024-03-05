using game_engine.graphics.ui;
using game_engine.settings;
using SFML.Graphics;
using SFML.System;

namespace game.graphics.ui.panels;

class ConsolePanel : Panel
{
    private static readonly float _panelWidthRatio = 0.20f;
    private static readonly float _panelWidth = HEngineSettings.Instance.WindowWidth * _panelWidthRatio;

    private static readonly float _panelHeightRatio = 0.45f;
    private static readonly float _panelHeight = HEngineSettings.Instance.WindowHeight * _panelHeightRatio;

    public ConsolePanel()
        : base(GetInitialPosition(), GetInitialSize())
    {

    }

    public override void Draw(RenderTarget render)
    {
        render.Draw(this);
    }

    internal static Vector2f GetInitialPosition()
    {
        var panelAbovePosition = CharacterActionsPanel.GetInitialPosition();
        var panelAboveSize = CharacterActionsPanel.GetInitialSize();

        return new Vector2f(
            panelAbovePosition.X,
            panelAbovePosition.Y + panelAboveSize.Y + HEngineSettings.Instance.SmallOffsetY
            );
    }

    internal static Vector2f GetInitialSize()
        => new Vector2f(_panelWidth, _panelHeight);
}
