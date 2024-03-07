using game.assets.fonts;
using game_engine.graphics.ui;
using game_engine.logger;
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

    private readonly ILogger _logger;
    private Text Text { get; }

    public ConsolePanel(ILogger logger)
        : base(GetInitialPosition(), GetInitialSize())
    {
        Text = new Text()
        {
            CharacterSize = 32,
            Font = RetroGamingFont.Instance.Font,
            FillColor = Color.Black,
            DisplayedString = "bla bla",
            Position = Position
        };
    }

    public override void Draw(RenderTarget render)
    {
        render.Draw(this);
        render.Draw(Text);
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
