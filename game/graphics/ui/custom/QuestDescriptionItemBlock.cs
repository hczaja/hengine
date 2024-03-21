using game.assets.fonts;
using game.events;
using game.graphics.ui.panels.diary;
using game_engine.events;
using game_engine.graphics;
using game_engine.settings;
using SFML.Graphics;
using SFML.System;

namespace game.graphics.ui.custom;

class QuestDescriptionItemBlock : IDrawable, IEventHandler<SelectedQuestChangedEvent>
{
    private Text Title { get; }

    private Text Author { get; }

    private Text Description { get; }

    private Text Logs { get; }

    public QuestDescriptionItemBlock()
    {
        Title = new Text(string.Empty, RetroGamingFont.Instance.Font, RetroGamingFont.Instance.GetConsoleFontSize());
        Title.Position = QuestDescriptionPanel.GetInitialPosition();
        Title.FillColor = Color.White;

        Author = new Text(string.Empty, RetroGamingFont.Instance.Font, RetroGamingFont.Instance.GetConsoleFontSize());
        Author.Position = Title.Position + new Vector2f(0f, 50f);
        Author.FillColor = Color.Yellow;

        Description = new Text(string.Empty, RetroGamingFont.Instance.Font, RetroGamingFont.Instance.GetConsoleFontSize());
        Description.Position = Author.Position + new Vector2f(0f, 50f);
        Description.FillColor = Color.White;

        Logs = new Text(string.Empty, RetroGamingFont.Instance.Font, RetroGamingFont.Instance.GetConsoleFontSize());
        Logs.Position = Description.Position + new Vector2f(0f, 50f);
        Logs.FillColor = Color.White;
    }


    public void Draw(RenderTarget render)
    {
        render.Draw(Title);
        render.Draw(Author);
        render.Draw(Description);
        render.Draw(Logs);
    }

    public void Handle(SelectedQuestChangedEvent @event)
    {
        if (@event.quest is null)
            return;

        Title.DisplayedString = @event.quest.Title;
        Author.DisplayedString = @event.quest.Author;
        Description.DisplayedString = @event.quest.Description;
        Logs.DisplayedString = string.Join("", @event.quest.Logs);
    }
}
