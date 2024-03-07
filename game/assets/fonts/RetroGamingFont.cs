using SFML.Graphics;

namespace game.assets.fonts;

class RetroGamingFont
{
    public static RetroGamingFont Instance = new RetroGamingFont();
    private RetroGamingFont() { }

    public Font Font { get; } = new Font("assets/fonts/Retro Gaming.ttf");
}
