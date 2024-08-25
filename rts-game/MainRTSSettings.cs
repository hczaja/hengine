using SFML.Window;

namespace rts_game
{
    public static class MainRTSSettings
    {
        public static readonly VideoMode FHDMode = new VideoMode(1920, 1200);
        public static readonly string Title = "RTS";
        public static readonly Styles Styles = Styles.None;
        public static readonly bool MouseCursorVisible = true;
        public static readonly bool EnableKeyRepeat = true;
        public static readonly bool DrawCollisions = true;
    }
}
