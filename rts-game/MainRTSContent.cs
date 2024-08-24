using game_engine.content;
using game_engine.events.input;
using game_engine.events.system;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace rts_game
{
    public class MainRTSContent : IContent
    {
        private readonly GameManager _gameManager;
        private readonly Selector _selector;

        private Vector2f MousePosition = new Vector2f(0, 0);

        public MainRTSContent(GameManager gameManager)
        {
            _gameManager = gameManager;

            _selector = new Selector();
        }

        public void DrawBy(RenderTarget render)
        {
            _selector.DrawBy(render);
        }

        public void Handle(MouseEvent @event)
        {
            MousePosition.X = @event.X;
            MousePosition.Y = @event.Y;
 
            if (@event.Button == Mouse.Button.Left)
            {
                _selector.Handle(@event);
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
            _selector.Update(MousePosition);
        }
    }
}
