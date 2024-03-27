namespace game_contracts.inventory;

public class Item
{
    public string Name { get; }
    public ItemType Type { get; }

    public Item(string name, ItemType type)
    {
        Name = name;
        Type = type;
    }
}
