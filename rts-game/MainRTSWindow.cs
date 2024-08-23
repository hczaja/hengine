using game_engine.core;
using game_engine.window;
using SFML.Graphics;

namespace rts_game;

internal class MainRTSWindow : IWindow
{
    private readonly RenderWindow _window;
    private readonly IHEngineCore _core;

    public MainRTSWindow(IHEngineCore core)
    {
        _core = core;

        _window = new RenderWindow(
            MainRTSSettings.FHDMode,
            MainRTSSettings.Title,
            MainRTSSettings.Styles);

        _window.SetKeyRepeatEnabled(enable: MainRTSSettings.EnableKeyRepeat);
        _window.SetMouseCursorVisible(visible: MainRTSSettings.MouseCursorVisible);

        _window.Closed += (_, _) => Close();
        _window.KeyPressed += _core._window_KeyPressed;
        _window.KeyReleased += _core._window_KeyReleased;

        //_window.MouseButtonPressed += _window_MouseButtonPressed;
        _window.MouseButtonPressed += _core._window_MouseButtonPressed;

        //_window.MouseButtonReleased += _window_MouseButtonReleased;
        _window.MouseButtonReleased += _core._window_MouseButtonReleased;
    }

    public void Clear() => _window.Clear();

    public void Close() => _window.Close();

    public void DispatchEvents() => _window.DispatchEvents();

    public void Display() => _window.Display();

    public void Draw() => _core.Render(_window);

    public bool IsOpen() => _window.IsOpen;

    public void Update() => _core.Update();
}
