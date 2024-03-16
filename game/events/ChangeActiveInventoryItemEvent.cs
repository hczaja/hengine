using game.graphics.ui.custom;
using game_engine.events;

record ChangeActiveInventoryItemEvent(InventoryItemBlock Block) : IEvent
{
    public Guid Id { get; } = Guid.NewGuid();
}

