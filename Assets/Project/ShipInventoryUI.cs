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
        base.RemoveItemFromSlot(slotNo);
        mPlayerInv.AddItem(item);
    }

    public void AddItem(int targetSlotNo,int itemSlotNo)
    {
        CollectableSO item = mPlayerInv.GetItemInSlot(itemSlotNo);
        if(item == null) Debug.Log("Item no " + itemSlotNo + " was not found in the player inventory");
        bool succ = mInv.AddItem(targetSlotNo,item);
        mPlayerInv.RemoveItem(itemSlotNo);
        Debug.Log("Adding item to slot no " + targetSlotNo + " was " + succ);
    }
}
