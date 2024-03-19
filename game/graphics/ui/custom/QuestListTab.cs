using game.assets;
using game.graphics.ui.panels.diary;
using game_engine.graphics;
using game_engine.settings;
using SFML.Graphics;
using SFML.System;

namespace game.graphics.ui.custom;

class QuestListTab : IDrawable
{
    private RectangleShape Shape { get; }

    public QuestListTab(int index)
    {
        var parentPos = QuestListPanel.GetInitialPosition();
        var parentSize = QuestListPanel.GetInitialSize();

        var size = new Vector2f(parentSize.X / 2f, HEngineSettings.Instance.SmallOffsetY);

        Shape = new RectangleShape(size);
        Shape.Position = parentPos + new Vector2f(index * size.X, 0f);
        Shape.OutlineThickness = 2f;
        Shape.OutlineColor = Color.Black;
        Shape.FillColor = Palette.Instance.C09_PaleYellow;
    }

    public void Draw(RenderTarget render)
    {
        render.Draw(Shape);
    }
}
