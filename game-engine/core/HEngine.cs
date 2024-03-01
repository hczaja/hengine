using game_engine.settings;
using game_engine.time;
using game_engine.window;

namespace game_engine.core;

public sealed class HEngine
{
    private readonly IClock _clock;
    private readonly IWindow _window;

    public HEngine(IClock clock, IWindow window)
        => (_clock, _window) = (clock, window);

    public void Run()
    {
        while (_window.IsOpen())
        {
            if (_clock.TryUpdate())
            {
                _window.DispatchEvents();
                _window.Update();

                _window.Clear();
                _window.Draw();
                _window.Display();

                _window.Restart();                
            }
        }
    }
}
