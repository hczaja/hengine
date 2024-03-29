using game.locations.data.chapter_one;
using game_contracts.locations;
using game_contracts.logger;

namespace game.locations;

class LocationManager : ILocationManager
{
    public IEnumerable<ILocation> Locations { get; }

    public LocationManager(ILogger logger)
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
