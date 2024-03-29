using game_engine.events;
using game_graphics.graphics.ui.custom;

namespace game_graphics.events;

public record ChangeActiveInventoryItemEvent(InventoryItemBlock Block) : IEvent
{
    public Guid Id { get; } = Guid.NewGuid();
}

