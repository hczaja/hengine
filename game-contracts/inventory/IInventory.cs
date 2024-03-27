namespace game_contracts.inventory
{
    public interface IInventory
    {
        IEnumerable<Item> Backpack { get; }

        Item Weapon { get; }
        Item Armour { get; }
        Item Boots { get; }

        float GetCapacity();
        float MaxCapacity { get; }
    }

}
