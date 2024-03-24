using game.locations.data.chapter_one;
using SFML.System;

namespace game.locations;

class LocationManager
{
    public ILocation GetStartingLocation(Vector2f position)
    {
        return new TrintedRillRegion(position);
    }
}
