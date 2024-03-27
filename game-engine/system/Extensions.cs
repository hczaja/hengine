using game_engine.events.input;
using SFML.Graphics;
using SFML.System;

namespace game_engine.system;

public static class Extensions
{
    public static bool IsMouseEventRaisedInRectangle(this FloatRect rectangle, MouseEvent @event) =>
        rectangle.Left < @event.X && @event.X < rectangle.Left + rectangle.Width &&
        rectangle.Top < @event.Y && @event.Y < rectangle.Top + rectangle.Height;

    public static bool IsMouseEventRaisedInCircle(this Vector2f center, float radius, MouseEvent @event) =>
        Math.Pow(@event.X - center.X, 2) + Math.Pow(@event.Y - center.Y, 2) < Math.Pow(radius, 2); 

    public static Vector2f GetCenterPosition(this CircleShape circle) => circle.Position + new Vector2f(circle.Radius, circle.Radius);
}
