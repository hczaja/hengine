using game_engine.content;
using game_engine.core;
using game_engine.events.input;
using SFML.Graphics;
using SFML.Window;

namespace rts_game;

internal class RTSCore : IHEngineCore
{
    private readonly IContent _content;

    public RTSCore()
    {
        _content = new MainRTSContent();
    }

    public void Render(RenderTarget target)
    {
        _content.DrawBy(target);
    }

    public void Update()
    {
        _content.Update();
    }

    public void _window_KeyPressed(object? sender, KeyEventArgs e) 
        => _content.Handle(new KeyboardEvent(KeyboardEventType.Pressed, e.Code));

    public void _window_KeyReleased(object? sender, KeyEventArgs e) 
        => _content.Handle(new KeyboardEvent(KeyboardEventType.Released, e.Code));

    public void _window_MouseButtonPressed(object? sender, MouseButtonEventArgs e) 
        => _content.Handle(new MouseEvent(MouseEventType.Pressed, e.X, e.Y, e.Button));

    public void _window_MouseButtonReleased(object? sender, MouseButtonEventArgs e) 
        => _content.Handle(new MouseEvent(MouseEventType.Released, e.X, e.Y, e.Button));

}
