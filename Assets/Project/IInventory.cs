using System;
using UnityEngine;

public interface IInventory 
{
    event EventHandler<InventoryObject> OnInventoryChanged;
    bool AddItem(CollectableSO item); 
    void RemoveItem(CollectableSO item);
    CollectableSO GetItemInSlot(int slotNo);
}

public struct InventoryObject
{
    public InventoryObject(int slotNo) : this(slotNo,null) {}
    public InventoryObject(int slotNo,CollectableSO item)
    {
        SlotNo = slotNo;
        Item = item;
    }

    public int SlotNo { get;}
    public CollectableSO Item { get;}
}
