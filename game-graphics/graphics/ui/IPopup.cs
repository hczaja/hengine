using game_engine.events;
using game_engine.events.input;
using game_engine.graphics;

namespace game_graphics.graphics.ui;

interface IPopup : IDrawable, IEventHandler<MouseEvent>
{
    string ParentId { get; }
}
