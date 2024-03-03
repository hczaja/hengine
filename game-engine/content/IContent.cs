using game_engine.events;
using game_engine.events.input;
using game_engine.graphics;

namespace game_engine.content;

public interface IContent : IDrawable, IEventHandler<MouseEvent>, IEventHandler<KeyboardEvent>
{
    void Update();
}
