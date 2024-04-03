using game_contracts.locations;
using game_contracts.logger;
using game_engine.events.input;
using game_engine.settings;
using game_graphics.graphics.ui.locations;
using game_graphics.graphics.ui.popups;
using SFML.Graphics;
using SFML.System;

namespace game_graphics.graphics.ui.panels;

public class LocationPanel : Panel
{
    private static readonly float _panelWidthRatio = 0.74f;
    private static readonly float _panelWidth = HEngineSettings.Instance.WindowWidth * _panelWidthRatio;

    private static readonly float _panelHeightRatio = 0.96f;
    private static readonly float _panelHeight = HEngineSettings.Instance.WindowHeight * _panelHeightRatio;

    private readonly ILocationManager _locationManager;
    private readonly IPopupService _popupService;
    private DrawableLocation CurrentLocation { get; set; }

    public LocationPanel(ILogger logger, ILocationManager locationManager)
        : base(GetInitialPosition(), GetInitialSize())
    {
        _locationManager = locationManager;
        _popupService = new PopupService();

        CurrentLocation = new DrawableLocation(_popupService, locationManager.GetStartingLocation());
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
        _popupService.Draw(render);
    }

    public override void Handle(MouseEvent @event)
    {
        CurrentLocation.Handle(@event);
        _popupService.Handle(@event);
    }
}
