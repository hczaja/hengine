using System.Reflection;

namespace game_engine.toggles;

public static class Toggles
{
    public static bool DrawCollisions { get; private set; }

    public static void Set(string name, bool value)
    {
        var property = typeof(Toggles).GetProperty(name, BindingFlags.Public | BindingFlags.Static);
        if (property is not null)
        {
            property.SetValue(null, value);
        }
    }
}
