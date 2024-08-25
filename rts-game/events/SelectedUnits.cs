using game_engine.events;

namespace rts_game.events;

public class SelectedUnits : IEvent
{
    public Guid Id { get; }

    public SelectedUnits(IEnumerable<Unit> selectedObjects)
    {
        Id = Guid.NewGuid();
    }
}
