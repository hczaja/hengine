using game.scripts;

namespace game.locations;

class Journey
{
    public float RequiredEnergy { get; }
    public DateTimeOffset RequiredTime { get; }
    public IEnumerable<Script> Scripts { get; }
}
