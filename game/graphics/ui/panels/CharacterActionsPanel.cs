using game.context;
using game_engine.content;
using game_engine.context;
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

    private static readonly float _panelHeightRatio = 0.15f;
    private static readonly float _panelHeight = HEngineSettings.Instance.Mode.Height * _panelHeightRatio;

    private readonly Vector2f _actionButtonSize = new Vector2f(0.2f * _panelWidth, 0.5f * _panelHeight);

    private readonly IContent _main;

    private IContext Context { get; set; }
    private Button[] Actions { get; set; }

    public CharacterActionsPanel(IContent main)
        : base(GetInitialPosition(), GetInitialSize())
    {
        _main = main;
        Handle(new ChangeContextEvent(new LocationContext()));
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
            GetRestButton(0, 0),
            GetInventoryButton(1, 0),
            GetDiaryButton(2, 0),
            GetStatsButton(0, 1),
            GetOptionsButton(1, 1)
        ];

    private Button GetRestButton(int col, int row) => new Button(
        _actionButtonSize,
        new Vector2f(Position.X, Position.Y) + new Vector2f(col * _actionButtonSize.X, row * _actionButtonSize.Y),
        new Texture("assets/textures/buttons/campfire.png"),
        callback: () => _main.Handle(new ChangeContextEvent(new LocationContext())));


    private Button GetInventoryButton(int col, int row) => new Button(
        _actionButtonSize,
        new Vector2f(Position.X, Position.Y) + new Vector2f(col * _actionButtonSize.X, row * _actionButtonSize.Y),
        new Texture("assets/textures/buttons/campfire.png"),
        callback: () => _main.Handle(new ChangeContextEvent(new InventoryContext())));

    private Button GetDiaryButton(int col, int row) => new Button(
        _actionButtonSize,
        new Vector2f(Position.X, Position.Y) + new Vector2f(col * _actionButtonSize.X, row * _actionButtonSize.Y),
        new Texture("assets/textures/buttons/campfire.png"),
        callback: () => _main.Handle(new ChangeContextEvent(new DiaryContext())));

    private Button GetStatsButton(int col, int row) => new Button(
        _actionButtonSize,
        new Vector2f(Position.X, Position.Y) + new Vector2f(col * _actionButtonSize.X, row * _actionButtonSize.Y),
        new Texture("assets/textures/buttons/campfire.png"),
        callback: () => { Console.WriteLine("Stats"); });

    private Button GetOptionsButton(int col, int row) => new Button(
        _actionButtonSize,
        new Vector2f(Position.X, Position.Y) + new Vector2f(col * _actionButtonSize.X, row * _actionButtonSize.Y),
        new Texture("assets/textures/buttons/campfire.png"),
        callback: () => { Console.WriteLine("Options"); });
}
