using game_engine.events.input;
using SFML.Graphics;

namespace game_engine.system;

public static class Extensions
{
    public static bool IsMouseEventRaisedIn(this FloatRect rectangle, MouseEvent @event) =>
        rectangle.Left < @event.X && @event.X < rectangle.Left + rectangle.Width &&
        rectangle.Top < @event.Y && @event.Y < rectangle.Top + rectangle.Height;
}
