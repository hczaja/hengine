using game.locations;
using game_engine.events.input;
using game_engine.graphics.ui;
using game_engine.logger;
using game_engine.settings;
using SFML.Graphics;
using SFML.System;

namespace game.graphics.ui.panels;

class LocationPanel : Panel
{
    private static readonly float _panelWidthRatio = 0.74f;
    private static readonly float _panelWidth = HEngineSettings.Instance.WindowWidth * _panelWidthRatio;

    private static readonly float _panelHeightRatio = 0.96f;
    private static readonly float _panelHeight = HEngineSettings.Instance.WindowHeight * _panelHeightRatio;

    private readonly LocationManager _locationManager;
    private ILocation CurrentLocation { get; set; }

    public LocationPanel(ILogger logger, LocationManager locationManager)
        : base(GetInitialPosition(), GetInitialSize())
    {
        _locationManager = locationManager;
        CurrentLocation = locationManager.GetStartingLocation(GetInitialPosition());
    }

    internal static Vector2f GetInitialPosition()
        => new Vector2f(
            HEngineSettings.Instance.SmallOffsetX,
            HEngineSettings.Instance.SmallOffsetY);

    internal static Vector2f GetInitialSize()
        => new Vector2f(_panelWidth, _panelHeight);

    public override void Draw(RenderTarget render)
    {
        render.Draw(this);
        CurrentLocation.Draw(render);
    }

    public override void Handle(MouseEvent @event)
    {
        CurrentLocation.Handle(@event);
    }
}
