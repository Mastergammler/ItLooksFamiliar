using UnityEngine;

public interface IInventory 
{
    bool AddItem(CollectableSO item);
    void RemoveItem(CollectableSO item);
    CollectableSO GetItemInSlot(int slotNo);
}
