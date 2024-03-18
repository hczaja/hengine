using game.character.diary;
using game.graphics.ui.panels.diary;
using game_engine.graphics;
using game_engine.settings;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.graphics.ui.custom;

class QuestListItemBlock : IDrawable
{
    private RectangleShape Shape { get; }

    public QuestListItemBlock(IQuest quest, int index)
    {
        Quest = quest;

        var parentSize = QuestListPanel.GetInitialSize();
        var size = new Vector2f(parentSize.X, parentSize.Y / 12f);

        var parentPosition = QuestListPanel.GetInitialPosition() + new Vector2f(0f, size.Y);
        
        Shape = new RectangleShape(size);
        Shape.Position = parentPosition + new Vector2f(0f, index * size.Y);
    }

    public IQuest Quest { get; }

    public void Draw(RenderTarget render)
    {
        render.Draw(Shape);
    }
}
