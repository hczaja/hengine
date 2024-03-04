using game_engine.events;
using game_engine.events.input;
using game_engine.graphics.ui;
using game_engine.settings;
using SFML.Graphics;
using SFML.System;

namespace game.graphics.ui.panels;

class CharacterActionsPanel : Panel
{
    private static readonly float _panelWidthRatio = 0.20f;
    private static readonly float _panelWidth = HEngineSettings.Instance.Mode.Width * _panelWidthRatio;

    private static readonly float _panelHeightRatio = 0.25f;
    private static readonly float _panelHeight = HEngineSettings.Instance.Mode.Height * _panelHeightRatio;

    private readonly Vector2f _actionButtonSize = new Vector2f(0.2f * _panelWidth, 0.2f * _panelHeight);

    private Button[] Actions { get; }

    public CharacterActionsPanel()
        : base(GetInitialPosition(), GetInitialSize())
    {
        Actions = new Button[1];

        var rest_action = new Button(
            _actionButtonSize,
            new Vector2f(this.Position.X, this.Position.Y),
            new Texture("assets/textures/buttons/campfire.png"),
            () => { Console.WriteLine("xd"); });

        Actions[0] = rest_action;
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

    public override void Draw(RenderTarget render)
    {
        render.Draw(this);
        render.Draw(Actions[0]);
    }

    public override void Handle(MouseEvent @event)
    {
        Actions[0].Handle(@event);
    }
}
