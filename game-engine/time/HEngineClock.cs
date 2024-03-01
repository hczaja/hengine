using SFML.System;

namespace game_engine.time;

public class HEngineClock : Clock, IClock
{
    private float _totalTimeBeforeUpdate;
    private float _totalTimeElapsed;
    private float _previousTotalTimeElapsed;

    private readonly float _timeBeforeUpdate;

    public HEngineClock(float fps)
    {
        this._timeBeforeUpdate = 1f / fps;
    }

    public bool TryUpdate()
    {
        this._totalTimeElapsed = this.ElapsedTime.AsSeconds();

        float deltaTime = this._totalTimeElapsed - this._previousTotalTimeElapsed;
        this._previousTotalTimeElapsed = this._totalTimeElapsed;

        this._totalTimeBeforeUpdate += deltaTime;

        return this._totalTimeBeforeUpdate >= this._timeBeforeUpdate;
    }

    public new void Restart()
    {
        this._totalTimeBeforeUpdate = 0f;
    }
}
