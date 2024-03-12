using game.character.inventory.items;

namespace game.character.inventory;

class CharacterInventory : IInventory
{
    public CharacterInventory()
    {
        //Backpack = new 
    }

    public IEnumerable<Item> Backpack { get; } = new List<Item>()
    {
        new Item("test", ItemType.Valueable),
        new Item("test2", ItemType.Valueable),
        new Item("test", ItemType.Valueable),
        new Item("test2", ItemType.Valueable),
        new Item("test", ItemType.Valueable),
        new Item("test2", ItemType.Valueable),
        new Item("test", ItemType.Valueable),
        new Item("test2", ItemType.Valueable)
    };

    public Item Weapon => null;

    public Item Armour => null;

    public Item Boots => new Item("test", ItemType.Boots);

    public float MaxCapacity => 10f;

    public float GetCapacity()
    {
        return Backpack.Count();
    }
}
