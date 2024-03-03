using game_engine.graphics.ui;
using game_engine.settings;
using SFML.System;

namespace game.graphics.ui.panels;

class CharacterActionsPanel : Panel
{
    private static readonly float _panelWidthRatio = 0.20f;
    private static readonly float _panelWidth = HEngineSettings.Instance.Mode.Width * _panelWidthRatio;

    private static readonly float _panelHeightRatio = 0.25f;
    private static readonly float _panelHeight = HEngineSettings.Instance.Mode.Height * _panelHeightRatio;

    public CharacterActionsPanel()
        : base(GetInitialPosition(), GetInitialSize())
    {

    }

    internal static Vector2f GetInitialPosition()
    {
        var panelAbovePosition = CharacterInfoPanel.GetInitialPosition();
        var panelAboveSize = CharacterInfoPanel.GetInitialSize();

        return new Vector2f(
            panelAbovePosition.X,
            panelAbovePosition.Y + panelAboveSize.Y + HEngineSettings.Instance.SmallOffsetY
            );
    }

    internal static Vector2f GetInitialSize()
        => new Vector2f(_panelWidth, _panelHeight);
}
