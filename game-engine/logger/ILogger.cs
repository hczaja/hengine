namespace game_engine.logger;

public interface ILogger
{
    EventHandler<EventArgs> OnLog { get; set; }
    void Log(IMessage message);
}
