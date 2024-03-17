using game.assets;
using game.character.diary;
using game.events;
using game.graphics.ui.custom;
using game.graphics.ui.panels.inventory;
using game_engine.events;
using game_engine.events.input;
using game_engine.graphics.ui;
using game_engine.settings;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace game.graphics.ui.panels.diary;

class QuestDescriptionPanel : Panel, IEventHandler<SelectedQuestChangedEvent>
{
    private static readonly float _panelWidthRatio = 0.54f;
    private static readonly float _panelWidth = InventoryPanel.GetInitialSize().X * _panelWidthRatio;

    private static readonly float _panelHeightRatio = 0.96f;
    private static readonly float _panelHeight = InventoryPanel.GetInitialSize().Y * _panelHeightRatio;

    private QuestDescriptionItemBlock DescriptionBlock { get; set; }

    public QuestDescriptionPanel()
        : base(GetInitialPosition(), GetInitialSize())
    {        
        FillColor = Palette.Instance.C03_Brown;
        DescriptionBlock = new QuestDescriptionItemBlock();
    }

    internal static Vector2f GetInitialPosition()
    {
        var parentPosition = DiaryPanel.GetInitialPosition();
        var parentSize = DiaryPanel.GetInitialSize();

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
        DescriptionBlock.Draw(render);
    }

    public void Handle(SelectedQuestChangedEvent @event)
    {
        DescriptionBlock.Handle(@event);
    }
}