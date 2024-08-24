using SFML.Window;

namespace rts_game
{
    internal static class MainRTSSettings
    {
        internal static readonly VideoMode FHDMode = new VideoMode(1920, 1200);
        internal static readonly string Title = "RTS";
        internal static readonly Styles Styles = Styles.None;
        internal static readonly bool MouseCursorVisible = true;
        internal static readonly bool EnableKeyRepeat = true;
    }
}
