namespace game.scripts;

class Script
{
    public Guid Id { get; }
    public Func<object[], bool> Condition { get; }
}
