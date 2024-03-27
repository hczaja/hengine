namespace game_contracts.locations;

public class LocationNode
{
    public string Name { get; }
    public float X { get; }
    public float Y { get; }

    public LocationNode(string name, float x, float y)
    {
        Name = name;
        X = x;
        Y = y;
    }
}