using static SFML.Window.Mouse;

namespace game_engine.events.input;

public record MouseEvent(MouseEventType Type, float X, float Y, Button Button) : IEvent
{
    public Guid Id { get; } = Guid.NewGuid();
}