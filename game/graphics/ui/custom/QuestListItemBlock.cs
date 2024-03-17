using game.character.diary;
using game_engine.graphics;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.graphics.ui.custom;

class QuestListItemBlock : IDrawable
{
    public QuestListItemBlock(IQuest quest)
    {
        Quest = quest;
    }

    public IQuest Quest { get; }

    public void Draw(RenderTarget render)
    {

    }
}
