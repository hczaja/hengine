namespace game_engine.collisions;

public interface ICollider
{
    bool Collide(ICollider other);
}
