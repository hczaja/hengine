using game_engine.events.input;
using game_engine.events;

namespace rts_game;

public interface IUserInputHandler 
    : IEventHandler<MouseEvent>, 
    IEventHandler<KeyboardEvent>
{ }
