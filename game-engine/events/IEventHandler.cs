namespace game_engine.events;

public interface IEventHandler<T> where T : IEvent
{
    public void Handle(T @event);
}
