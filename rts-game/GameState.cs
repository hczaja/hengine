using SFML.System;

namespace rts_game;

public class GameState
{
    public GameState()
    {
        var factory = new UnitsFactory();
        Units = new List<Unit>()
        {
            factory.CreatePikeman(new Vector2f(64, 64))
        };
    }

    public IEnumerable<Unit> Units { get; }
}