using SFML.Graphics;
using SFML.Window;

namespace game_engine.core;

public interface IHEngineCore
{
    void _window_KeyPressed(object? sender, KeyEventArgs e);
    void _window_KeyReleased(object? sender, KeyEventArgs e);
    void _window_MouseButtonReleased(object? sender, MouseButtonEventArgs e);
    void _window_MouseButtonPressed(object? sender, MouseButtonEventArgs e);

    void Update();
    void Render(RenderTarget target);
}
