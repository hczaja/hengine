using game_engine.events;

namespace game.events;

record ChangeTabDiaryEvent : IEvent
{
    public Guid Id { get; } = Guid.NewGuid();
}
