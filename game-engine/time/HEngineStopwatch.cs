using SFML.System;

namespace game_engine.time;

public class HEngineStopwatch : Clock
{
    private float InitialTime { get; set; }
    private float RealTime { get; set; }

    public HEngineStopwatch(float initialTime) => InitialTime = initialTime;

    public bool TryUpdate()
    {
        RealTime = InitialTime - ElapsedTime.AsSeconds();
        return RealTime > 0f;
    }

    public new void Restart()
    {
        RealTime = InitialTime;
    }
}