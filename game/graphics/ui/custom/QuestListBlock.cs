using game.character.diary;
using game.graphics.ui.panels.diary;
using game_engine.core;
using game_engine.graphics;
using game_engine.settings;
using SFML.Graphics;
using SFML.System;

namespace game.graphics.ui.custom;

class QuestListBlock : IDrawable
{
    private Vector2f Postion { get; }
    private Vector2f Size { get; }
    private List<QuestListItemBlock> QuestsBlocks { get; set; }
    private bool ShowActiveQuests { get; }

    private readonly IDiary _diary;

    public IQuest Pointer { get; }

    public QuestListBlock(IDiary diary)
    {
        _diary = diary;

        Postion = QuestListPanel.GetInitialPosition() 
            + new Vector2f(
                HEngineSettings.Instance.SmallOffsetX,
                HEngineSettings.Instance.SmallOffsetY);

        Size = QuestListPanel.GetInitialSize()
            - new Vector2f(
                2 * HEngineSettings.Instance.SmallOffsetX,
                2 * HEngineSettings.Instance.SmallOffsetY);

        QuestsBlocks = new List<QuestListItemBlock>();

        int index = 0;
        foreach (var quest in diary.Active)
        {
            QuestsBlocks.Add(
                new QuestListItemBlock(quest, index));
            index++;
        }
        ShowActiveQuests = true;

        Pointer = null;

        var first = QuestsBlocks.FirstOrDefault();
        if (first is not null)
            Pointer = first.Quest;
    }

    public void Draw(RenderTarget render)
    {
        foreach (var item in QuestsBlocks)
            item.Draw(render);
    }

    public void SwitchList()
    {
        QuestsBlocks = new List<QuestListItemBlock>();

        int index = 0;
        foreach (var quest in ShowActiveQuests 
            ? _diary.Active 
            : _diary.Finished)
        {
            QuestsBlocks.Add(
                new QuestListItemBlock(quest, index));
            index++;
        }
    }
}
