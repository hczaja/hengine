using game.character.diary;
using game_engine.events;

namespace game.events;

record SelectedQuestChangedEvent(IQuest quest) : IEvent
{
    public Guid Id => Guid.NewGuid();
}
