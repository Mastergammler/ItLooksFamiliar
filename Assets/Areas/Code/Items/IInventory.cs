using System;
using UnityEngine;

namespace ItLooksFamiliar.Items
{

    public interface IInventory
    {
        event EventHandler<InventoryObject> OnInventoryChanged;
        bool AddItem(CollectableSO item);
        bool AddItem(int slotNo, CollectableSO item);
        void RemoveItem(CollectableSO item);
        void RemoveItem(int slotNo);
        CollectableSO GetItemInSlot(int slotNo);
    }

    public struct InventoryObject
    {
        public InventoryObject(int slotNo) : this(slotNo, null) { }
        public InventoryObject(int slotNo, CollectableSO item)
        {
            SlotNo = slotNo;
            Item = item;
        }

        public int SlotNo { get; }
        public CollectableSO Item { get; }
    }

}