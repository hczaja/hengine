using game_engine.settings;
using game_engine.standards;
using SFML.Graphics;

namespace game.assets.fonts;

class RetroGamingFont
{
    public static RetroGamingFont Instance = new RetroGamingFont();
    private RetroGamingFont() { }

    public Font Font { get; } = new Font("assets/fonts/Retro Gaming.ttf");

    public uint GetConsoleFontSize()
    {
        var mode = HEngineSettings.Instance.Mode;

        if (mode.Equals(VideoStandard.WXGA.Mode))
        {
            return 12;
        }
        if (mode.Equals(VideoStandard.FHD.Mode))
        {
            return 20;
        }
        if (mode.Equals(VideoStandard.QHD.Mode))
        {
            return 24;
        }

        return 24;
    }

    public int GetConsoleMaxLines() => 20;

    public uint GetConsoleMaxCharactersInLine() => 40;
}
