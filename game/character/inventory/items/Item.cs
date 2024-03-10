namespace game.character.inventory.items;

abstract class Item
{
    public string Name { get; }
    public ItemType Type { get; }

    public Item(string name, ItemType type)
        => (Name, Type) = (name, type);
}
