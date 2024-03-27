using SFML.Graphics;

namespace game_contracts.assets;

class Palette
{
    public static Palette Instance = new Palette();
    private Palette() { }

    public Color C01_DarkBrown { get; } = new Color(45, 14, 3);
    public Color C02_DirtyRed { get; } = new Color(134, 2, 16);
    public Color C03_Brown { get; } = new Color(127, 58, 40);
    public Color C04_DirtyOrange { get; } = new Color(165, 78, 20);
    public Color C05_DarkGreen { get; } = new Color(74, 63, 12);
    public Color C06_RottenGreen { get; } = new Color(108, 95, 23);
    public Color C07_PaleGreen { get; } = new Color(138, 142, 85);
    public Color C08_DarkYellow { get; } = new Color(139, 128, 93);
    public Color C09_PaleYellow { get; } = new Color(187, 158, 127);
    public Color C10_SandYellow { get; } = new Color(235, 234, 178);
}
