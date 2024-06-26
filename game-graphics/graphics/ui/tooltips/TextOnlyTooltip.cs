﻿using SFML.Graphics;
using SFML.System;

namespace game_graphics.graphics.ui.tooltips;

class TextOnlyTooltip : Tooltip
{
    public TextOnlyTooltip(Vector2f position, Vector2f size) : base(position, size)
    {

    }

    public override void DrawBy(RenderTarget render)
    {
        render.Draw(this);
    }
}
