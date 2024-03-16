using static SFML.Window.Keyboard;

namespace game_engine.events.input;

public record KeyboardEvent(KeyboardEventType Type, Key Key) : IEvent
{
    public Guid Id { get; } = Guid.NewGuid();
}