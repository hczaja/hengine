﻿using game_engine.graphics.ui;
using SFML.Graphics;
using SFML.System;

namespace game.graphics.ui.tooltips
{
    class InformationNotification : Notification
    {
        public InformationNotification(Vector2f position, Vector2f size) : base(position, size)
        {

        }

        public override void Draw(RenderTarget render)
        {
            render.Draw(this);
        }
    }
}
