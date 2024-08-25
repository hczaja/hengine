using game_engine.events;

namespace rts_game.events;

public class SelectedUnitsEvent : IEvent
{
    public Guid Id { get; }
    public IEnumerable<IGameObject> Objects { get; }

    public SelectedUnitsEvent(IEnumerable<IGameObject> selectedObjects)
    {
        Id = Guid.NewGuid();
        Objects = selectedObjects;
    }
}
