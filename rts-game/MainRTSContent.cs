using game_engine.content;
using game_engine.events.input;
using game_engine.events.system;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace rts_game
{
    internal class MainRTSContent : IContent
    {
        RectangleShape shape;

        private Vector2f MousePosition = new Vector2f(0, 0);
        private bool _drawSelectionRectangle;
        private bool _checkSelectionRectangle;

        public MainRTSContent()
        {
            shape = new RectangleShape();

            shape.FillColor = Color.Transparent;
            shape.OutlineColor = Color.White;
            shape.OutlineThickness = 1;

            shape.Size = new Vector2f(50, 50);
            shape.Position = new Vector2f(50, 50);
        }

        public void DrawBy(RenderTarget render)
        {
            if (_drawSelectionRectangle)
            {
                render.Draw(shape);
            }
        }

        public void Handle(MouseEvent @event)
        {
            MousePosition.X = @event.X;
            MousePosition.Y = @event.Y;
 
            if (@event.Button == Mouse.Button.Left)
            {
                switch (@event.Type)
                {
                    case MouseEventType.Pressed:
                        shape.Position = MousePosition;
                        _drawSelectionRectangle = true;
                        break;
                    case MouseEventType.Released:
                        _drawSelectionRectangle = false;
                        _checkSelectionRectangle = true;
                        break;
                }
            }
        }

        public void Handle(KeyboardEvent @event)
        {
        }

        public void Handle(ChangeContextEvent @event)
        {
        }

        public void Update()
        {
            if (_drawSelectionRectangle)
            {
                float width = shape.Position.X - MousePosition.X;
                float height = shape.Position.Y - MousePosition.Y;

                shape.Size = new Vector2f(-width, -height);
            }

            if (_checkSelectionRectangle)
            {

                _checkSelectionRectangle = false;
            }
        }
    }
}
