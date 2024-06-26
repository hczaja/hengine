﻿using game_contracts.locations;
using game_contracts.logger;
using game_engine.events.input;
using game_engine.settings;
using game_graphics.graphics.ui.locations;
using game_graphics.graphics.ui.notifications;
using game_graphics.graphics.ui.popups;
using SFML.Graphics;
using SFML.System;

namespace game_graphics.graphics.ui.panels;

public class LocationPanel : Panel
{
    private static readonly float _panelWidthRatio = 0.98f;
    private static readonly float _panelWidth = HEngineSettings.Instance.WindowWidth * _panelWidthRatio;

    private static readonly float _panelHeightRatio = 0.98f;
    private static readonly float _panelHeight = HEngineSettings.Instance.WindowHeight * _panelHeightRatio;

    private readonly ILocationManager _locationManager;
    private readonly IPopupService _popupService;
    private readonly INotificationService _notificationService;
    private DrawableLocation CurrentLocation { get; set; }
    private RectangleShape Frame { get; }

    public LocationPanel(ILogger logger, ILocationManager locationManager)
        : base(GetInitialPosition(), GetInitialSize())
    {
        _locationManager = locationManager;

        _popupService = new PopupService();
        _notificationService = new NotificationService();

        CurrentLocation = new DrawableLocation(_popupService, _notificationService, locationManager.GetStartingLocation());

        Frame = new RectangleShape(
            new Vector2f(
                HEngineSettings.Instance.WindowWidth,
                HEngineSettings.Instance.WindowHeight));
        Frame.Texture = new Texture("assets/locations/ui.png");

    }

    internal static Vector2f GetInitialPosition()
        => new Vector2f(
            HEngineSettings.Instance.SmallOffsetX,
            HEngineSettings.Instance.SmallOffsetY);

    internal static Vector2f GetInitialSize()
        => new Vector2f(
            _panelWidth,
            _panelHeight);

    public override void DrawBy(RenderTarget render)
    {
        CurrentLocation.DrawBy(render);

        _popupService.DrawBy(render);
        _notificationService.DrawBy(render);

        render.Draw(Frame);
    }

    public override void Handle(MouseEvent @event)
    {
        _popupService.Handle(@event);
        _notificationService.Handle(@event);

        CurrentLocation.Handle(@event);
    }
}
