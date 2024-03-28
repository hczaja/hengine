using game_contracts.diary;
using game_engine.events;
using game_engine.events.input;
using game_engine.graphics.ui;
using game_engine.logger;
using game_engine.settings;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace game.graphics.ui.panels.diary;

public class DiaryPanel : Panel
{
    private static readonly float _panelWidthRatio = 0.74f;
    private static readonly float _panelWidth = HEngineSettings.Instance.WindowWidth * _panelWidthRatio;

    private static readonly float _panelHeightRatio = 0.96f;
    private static readonly float _panelHeight = HEngineSettings.Instance.WindowHeight * _panelHeightRatio;

    private readonly IDiary _diary;

    private QuestDescriptionPanel QuestDescription { get; }
    private QuestListPanel QuestList { get; }

    public DiaryPanel(ILogger logger, IDiary diary)
        : base(GetInitialPosition(), GetInitialSize())
    {
        _diary = diary;

        QuestDescription = new QuestDescriptionPanel();
        QuestList = new QuestListPanel(diary, QuestDescription);

        FillColor = Color.Black;
    }

    internal static Vector2f GetInitialPosition()
        => new Vector2f(
            HEngineSettings.Instance.SmallOffsetX,
            HEngineSettings.Instance.SmallOffsetY);

    internal static Vector2f GetInitialSize()
        => new Vector2f(_panelWidth, _panelHeight);

    public override void Handle(KeyboardEvent @event)
    {
        if (@event.Type == KeyboardEventType.Released)
            return;

        QuestList.Handle(@event);
    }

    public override void Handle(MouseEvent @event) { }

    public override void Draw(RenderTarget render)
    {
        render.Draw(this);

        QuestList.Draw(render);
        QuestDescription.Draw(render);
    }
}
