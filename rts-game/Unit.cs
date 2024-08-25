using game_engine.graphics;
using SFML.Graphics;
using SFML.System;

namespace rts_game;

public class Unit : IDrawable
{
    public static class Type
    {
        public static readonly Guid Pikeman = Guid.Parse("72DBDF06-87F9-467A-A778-FBC6DDDCA70F");
    }

    public Guid Id { get; }
    public Guid TypeId { get; }

    private readonly RectangleShape _shape;
    private readonly RectangleShape _collisionBox;

    public Unit(
        RectangleShape shape, 
        RectangleShape collisionBox, 
        Guid typeId)
    {
        Id = Guid.NewGuid();
        TypeId = typeId;

        _shape = shape;
        _collisionBox = collisionBox;
    }

    public FloatRect GetPositionRect() => _collisionBox.GetGlobalBounds();

    public void DrawBy(RenderTarget render)
    {
        render.Draw(_shape);

        if (MainRTSSettings.DrawCollisions)
        {
            render.Draw(_collisionBox);
        }
    }

    public void Update()
    {
        _shape.Position = _collisionBox.Position - new Vector2f(0, 32);
    }
}

public class UnitsFactory
{
    public Unit CreatePikeman(Vector2f position)
    {
        var rect = new RectangleShape(
            new Vector2f(32, 64));

        rect.Texture = new Texture("assets/pikeman.png");
        
        var box = new RectangleShape(
            new Vector2f(32, 32));

        box.FillColor = Color.Transparent;

        box.OutlineThickness = 1;
        box.OutlineColor = Color.White;

        box.Position = position;

        var pikeman = new Unit(rect, box, Unit.Type.Pikeman);
        return pikeman;
    }

}
