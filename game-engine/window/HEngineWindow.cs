using game_engine.settings;
using SFML.Graphics;

namespace game_engine.window;

public class HEngineWindow : IWindow
{
    private readonly RenderWindow _window;

    public HEngineWindow(ISettings settings)
    {
        _window = new RenderWindow(settings.Mode, settings.Title, settings.Styles);

        _window.SetKeyRepeatEnabled(enable: settings.EnableKeyRepeat);
        _window.SetMouseCursorVisible(visible: settings.MouseCursorVisible);

        _window.Closed += (_, _) => Close();
    }

    public void Clear() => _window.Clear();

    public void Close() => _window.Close();

    public void DispatchEvents() => _window.DispatchEvents();

    public void Display() => _window.Display();

    public void Draw() { }

    public bool IsOpen() => _window.IsOpen;

    public void Update() { }
}
