using SFML.Window;

namespace game_engine.standards;

class VideoStandard
{
    public VideoMode Mode { get; }

    private VideoStandard(VideoMode mode) => Mode = mode;

    public static VideoStandard Default = new VideoStandard(VideoMode.DesktopMode);
    public static VideoStandard WXGA = new VideoStandard(new VideoMode(1280, 720));
    public static VideoStandard FHD = new VideoStandard(new VideoMode(1920, 1200));
    public static VideoStandard QHD = new VideoStandard(new VideoMode(2560, 1440));
}
