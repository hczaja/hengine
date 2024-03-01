using game_engine.standards;
using SFML.Window;

namespace game_engine.settings;

public class HEngineSettings : ISettings
{
    public float FPS => 30f;

    public VideoMode Mode => VideoStandard.WXGA.Mode;

    public Styles Styles => Styles.None;

    public string Title => string.Empty;

    public bool EnableKeyRepeat => false;

    public bool MouseCursorVisible => true;
}
