using game_contracts.assets;
using game_engine.graphics;
using game_engine.settings;
using game_graphics.graphics.ui.panels.diary;
using SFML.Graphics;
using SFML.System;

namespace game_graphics.graphics.ui.custom;

class QuestListTab : IDrawable
{
    private RectangleShape Shape { get; }

    public bool Enabled { get; private set; }

    public QuestListTab(int index)
    {
        var parentPos = QuestListPanel.GetInitialPosition();
        var parentSize = QuestListPanel.GetInitialSize();

        var size = new Vector2f(parentSize.X / 2f, HEngineSettings.Instance.SmallOffsetY);

        Shape = new RectangleShape(size);
        Shape.Position = parentPos + new Vector2f(index * size.X, 0f);
    }

    public void Draw(RenderTarget render)
    {
        render.Draw(Shape);
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
