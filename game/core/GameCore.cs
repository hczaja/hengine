using game.content;
using game.logger;
using game_engine.content;
using game_engine.core;
using game_engine.events.input;
using game_engine.logger;
using game_engine.settings;
using SFML.Graphics;
using SFML.Window;

namespace game.core;

internal class GameCore : IHEngineCore
{
    public IContent ActualContent { get; }
    public IContent CommonContent { get; }

    public Dictionary<string, IContent> ContentRegistry { get; }

    private readonly ILogger _logger;

    public GameCore()
    {
        var main = new MainContent(new InGameConsoleLogger());
        var common = new StaticContent();

        ContentRegistry = new Dictionary<string, IContent>()
        {
            { nameof(MainContent), main },
            { nameof(StaticContent), common }
        };

        ActualContent = main;
        CommonContent = common;
    }

    public void Render(RenderTarget target)
    {
        ActualContent.Draw(target);
    }

    public void Update()
    {
        ActualContent.Update();
        CommonContent.Update();
    }

    public void _window_KeyPressed(object? sender, KeyEventArgs e) => ActualContent.Handle(new KeyboardEvent(KeyboardEventType.Pressed, e.Code));

    public void _window_KeyReleased(object? sender, KeyEventArgs e) => ActualContent.Handle(new KeyboardEvent(KeyboardEventType.Released, e.Code));

    public void _window_MouseButtonPressed(object? sender, MouseButtonEventArgs e) => ActualContent.Handle(new MouseEvent(MouseEventType.Pressed, e.X, e.Y, e.Button));

    public void _window_MouseButtonReleased(object? sender, MouseButtonEventArgs e) => ActualContent.Handle(new MouseEvent(MouseEventType.Released, e.X, e.Y, e.Button));
}