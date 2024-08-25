using game_engine.graphics;
using SFML.Graphics;

namespace rts_game;

public interface IGameObject : IDrawable
{
    public Guid Id { get; }
    public Guid TypeId { get; }

    public FloatRect GetPositionRect();
    public void Update();

    //void Select();
    //void Unselect();
}
