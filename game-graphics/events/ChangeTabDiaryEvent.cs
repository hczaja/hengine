using game_engine.events;

namespace game_graphics.events;

public record ChangeTabDiaryEvent : IEvent
{
    public Guid Id { get; } = Guid.NewGuid();
}
