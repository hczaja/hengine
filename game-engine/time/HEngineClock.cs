﻿using game_engine.settings;
using SFML.System;

namespace game_engine.time;

public class HEngineClock : Clock, IClock
{
    private float _totalTimeBeforeUpdate;
    private float _totalTimeElapsed;
    private float _previousTotalTimeElapsed;

    private readonly float _timeBeforeUpdate;

    public HEngineClock()
    {
        _timeBeforeUpdate = 1f / HEngineSettings.Instance.FPS;
    }

    public bool TryUpdate()
    {
        _totalTimeElapsed = ElapsedTime.AsSeconds();

        float deltaTime = _totalTimeElapsed - _previousTotalTimeElapsed;
        _previousTotalTimeElapsed = _totalTimeElapsed;

        _totalTimeBeforeUpdate += deltaTime;

        return _totalTimeBeforeUpdate >= _timeBeforeUpdate;
    }

    public new void Restart()
    {
        _totalTimeBeforeUpdate = 0f;
    }
}
