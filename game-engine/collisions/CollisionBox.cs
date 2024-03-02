using game_engine.graphics;
using game_engine.toggles;
using SFML.Graphics;
using SFML.System;

namespace game_engine.collisions;

public class CollisionBox : ICollider, IDrawable
{
    public RectangleShape Shape { get; }

    public CollisionBox(RectangleShape shape) => Shape = shape;

    public bool Collide(ICollider other)
    {
        if (other is CollisionBox cb)
            return Collide(cb);

        return false;
    }

    private bool Collide(CollisionBox other)
    {
        var topLeft = new Vector2f(Shape.Position.X, Shape.Position.Y);
        var bottomRight = new Vector2f(Shape.Position.X + Shape.Size.X, Shape.Position.Y + Shape.Size.Y);

        var topLeftOther = new Vector2f(other.Shape.Position.X, other.Shape.Position.Y);
        var bottomRightOther = new Vector2f(other.Shape.Position.X + other.Shape.Size.X, other.Shape.Position.Y + other.Shape.Size.Y);

        if (topLeft.X == bottomRight.X
            || topLeft.Y == bottomRight.Y
            || bottomRightOther.X == topLeftOther.X
            || topLeftOther.Y == bottomRightOther.Y)
            return false;

        if (topLeft.X > bottomRightOther.X
            || topLeftOther.X > bottomRight.X)
            return false;

        if (bottomRight.Y > topLeftOther.Y
            || bottomRightOther.Y > topLeft.Y)
            return false;

        return true;
    }

    public void Draw(RenderTarget render)
    {
        if (Toggles.DrawCollisions)
        {
            render.Draw(Shape);
        }
    }
}
