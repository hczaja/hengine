namespace game_contracts.locations;

public interface ILocationManager
{
    IEnumerable<ILocation> Locations { get; }
    ILocation GetStartingLocation();
}
