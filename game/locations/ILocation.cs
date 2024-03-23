namespace game.locations;

interface ILocation
{
    string Id { get; set; }
    IEnumerable<IRoute> Routes { get; }
    IEnumerable<ILocationNode> Nodes { get; }
}

interface ILocationNode
{
    IEnumerable<IRoute> Routes { get; }
}

interface IRoute
{
    string OriginId { get; }
    string DestinationId { get; }
    float Distance { get; }
    float Difficulty { get; }
}
