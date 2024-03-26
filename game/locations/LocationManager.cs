using game.locations.data.chapter_one;
using SFML.System;

namespace game.locations;

class LocationManager
{
    IEnumerable<ILocation> Locations { get; }

    public LocationManager()
    {
        Locations = new List<ILocation>()
        {

        };
    }

    public ILocation GetStartingLocation(Vector2f position)
    {
        return new TrintedRillRegion(position);
    }
}
