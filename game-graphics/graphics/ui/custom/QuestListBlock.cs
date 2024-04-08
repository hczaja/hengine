using game_contracts.diary;
using game_engine.graphics;
using SFML.Graphics;

namespace game_graphics.graphics.ui.custom;

class QuestListBlock : IDrawable
{
    private List<QuestListItemBlock> QuestsBlocks { get; set; }
    private bool ShowActiveQuests { get; set; }
    private QuestListItemBlock Pointer { get; set; }

    private readonly IDiary _diary;

    public QuestListBlock(IDiary diary)
    {
        _diary = diary;

        QuestsBlocks = new List<QuestListItemBlock>();

        int index = 0;
        foreach (var quest in diary.Active)
        {
            QuestsBlocks.Add(
                new QuestListItemBlock(quest, index));
            index++;
        }

        ShowActiveQuests = true;

        var first = QuestsBlocks.FirstOrDefault();
        if (first is not null)
            Pointer = first;

        Pointer?.Enable();
    }

    public IQuest GetQuest() => Pointer?.Quest;

    public void DrawBy(RenderTarget render)
    {
        foreach (var item in QuestsBlocks)
            item.DrawBy(render);
    }

    public void SwitchTab()
    {
        ShowActiveQuests = !ShowActiveQuests;
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

        var first = QuestsBlocks.FirstOrDefault();
        if (first is not null)
        { 
            Pointer = first;
        }

        Pointer?.Enable();
    }

    public void Next()
    {
        Pointer?.Disable();

        if (Pointer is null)
        {
            Pointer = QuestsBlocks.FirstOrDefault();
            Pointer?.Enable();
            return;
        }

        var index = QuestsBlocks.IndexOf(Pointer);
        if (index + 1 >= QuestsBlocks.Count)
        {
            Pointer = QuestsBlocks.FirstOrDefault();
            Pointer?.Enable();
            return;
        }

        Pointer = QuestsBlocks[index + 1];
        Pointer?.Enable();
    }

    public void Prev()
    {
        Pointer?.Disable();

        if (Pointer is null)
        {
            Pointer = QuestsBlocks.FirstOrDefault();
            Pointer?.Enable();
            return;
        }

        var index = QuestsBlocks.IndexOf(Pointer);
        if (index - 1 < 0)
        {
            Pointer = QuestsBlocks.LastOrDefault();
            Pointer?.Enable();
            return;
        }

        Pointer = QuestsBlocks[index - 1];
        Pointer?.Enable();
    }
}
