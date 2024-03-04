using game_engine.context;

namespace game_engine.events.system;

public record ChangeContextEvent(IContext Context) : IEvent
{
    public Guid Id { get; } = Guid.NewGuid();
}
