using game.assets;
using game.assets.fonts;
using game.character.diary;
using game.graphics.ui.panels.diary;
using game_engine.graphics;
using game_engine.settings;
using SFML.Graphics;
using SFML.System;

namespace game.graphics.ui.custom;

class QuestListItemBlock : IDrawable
{
    private RectangleShape Shape { get; }
    private Text Text { get; }

    public QuestListItemBlock(IQuest quest, int index)
    {
        Quest = quest;

        var parentSize = QuestListPanel.GetInitialSize();
        var size = new Vector2f(parentSize.X, HEngineSettings.Instance.SmallOffsetY);

        var parentPosition = QuestListPanel.GetInitialPosition() + new Vector2f(0f, size.Y);
        
        Shape = new RectangleShape(size);
        Shape.OutlineThickness = 2f;
        Shape.OutlineColor = Color.Black;
        
        Shape.Position = parentPosition + new Vector2f(0f, index * size.Y);

        var fontSize = RetroGamingFont.Instance.GetConsoleFontSize();

        Text = new Text(quest.Title, RetroGamingFont.Instance.Font, fontSize);
        Text.FillColor = Color.Black;
        Text.Position = Shape.Position;
    }

    public IQuest Quest { get; }

    public void Draw(RenderTarget render)
    {
        render.Draw(Shape);
        render.Draw(Text);
    }
}
