using game_engine.standards;
using SFML.Window;

namespace game_engine.settings;

public class HEngineSettings
{
    public static HEngineSettings Instance { get; } = new HEngineSettings();

    private HEngineSettings() { }

    public float FPS => 30f;

    public VideoMode Mode => VideoStandard.FHD.Mode;

    public float WindowWidth => Mode.Width;
    public float WindowHeight => Mode.Height;

    public float SmallOffsetX => WindowWidth * 0.02f;
    public float SmallOffsetY => WindowHeight * 0.02f;

    public Styles Styles => Styles.None;

    public string Title => string.Empty;

    public bool EnableKeyRepeat => false;

    public bool MouseCursorVisible => true;
}
