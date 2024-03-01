namespace game_engine.time;

public interface IClock
{
    bool TryUpdate();
    void Restart();
}
