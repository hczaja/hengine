﻿using game_contracts.assets;
using game_engine.events.input;
using game_engine.settings;
using game_graphics.graphics.ui;
using game_graphics.graphics.ui.panels;
using SFML.Graphics;
using SFML.System;

namespace game.graphics.ui.panels;

public class GameActionsPanel : Panel
{
    private static readonly float _panelWidthRatio = 0.20f;
    private static readonly float _panelWidth = HEngineSettings.Instance.WindowWidth * _panelWidthRatio;

    private static readonly float _panelHeightRatio = 0.15f;
    private static readonly float _panelHeight = HEngineSettings.Instance.WindowHeight * _panelHeightRatio;

    private readonly Vector2f _actionButtonSize = new Vector2f(0.2f * _panelWidth, 0.5f * _panelHeight);

    private Button[] Actions { get; set; }

    public GameActionsPanel()
        : base(GetInitialPosition(), GetInitialSize())
    {
        FillColor = Palette.Instance.C07_PaleGreen;

        Actions = GetGameActions();
    }

    public override void DrawBy(RenderTarget render)
    {
        render.Draw(this);
        foreach (var action in Actions)
        {
            render.Draw(action);
        }
    }

    public override void Handle(MouseEvent @event)
    {
        foreach (var action in Actions)
        {
            action.Handle(@event);
        }
    }

    internal static Vector2f GetInitialPosition()
    {
        var panelAbovePosition = ConsolePanel.GetInitialPosition();
        var panelAboveSize = ConsolePanel.GetInitialSize();

        return new Vector2f(
            panelAbovePosition.X,
            panelAbovePosition.Y + panelAboveSize.Y + HEngineSettings.Instance.SmallOffsetY
            );
    }

    internal static Vector2f GetInitialSize()
        => new Vector2f(_panelWidth, _panelHeight);

    private Button[] GetGameActions() =>
    [
        GetSaveGameButton(0, 0),
        GetLoadGameButton(1, 0),
        GetGameStatsButton(2, 0),
        GetGameOptionsButton(0, 1),
        GetExitGameButton(1, 1)
    ];

    private Button GetSaveGameButton(int col, int row) => new Button(
        _actionButtonSize,
        new Vector2f(Position.X, Position.Y) + new Vector2f(col * _actionButtonSize.X, row * _actionButtonSize.Y),
        new Texture("assets/textures/buttons/campfire.png"),
        callback: () => { Console.WriteLine("Save"); });

    private Button GetLoadGameButton(int col, int row) => new Button(
        _actionButtonSize,
        new Vector2f(Position.X, Position.Y) + new Vector2f(col * _actionButtonSize.X, row * _actionButtonSize.Y),
        new Texture("assets/textures/buttons/campfire.png"),
        callback: () => { Console.WriteLine("Load"); });

    private Button GetGameStatsButton(int col, int row) => new Button(
        _actionButtonSize,
        new Vector2f(Position.X, Position.Y) + new Vector2f(col * _actionButtonSize.X, row * _actionButtonSize.Y),
        new Texture("assets/textures/buttons/campfire.png"),
        callback: () => { Console.WriteLine("Stats"); });

    private Button GetGameOptionsButton(int col, int row) => new Button(
        _actionButtonSize,
        new Vector2f(Position.X, Position.Y) + new Vector2f(col * _actionButtonSize.X, row * _actionButtonSize.Y),
        new Texture("assets/textures/buttons/campfire.png"),
        callback: () => { Console.WriteLine("Options"); });

    private Button GetExitGameButton(int col, int row) => new Button(
        _actionButtonSize,
        new Vector2f(Position.X, Position.Y) + new Vector2f(col * _actionButtonSize.X, row * _actionButtonSize.Y),
        new Texture("assets/textures/buttons/campfire.png"),
        callback: () => { Console.WriteLine("Exit"); });
}

