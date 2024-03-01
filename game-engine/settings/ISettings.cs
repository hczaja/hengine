using SFML.Window;

namespace game_engine.settings;

public interface ISettings
{
    float FPS { get; }
    VideoMode Mode { get; }
    Styles Styles { get; }
    string Title { get; }
    bool EnableKeyRepeat { get; }
    bool MouseCursorVisible { get; }
}
