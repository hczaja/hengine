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
        new Item("test", ItemType.Armour),
        new Item("test2", ItemType.Boots),
        new Item("test", ItemType.OneHandedWeapon),
        new Item("test2", ItemType.ToEat),
        new Item("test", ItemType.Mixture),
        new Item("test2", ItemType.ToEat),
        new Item("test", ItemType.Valueable),
        new Item("test2", ItemType.Valueable)
    };

    public Item Weapon => new Item("test", ItemType.OneHandedWeapon);

    public Item Armour => new Item("test", ItemType.Armour);

    public Item Boots => new Item("test", ItemType.Boots);

    public float MaxCapacity => 25f;

    public float GetCapacity()
    {
        return Backpack.Count();
    }
}
