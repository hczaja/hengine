﻿using game_engine.graphics.ui;
using game_engine.settings;
using SFML.Graphics;
using SFML.System;

namespace game.graphics.ui.panels;

class InventoryPanel : Panel
{
    private static readonly float _panelWidthRatio = 0.74f;
    private static readonly float _panelWidth = HEngineSettings.Instance.WindowWidth * _panelWidthRatio;

    private static readonly float _panelHeightRatio = 0.96f;
    private static readonly float _panelHeight = HEngineSettings.Instance.WindowHeight * _panelHeightRatio;

    public InventoryPanel()
        : base(GetInitialPosition(), GetInitialSize())
    {
        this.FillColor = Color.Red;
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
    }
}
