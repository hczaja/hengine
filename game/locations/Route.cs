using game_contracts.locations;

namespace game.locations;

class Route
{
    public string DisplayName { get; set; }

    private LocationNode NodeA { get; set; }
    private LocationNode NodeB { get; set; }

    public Journey GetJourneyFromAToB() => throw new NotImplementedException();
    public Journey GetJourneyFromBToA() => throw new NotImplementedException();
}
