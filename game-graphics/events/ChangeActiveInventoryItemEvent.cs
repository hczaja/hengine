using game.graphics.ui.custom;
using game_engine.events;

namespace game_graphics.events;

public record ChangeActiveInventoryItemEvent(InventoryItemBlock Block) : IEvent
{
    public Guid Id { get; } = Guid.NewGuid();
}

