using Enemy;

namespace Player.Inventory.InventoryInterface
{
    public interface IInventoryRemove
    {
        void RemoveItem(ItemData itemData, int count);
    }
}