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
    private readonly IContent _content;
    private readonly ILogger _logger;

    public GameCore()
    {
        _logger = new InGameConsoleLogger();
        _content = new MainContent(
            _logger, 
            new MainCharacter(_logger), 
            new LocationManager(_logger));
    }

    public void Render(RenderTarget target)
    {
        _content.Draw(target);
    }

    public void Update()
    {
        _content.Update();
    }

    public void _window_KeyPressed(object? sender, KeyEventArgs e) => _content.Handle(new KeyboardEvent(KeyboardEventType.Pressed, e.Code));

    public void _window_KeyReleased(object? sender, KeyEventArgs e) => _content.Handle(new KeyboardEvent(KeyboardEventType.Released, e.Code));

    public void _window_MouseButtonPressed(object? sender, MouseButtonEventArgs e) => _content.Handle(new MouseEvent(MouseEventType.Pressed, e.X, e.Y, e.Button));
    
    public void _window_MouseButtonReleased(object? sender, MouseButtonEventArgs e) => _content.Handle(new MouseEvent(MouseEventType.Released, e.X, e.Y, e.Button));
}