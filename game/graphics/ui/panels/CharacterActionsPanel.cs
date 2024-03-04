using game.context;
using game_engine.context;
using game_engine.events;
using game_engine.events.input;
using game_engine.events.system;
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

    private IContext Context { get; set; }
    private Button[] Actions { get; set; }

    public CharacterActionsPanel(IContext context)
        : base(GetInitialPosition(), GetInitialSize())
    {
        Handle(new ChangeContextEvent(context));
    }

    public override void Draw(RenderTarget render)
    {
        render.Draw(this);
        foreach (var action in Actions) 
        {
            render.Draw(action);
        }
    }

    public override void Handle(MouseEvent @event)
    {
        foreach (var action in Actions) 
        {
            action.Handle(@event);
        }
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

    public override void Handle(ChangeContextEvent @event)
    {
        Context = @event.Context;

        if (Context is LocationContext locationContext)
            Actions = GetLocationContextActions(locationContext);
    }

    private Button[] GetLocationContextActions(LocationContext context) =>
        [
            GetRestButton(),
            GetInventoryButton(),
            GetDiaryButton(),
            GetStatsButton(),
            GetOptionsButton()
        ];


    private Button GetRestButton() => new Button(
        _actionButtonSize,
        new Vector2f(this.Position.X, this.Position.Y),
        new Texture("assets/textures/buttons/campfire.png"),
        callback: () => { Console.WriteLine("xd1"); });

    private Button GetInventoryButton() => new Button(
        _actionButtonSize,
        new Vector2f(this.Position.X, this.Position.Y) + new Vector2f(_actionButtonSize.X, 0f),
        new Texture("assets/textures/buttons/campfire.png"),
        callback: () => { Console.WriteLine("xd2"); });

    private Button GetDiaryButton() => new Button(
        _actionButtonSize,
        new Vector2f(this.Position.X, this.Position.Y) + new Vector2f(2 * _actionButtonSize.X, 0f),
        new Texture("assets/textures/buttons/campfire.png"),
        callback: () => { Console.WriteLine("xd3"); });

    private Button GetStatsButton() => new Button(
        _actionButtonSize,
        new Vector2f(this.Position.X, this.Position.Y) + new Vector2f(3 * _actionButtonSize.X, 0f),
        new Texture("assets/textures/buttons/campfire.png"),
        callback: () => { Console.WriteLine("xd4"); });

    private Button GetOptionsButton() => new Button(
        _actionButtonSize,
        new Vector2f(this.Position.X, this.Position.Y) + new Vector2f(4 * _actionButtonSize.X, 0f),
        new Texture("assets/textures/buttons/campfire.png"),
        callback: () => { Console.WriteLine("xd5"); });
}
