namespace game_contracts.logger;

public interface ILogger
{
    EventHandler<EventArgs> OnLog { get; set; }
    string DisplayText { get; }

    void Log(IMessage message);
}
