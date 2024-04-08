using game_contracts.assets;
using game_contracts.diary;
using game_engine.events;
using game_engine.events.input;
using game_engine.settings;
using game_graphics.events;
using game_graphics.graphics.ui.custom;
using game_graphics.graphics.ui.panels.inventory;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace game_graphics.graphics.ui.panels.diary;

internal class QuestListPanel : Panel
{
    private static readonly float _panelWidthRatio = 0.36f;
    private static readonly float _panelWidth = InventoryPanel.GetInitialSize().X * _panelWidthRatio;

    private static readonly float _panelHeightRatio = 0.66f;
    private static readonly float _panelHeight = InventoryPanel.GetInitialSize().Y * _panelHeightRatio;

    private QuestListBlock QuestListBlock { get; set; }
    private QuestListTab ActiveQuestsTab { get; }
    private QuestListTab FinishedQuestsTab { get; }

    private readonly IDiary _diary;
    private readonly IEventHandler<SelectedQuestChangedEvent> _handler;

    public QuestListPanel(IDiary diary, IEventHandler<SelectedQuestChangedEvent> handler)
        : base(GetInitialPosition(), GetInitialSize())
    {
        _diary = diary;
        _handler = handler;

        FillColor = Palette.Instance.C03_Brown;

        ActiveQuestsTab = new QuestListTab(0);
        ActiveQuestsTab.Enable();

        FinishedQuestsTab = new QuestListTab(1);
        FinishedQuestsTab.Disable();

        QuestListBlock = new QuestListBlock(diary);
        _handler.Handle(new SelectedQuestChangedEvent(QuestListBlock.GetQuest()));
    }

    internal static Vector2f GetInitialPosition()
    {
        var parent = DiaryPanel.GetInitialPosition();

        return parent + new Vector2f(
            HEngineSettings.Instance.SmallOffsetX,
            HEngineSettings.Instance.SmallOffsetY);
    }

    internal static Vector2f GetInitialSize()
        => new Vector2f(_panelWidth, _panelHeight);

    public override void DrawBy(RenderTarget render)
    {
        render.Draw(this);

        QuestListBlock.DrawBy(render);
        ActiveQuestsTab.DrawBy(render);
        FinishedQuestsTab.DrawBy(render);
    }

    public override void Handle(KeyboardEvent @event)
    {
        if (@event.Key == Keyboard.Key.Tab)
        {
            if (ActiveQuestsTab.Enabled)
            {
                ActiveQuestsTab.Disable();
                FinishedQuestsTab.Enable();
            }
            else
            {
                FinishedQuestsTab.Disable();
                ActiveQuestsTab.Enable();
            }

            QuestListBlock.SwitchTab();
            _handler.Handle(new SelectedQuestChangedEvent(QuestListBlock.GetQuest()));
        }
        else if (@event.Key == Keyboard.Key.Up)
        {
            QuestListBlock.Prev();
            _handler.Handle(new SelectedQuestChangedEvent(QuestListBlock.GetQuest()));
        }
        else if (@event.Key == Keyboard.Key.Down)
        {
            QuestListBlock.Next();
            _handler.Handle(new SelectedQuestChangedEvent(QuestListBlock.GetQuest()));
        }
    }
}