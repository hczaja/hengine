using game.character;
using game.locations;
using game.logger;
using game_contracts.logger;
using game_engine.content;
using game_engine.core;
using game_engine.events.input;
using game_graphics.content;
using SFML.Graphics;
using SFML.Window;

namespace game.core;

internal class GameCore : IHEngineCore
{
    public IContent ActualContent { get; }

    private readonly ILogger _logger;

    public GameCore()
    {
        var main = new MainContent(new InGameConsoleLogger(), new MainCharacter(), new LocationManager());

        ActualContent = main;
    }

    public void Render(RenderTarget target)
    {
        ActualContent.Draw(target);
    }

    public void Update()
    {
        ActualContent.Update();
    }

    public void _window_KeyPressed(object? sender, KeyEventArgs e) => ActualContent.Handle(new KeyboardEvent(KeyboardEventType.Pressed, e.Code));

    public void _window_KeyReleased(object? sender, KeyEventArgs e) => ActualContent.Handle(new KeyboardEvent(KeyboardEventType.Released, e.Code));

    public void _window_MouseButtonPressed(object? sender, MouseButtonEventArgs e) => ActualContent.Handle(new MouseEvent(MouseEventType.Pressed, e.X, e.Y, e.Button));

    public void _window_MouseButtonReleased(object? sender, MouseButtonEventArgs e) => ActualContent.Handle(new MouseEvent(MouseEventType.Released, e.X, e.Y, e.Button));
}