using game_engine.core;
using game_engine.settings;
using SFML.Graphics;
using System.Xml.Linq;

namespace game_engine.window;

public class HEngineWindow : IWindow
{
    private readonly RenderWindow _window;
    private readonly IHEngineCore _core;

    public HEngineWindow(IHEngineCore core)
    {
        _core = core;

        _window = new RenderWindow(
            HEngineSettings.Instance.Mode,
            HEngineSettings.Instance.Title,
            HEngineSettings.Instance.Styles);

        _window.SetKeyRepeatEnabled(enable: HEngineSettings.Instance.EnableKeyRepeat);
        _window.SetMouseCursorVisible(visible: HEngineSettings.Instance.MouseCursorVisible);

        _window.Closed += (_, _) => Close();
        _window.KeyPressed += _core._window_KeyPressed;
        _window.KeyReleased += _core._window_KeyReleased;
        _window.MouseButtonPressed += _core._window_MouseButtonPressed;
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
