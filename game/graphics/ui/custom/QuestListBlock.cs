using game.character.diary;
using game_engine.graphics;
using SFML.Graphics;
using SFML.System;

namespace game.graphics.ui.custom;

class QuestListBlock : IDrawable
{
    public Vector2f Postion { get; }
    public Vector2f Size { get; }

    List<QuestListItemBlock> QuestsBlocks { get; }

    public QuestListBlock(IEnumerable<IQuest> quests)
    {
        QuestsBlocks = new List<QuestListItemBlock>();
        foreach (var  quest in quests)
        {
            QuestsBlocks.Add(
                new QuestListItemBlock());
        }
    }

    public void Draw(RenderTarget render)
    {
        foreach (var item in QuestsBlocks)
            item.Draw(render);
    }
}
