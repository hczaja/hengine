using game_contracts.assets;
using game_contracts.assets.fonts;
using game_contracts.diary;
using game_engine.graphics;
using game_engine.settings;
using game_graphics.graphics.ui.panels.diary;
using SFML.Graphics;
using SFML.System;

namespace game_graphics.graphics.ui.custom;

class QuestListItemBlock : IDrawable
{
    private RectangleShape Shape { get; }
    private Text Text { get; }
    public IQuest Quest { get; }
    public int Index { get; }
    public bool Enabled { get; private set; }

    public QuestListItemBlock(IQuest quest, int index)
    {
        Quest = quest;
        Index = index;

        var parentSize = QuestListPanel.GetInitialSize();
        var size = new Vector2f(parentSize.X, HEngineSettings.Instance.SmallOffsetY);

        var parentPosition = QuestListPanel.GetInitialPosition() + new Vector2f(0f, size.Y);
        
        Shape = new RectangleShape(size);
        Shape.OutlineThickness = 2f;
        Shape.OutlineColor = Color.Black;
        Shape.FillColor = Palette.Instance.C03_Brown;
        
        Shape.Position = parentPosition + new Vector2f(0f, index * size.Y);

        Text = new Text(
            quest.Title, 
            RetroGamingFont.Instance.Font, 
            RetroGamingFont.Instance.GetConsoleFontSize());

        Text.FillColor = Color.Black;
        Text.Position = Shape.Position;
    }

    public void DrawBy(RenderTarget render)
    {
        render.Draw(Shape);
        render.Draw(Text);
    }

    public void Enable()
    {
        Enabled = true;
        Shape.FillColor = Color.White;
    }

    public void Disable()
    {
        Enabled = false;
        Shape.FillColor = Palette.Instance.C03_Brown;
    }
}
