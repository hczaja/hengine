using game_contracts.assets;
using game_contracts.assets.fonts;
using game_contracts.logger;
using game_engine.settings;
using SFML.Graphics;
using SFML.System;

namespace game_graphics.graphics.ui.panels;

public class ConsolePanel : Panel
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
        _logger = logger;

        FillColor = Palette.Instance.C07_PaleGreen;
        Text = new Text()
        {
            CharacterSize = RetroGamingFont.Instance.GetConsoleFontSize(),
            Font = RetroGamingFont.Instance.Font,
            FillColor = Palette.Instance.C01_DarkBrown,
            DisplayedString = ">",
            Position = Position + new Vector2f(HEngineSettings.Instance.SmallOffsetX / 2, HEngineSettings.Instance.SmallOffsetX / 2),
            OutlineThickness = 1f,
            OutlineColor = Color.White,
        };

        _logger.OnLog += (_, _) => UpdateDisplay();
    }

    public override void DrawBy(RenderTarget render)
    {
        render.Draw(this);
        render.Draw(Text);
    }

    private void UpdateDisplay()
    {
        string text = _logger.DisplayText;
        
        var chunks = text.Split(Environment.NewLine);
        var messages = chunks.Take(chunks.Length - 1).ToArray();

        var messagesLimit = RetroGamingFont.Instance.GetConsoleMaxLines();

        if (messages.Length > messagesLimit)
            text = string.Join(Environment.NewLine, messages[^messagesLimit..]);

        Text.DisplayedString = text;
    }

    private void ScrollDown()
    {
        var messages = Text.DisplayedString.Split(Environment.NewLine);
        Text.DisplayedString = string.Join(Environment.NewLine, messages.Skip(1));
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
