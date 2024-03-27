using game_contracts.diary;
using game_engine.events;

namespace game_graphics.events;

public record SelectedQuestChangedEvent(IQuest quest) : IEvent
{
    public Guid Id => Guid.NewGuid();
}
