using game.events;
using game_engine.events;
using game_engine.graphics;
using SFML.Graphics;

namespace game.graphics.ui.custom;

class QuestDescriptionItemBlock : IDrawable, IEventHandler<SelectedQuestChangedEvent>
{
    public void Draw(RenderTarget render)
    {
    }

    public void Handle(SelectedQuestChangedEvent @event)
    {
    }
}
