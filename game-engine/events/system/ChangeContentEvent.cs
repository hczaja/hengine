﻿namespace game_engine.events.system;

public record ChangeContentEvent() : IEvent
{
    public Guid Id { get; } = Guid.NewGuid();
}
