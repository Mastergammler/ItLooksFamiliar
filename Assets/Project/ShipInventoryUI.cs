using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInventoryUI : InventoryUI
{
    public GameObject PlayerInventory;

    private IInventory mPlayerInv;

    private void Start()
    {
        base.Init();
        mPlayerInv = PlayerInventory.GetComponent<IInventory>();
    }

    public override void RemoveItemFromSlot(int slotNo)
    {
        CollectableSO item = mInv.GetItemInSlot(slotNo);
        mInv.RemoveItem(slotNo);
        bool succ = mPlayerInv.AddItem(item);
    }

    public void AddItem(int targetSlotNo,int itemSlotNo)
    {
        CollectableSO item = mPlayerInv.GetItemInSlot(itemSlotNo);
        bool succ = mInv.AddItem(targetSlotNo,item);
        mPlayerInv.RemoveItem(itemSlotNo);
    }
}
