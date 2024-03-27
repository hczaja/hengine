using game.locations.data.chapter_one;
using game_contracts.locations;
using SFML.System;

namespace game.locations;

class LocationManager : ILocationManager
{
    public IEnumerable<ILocation> Locations { get; }

    public LocationManager()
    {
        Locations = new List<ILocation>()
        {

        };
    }

    public ILocation GetStartingLocation()
    {
        return new TrintedRillRegion();
    }
}
